// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using Roslyn.Utilities;

namespace Microsoft.CodeAnalysis.CSharp.Syntax
{
    [DebuggerDisplay("{GetDebuggerDisplay(), nq}")]
    public abstract class Directive
    {
        private readonly CSharpSyntaxNode _node;
        private readonly bool _isActive;

        protected Directive(CSharpSyntaxNode node, bool isActive)
        {
            Debug.Assert(node is IDirectiveTriviaSyntax);
            _node = node;
            _isActive = isActive;
        }

        public abstract DirectiveKind Kind { get; }

        public virtual bool IncrementallyEquivalent(Directive other)
        {
            if (this.Kind != other.Kind)
            {
                return false;
            }

            bool isActive = this.IsActive;
            bool otherIsActive = other.IsActive;

            // states of inactive directives don't matter
            if (!isActive && !otherIsActive)
            {
                return true;
            }

            if (isActive != otherIsActive)
            {
                return false;
            }

            switch (this.Kind)
            {
                case DirectiveKind.Define:
                case DirectiveKind.Undef:
                    return this.GetIdentifier() == other.GetIdentifier();
                case DirectiveKind.If:
                case DirectiveKind.Elif:
                case DirectiveKind.Else:
                    return this.BranchTaken == other.BranchTaken;
                default:
                    return true;
            }
        }

        // Can't be private as it's called by DirectiveStack in its GetDebuggerDisplay()
        internal string GetDebuggerDisplay()
        {
            var writer = new System.IO.StringWriter(System.Globalization.CultureInfo.InvariantCulture);
            _node.WriteTo(writer);
            return writer.ToString();
        }

        public virtual string GetIdentifier()
        {
            return null;
        }

        public virtual bool HasRelatedDirectives
        {
            get { return false; }
        }

        public virtual bool IsActive
        {
            get { return _isActive; }
        }

        public virtual bool BranchTaken 
        {
            get { return false; }
        }
    }

    public abstract class BranchingDirective : Directive
    {
        public BranchingDirective(CSharpSyntaxNode node, bool isActive) 
            : base(node, isActive)
        {
        }
    }

    public abstract class ConditionalDirective : BranchingDirective
    {
        public ConditionalDirective(CSharpSyntaxNode node, bool isActive)
            : base(node, isActive)
        {
        }

        public abstract CSharpSyntaxNode Condition { get; }
        public abstract bool ConditionValue { get; }
    }

    public class IfDirective : ConditionalDirective
    {
        private readonly CSharpSyntaxNode _condition;
        private readonly bool _branchTaken;
        private readonly bool _conditionValue;

        public IfDirective(CSharpSyntaxNode node, CSharpSyntaxNode condition, bool isActive, bool branchTaken, bool conditionValue)
            : base(node, isActive)
        {
            _condition = condition;
            _branchTaken = branchTaken;
            _conditionValue = conditionValue;
        }

        public override CSharpSyntaxNode Condition => _condition;

        public override bool ConditionValue => _conditionValue;

        public override DirectiveKind Kind => DirectiveKind.If;

        public override bool HasRelatedDirectives => true;
    }

    public class ElifDirective : ConditionalDirective
    {
        private readonly CSharpSyntaxNode _condition;
        private readonly bool _branchTaken;
        private readonly bool _conditionValue;

        public ElifDirective(CSharpSyntaxNode node, CSharpSyntaxNode condition, bool isActive, bool branchTaken, bool conditionValue)
            : base(node, isActive)
        {
            _condition = condition;
            _branchTaken = branchTaken;
            _conditionValue = conditionValue;
        }

        public override CSharpSyntaxNode Condition => _condition;

        public override bool ConditionValue => _conditionValue;

        public override DirectiveKind Kind => DirectiveKind.Elif;

        public override bool HasRelatedDirectives => true;
    }

    public class ElseDirective : BranchingDirective
    {
        private readonly bool _branchTaken;

        public ElseDirective(CSharpSyntaxNode node, bool isActive, bool branchTaken)
            : base(node, isActive)
        {
            _branchTaken = branchTaken;
        }

