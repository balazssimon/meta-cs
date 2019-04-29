// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Roslyn.Utilities;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public partial class SourceNamespaceSymbol
    {
        public override void ForceComplete(SourceLocation locationOpt, CancellationToken cancellationToken)
        {
            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();
                var incompletePart = _state.NextIncompletePart;
                if (incompletePart == CompletionPart.NameToMembersMap)
                {
                    var tmp = GetNameToMembersMap();
                }
                else if (incompletePart == CompletionPart.MembersCompleted)
                {
                    // ensure relevant imports are complete.
                    foreach (var declaration in _mergedDeclaration.Declarations)
                    {
                        if (locationOpt == null || locationOpt.SourceTree == declaration.SyntaxReference.SyntaxTree)
                        {
                            if (declaration.HasUsings || declaration.HasExternAliases)
                            {
                                this.DeclaringCompilation.GetImports(declaration).Complete(cancellationToken);
                            }
                        }
                    }

                    var members = this.GetMembers();

                    bool allCompleted = true;

                    if (this.DeclaringCompilation.Options.ConcurrentBuild)
                    {
                        var po = cancellationToken.CanBeCanceled
                            ? new ParallelOptions() { CancellationToken = cancellationToken }
                            : LanguageCompilation.DefaultParallelOptions;

                        Parallel.For(0, members.Length, po, UICultureUtilities.WithCurrentUICulture<int>(i =>
                        {
                            var member = members[i];
                            ForceCompleteMemberByLocation(locationOpt, member, cancellationToken);
                        }));

                        foreach (var member in members)
                        {
                            if (!member.HasComplete(CompletionPart.All))
                            {
                                allCompleted = false;
                                break;
                            }
                        }
                    }
                    else
                    {
                        foreach (var member in members)
                        {
                            ForceCompleteMemberByLocation(locationOpt, member, cancellationToken);
                            allCompleted = allCompleted && member.HasComplete(CompletionPart.All);
                        }
                    }

                    if (allCompleted)
                    {
                        _state.NotePartComplete(CompletionPart.MembersCompleted);
                        break;
                    }
                    else
                    {
                        // NOTE: we're going to kick out of the completion part loop after this,
                        // so not making progress isn't a problem.
                        goto done;
                    }
                }
                else if (incompletePart == CompletionPart.None)
                {
                    return;
                }
                else
                {
                    // any other values are completion parts intended for other kinds of symbols
                    // TODO:MetaDslx
                    //_state.NotePartComplete(CompletionPart.All & ~CompletionPart.NamespaceSymbolAll);
                    break;
                }

                _state.SpinWaitComplete(incompletePart, cancellationToken);
            }
        done:
            return;
            /*// TODO:MetaDslx
            // Don't return until we've seen all of the CompletionParts. This ensures all
            // diagnostics have been reported (not necessarily on this thread).

            CompletionPart allParts = (locationOpt == null) ? CompletionPart.NamespaceSymbolAll : CompletionPart.NamespaceSymbolAll & ~CompletionPart.MembersCompleted;
            _state.SpinWaitComplete(allParts, cancellationToken);
            */
        }

        public override bool HasComplete(CompletionPart part)
        {
            return _state.HasComplete(part);
        }
    }
}