        public override DirectiveKind Kind => DirectiveKind.Else;

        public override bool HasRelatedDirectives => true;
    }

    public class EndIfDirective : Directive
    {
        public EndIfDirective(CSharpSyntaxNode node, bool isActive)
            : base(node, isActive)
        {
        }

        public override DirectiveKind Kind => DirectiveKind.EndIf;

        public override bool HasRelatedDirectives => true;
    }

    public class RegionDirective : Directive
    {
        public RegionDirective(CSharpSyntaxNode node, bool isActive)
            : base(node, isActive)
        {
        }

        public override DirectiveKind Kind => DirectiveKind.Region;

        public override bool HasRelatedDirectives => true;
    }

    public class EndRegionDirective : Directive
    {
        public EndRegionDirective(CSharpSyntaxNode node, bool isActive)
            : base(node, isActive)
        {
        }

        public override DirectiveKind Kind => DirectiveKind.EndRegion;

        public override bool HasRelatedDirectives => true;
    }
    public class DefineDirective : Directive
    {
        private readonly string _name;

        public DefineDirective(CSharpSyntaxNode node, bool isActive, string name)
            : base(node, isActive)
        {
            _name = name;
        }

        public override DirectiveKind Kind => DirectiveKind.Define;

        public string Name => _name;

        public override string GetIdentifier()
        {
            return _name;
        }
    }

    public class UndefDirective : Directive
    {
        private readonly string _name;

        public UndefDirective(CSharpSyntaxNode node, bool isActive, string name)
            : base(node, isActive)
        {
            _name = name;
        }

        public override DirectiveKind Kind => DirectiveKind.Undef;

        public string Name => _name;

        public override string GetIdentifier()
        {
            return _name;
        }
    }

    public class ReferenceDirective : Directive
    {
        private readonly string _file;

        public ReferenceDirective(CSharpSyntaxNode node, bool isActive, string file)
            : base(node, isActive)
        {
            _file = file;
        }

        public override DirectiveKind Kind => DirectiveKind.Undef;

        public string File => _file;
    }

    public class LoadDirective : Directive
    {
        private readonly string _file;

        public LoadDirective(CSharpSyntaxNode node, bool isActive, string file)
            : base(node, isActive)
        {
            _file = file;
        }

        public override DirectiveKind Kind => DirectiveKind.Undef;

        public string File => _file;
    }

    public enum LineDirectiveKind
    {
        Default,
        Hidden,
        Number
    }

    public class LineDirective : Directive
    {
        private readonly LineDirectiveKind _kind;
        private readonly int _line;
        private readonly string _file;

        public LineDirective(CSharpSyntaxNode node, bool isActive, int line, string file = null)
            : base(node, isActive)
        {
            _kind = LineDirectiveKind.Number;
            _line = line;
            _file = file;
        }

        public LineDirective(CSharpSyntaxNode node, bool isActive, LineDirectiveKind kind)
            : base(node, isActive)
        {
            _kind = kind;
        }

        public override DirectiveKind Kind => DirectiveKind.Line;

        public LineDirectiveKind LineKind => _kind;
        public string File => _file;
        public int Line => _line;
    }

    public enum PragmaWarningKind
    {
        Warning,
        Nullable
    }

    public class PragmaWarningDirective : Directive
    {
        private readonly PragmaWarningState _state;
        private readonly PragmaWarningKind _kind;
        private readonly ImmutableArray<string> _errorIds;

        public PragmaWarningDirective(CSharpSyntaxNode node, bool isActive, PragmaWarningState state, PragmaWarningKind kind, ImmutableArray<string> errorIds)
            : base(node, isActive)
        {
            _state = state;
            _kind = kind;
            _errorIds = errorIds;
        }

        public override DirectiveKind Kind => DirectiveKind.PragmaWarning;
        public PragmaWarningKind PragmaWarningKind => _kind;
        public PragmaWarningState State => _state;
        public ImmutableArray<string> ErrorIds => _errorIds;
    }

    public class NullableDirective : Directive
    {
        private readonly PragmaWarningState _state;

        public NullableDirective(CSharpSyntaxNode node, bool isActive, PragmaWarningState state)
            : base(node, isActive)
        {
            _state = state;
        }

        public override DirectiveKind Kind => DirectiveKind.Line;
        public PragmaWarningState State => _state;
    }

    public enum DefineState
    {
        Defined,
        Undefined,
        Unspecified
    }

    [DebuggerDisplay("{GetDebuggerDisplay(), nq}")]
    public struct DirectiveStack
    {
        public static readonly DirectiveStack Empty = new DirectiveStack(ConsList<Directive>.Empty);
        public static readonly DirectiveStack Null = new DirectiveStack(null);

        private readonly ConsList<Directive> _directives;

        private DirectiveStack(ConsList<Directive> directives)
        {
            _directives = directives;
        }

        public bool IsNull
        {
            get
            {
                return _directives == null;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return _directives == ConsList<Directive>.Empty;
            }
        }

        public DefineState IsDefined(string id)
        {
            for (var current = _directives; current != null && current.Any(); current = current.Tail)
            {
                switch (current.Head.Kind)
                {
                    case DirectiveKind.Define:
                        if (current.Head.GetIdentifier() == id)
                        {
                            return DefineState.Defined;
                        }

                        break;
                    case DirectiveKind.Undef:
                        if (current.Head.GetIdentifier() == id)
                        {
                            return DefineState.Undefined;
                        }

                        break;

                    case DirectiveKind.Elif:
                    case DirectiveKind.Else:
                        // Skip directives from previous branches of the same #if.
                        do
                        {
                            current = current.Tail;

                            if (current == null || !current.Any())
                            {
                                return DefineState.Unspecified;
                            }
                        }
                        while (current.Head.Kind != DirectiveKind.If);

                        break;
                }
            }

            return DefineState.Unspecified;
        }

        // true if any previous section of the closest #if has its branch taken
        public bool PreviousBranchTaken()
        {
            for (var current = _directives; current != null && current.Any(); current = current.Tail)
            {
                if (current.Head.BranchTaken)
                {
                    return true;
                }
                else if (current.Head.Kind == DirectiveKind.If)
                {
                    return false;
                }
            }

            return false;
        }

        public bool HasUnfinishedIf()
        {
            var prev = GetPreviousIfElifElseOrRegion(_directives);
            return prev != null && prev.Any() && prev.Head.Kind != DirectiveKind.Region;
        }

        public bool HasPreviousIfOrElif()
        {
            var prev = GetPreviousIfElifElseOrRegion(_directives);
            return prev != null && prev.Any() && (prev.Head.Kind == DirectiveKind.If || prev.Head.Kind == DirectiveKind.Elif);
        }

        public bool HasUnfinishedRegion()
        {
            var prev = GetPreviousIfElifElseOrRegion(_directives);
            return prev != null && prev.Any() && prev.Head.Kind == DirectiveKind.Region;
        }

        public DirectiveStack Add(Directive directive)
        {
            switch (directive.Kind)
            {
                case DirectiveKind.EndIf:
                    var prevIf = GetPreviousIf(_directives);
                    if (prevIf == null || !prevIf.Any())
                    {
                        goto default; // no matching if directive !! leave directive alone
                    }

                    bool tmp;
                    return new DirectiveStack(CompleteIf(_directives, out tmp));
                case DirectiveKind.EndRegion:
                    var prevRegion = GetPreviousRegion(_directives);
                    if (prevRegion == null || !prevRegion.Any())
                    {
                        goto default; // no matching region directive !! leave directive alone
                    }

                    return new DirectiveStack(CompleteRegion(_directives)); // remove region directives from stack but leave everything else
                default:
                    return new DirectiveStack(new ConsList<Directive>(directive, _directives != null ? _directives : ConsList<Directive>.Empty));
            }
        }

        // removes unfinished if & related directives from stack and leaves active branch directives
        private static ConsList<Directive> CompleteIf(ConsList<Directive> stack, out bool include)
        {
            // if we get to the top, the default rule is to include anything that follows
            if (!stack.Any())
            {
                include = true;
                return stack;
            }

            // if we reach the #if directive, then we stop unwinding and start
            // rebuilding the stack w/o the #if/#elif/#else/#endif directives
            // only including content from sections that are considered included
            if (stack.Head.Kind == DirectiveKind.If)
            {
                include = stack.Head.BranchTaken;
                return stack.Tail;
            }

            var newStack = CompleteIf(stack.Tail, out include);
            switch (stack.Head.Kind)
            {
                case DirectiveKind.Elif:
                case DirectiveKind.Else:
                    include = stack.Head.BranchTaken;
                    break;
                default:
                    if (include)
                    {
                        newStack = new ConsList<Directive>(stack.Head, newStack);
                    }

                    break;
            }

            return newStack;
        }

        // removes region directives from stack but leaves everything else
        private static ConsList<Directive> CompleteRegion(ConsList<Directive> stack)
        {
            // if we get to the top, the default rule is to include anything that follows
            if (!stack.Any())
            {
                return stack;
            }

            if (stack.Head.Kind == DirectiveKind.Region)
            {
                return stack.Tail;
            }

            var newStack = CompleteRegion(stack.Tail);
            newStack = new ConsList<Directive>(stack.Head, newStack);
            return newStack;
        }

        private static ConsList<Directive> GetPreviousIf(ConsList<Directive> directives)
        {
            var current = directives;
            while (current != null && current.Any())
            {
                switch (current.Head.Kind)
                {
                    case DirectiveKind.If:
                        return current;
                }

                current = current.Tail;
            }

            return current;
        }

        private static ConsList<Directive> GetPreviousIfElifElseOrRegion(ConsList<Directive> directives)
        {
            var current = directives;
            while (current != null && current.Any())
            {
                switch (current.Head.Kind)
                {
                    case DirectiveKind.If:
                    case DirectiveKind.Elif:
                    case DirectiveKind.Else:
                    case DirectiveKind.Region:
                        return current;
                }

                current = current.Tail;
            }

            return current;
        }

        private static ConsList<Directive> GetPreviousRegion(ConsList<Directive> directives)
        {
            var current = directives;
            while (current != null && current.Any() && current.Head.Kind != DirectiveKind.Region)
            {
                current = current.Tail;
            }

            return current;
        }

        private string GetDebuggerDisplay()
        {
            var sb = new StringBuilder();
            for (var current = _directives; current != null && current.Any(); current = current.Tail)
            {
                if (sb.Length > 0)
                {
                    sb.Insert(0, " | ");
                }

                sb.Insert(0, current.Head.GetDebuggerDisplay());
            }

            return sb.ToString();
        }

        public bool IncrementallyEquivalent(DirectiveStack other)
        {
            var mine = SkipInsignificantDirectives(_directives);
            var theirs = SkipInsignificantDirectives(other._directives);
            bool mineHasAny = mine != null && mine.Any();
            bool theirsHasAny = theirs != null && theirs.Any();
            while (mineHasAny && theirsHasAny)
            {
                if (!mine.Head.IncrementallyEquivalent(theirs.Head))
                {
                    return false;
                }

                mine = SkipInsignificantDirectives(mine.Tail);
                theirs = SkipInsignificantDirectives(theirs.Tail);
                mineHasAny = mine != null && mine.Any();
                theirsHasAny = theirs != null && theirs.Any();
            }

            return mineHasAny == theirsHasAny;
        }

        private static ConsList<Directive> SkipInsignificantDirectives(ConsList<Directive> directives)
        {
            for (; directives != null && directives.Any(); directives = directives.Tail)
            {
                switch (directives.Head.Kind)
                {
                    case DirectiveKind.If:
                    case DirectiveKind.Elif:
                    case DirectiveKind.Else:
                    case DirectiveKind.EndIf:
                    case DirectiveKind.Define:
                    case DirectiveKind.Undef:
                    case DirectiveKind.Region:
                    case DirectiveKind.EndRegion:
                        return directives;
                }
            }

            return directives;
        }
    }
}
