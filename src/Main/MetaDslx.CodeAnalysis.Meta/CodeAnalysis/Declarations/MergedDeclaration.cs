using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.CodeAnalysis;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis.PooledObjects;
using MetaDslx.CodeAnalysis.Symbols;

namespace MetaDslx.CodeAnalysis.Declarations
{
    public sealed class MergedDeclaration : Declaration
    {
        private readonly ImmutableArray<SingleDeclaration> _declarations;
        private ImmutableArray<MergedDeclaration> _lazyChildren;
        private ImmutableArray<string> _lazyChildNames;
        private MutableObjectBase _modelObject;

        public MergedDeclaration(ImmutableArray<SingleDeclaration> declarations)
            : base(declarations.IsEmpty ? null : declarations[0].Name,
                  declarations.IsEmpty ? false : declarations[0].Merge,
                  declarations.IsEmpty ? string.Empty : declarations[0].ParentPropertyToAddTo)
        {
            this._declarations = declarations;
        }

        public ImmutableArray<SingleDeclaration> Declarations
        {
            get
            {
                return _declarations;
            }
        }

        public ImmutableArray<SyntaxReference> SyntaxReferences
        {
            get
            {
                return _declarations.SelectAsArray(r => r.SyntaxReference);
            }
        }

        public override ModelObjectDescriptor ModelObjectType
        {
            get
            {
                return this._declarations.IsEmpty ? null : this._declarations[0].ModelObjectType;
            }
        }

        public LexicalSortKey GetLexicalSortKey(LanguageCompilation compilation)
        {
            LexicalSortKey sortKey = new LexicalSortKey(Declarations[0].NameLocation, compilation);
            for (var i = 1; i < Declarations.Length; i++)
            {
                sortKey = LexicalSortKey.First(sortKey, new LexicalSortKey(Declarations[i].NameLocation, compilation));
            }

            return sortKey;
        }

        public ImmutableArray<Location> NameLocations
        {
            get
            {
                if (Declarations.Length == 1)
                {
                    return ImmutableArray.Create(Declarations[0].NameLocation);
                }
                else
                {
                    var builder = ArrayBuilder<Location>.GetInstance();
                    foreach (var decl in Declarations)
                    {
                        Location loc = decl.NameLocation;
                        if (loc != null)
                            builder.Add(loc);
                    }
                    return builder.ToImmutableAndFree();
                }
            }
        }

        private void MakeChildren()
        {
            ArrayBuilder<SingleDeclaration> nestedDeclarations = null;

            foreach (var decl in this.Declarations)
            {
                foreach (var child in decl.Children)
                {
                    var asSingle = child as SingleDeclaration;
                    if (asSingle != null)
                    {
                        if (nestedDeclarations == null)
                        {
                            nestedDeclarations = ArrayBuilder<SingleDeclaration>.GetInstance();
                        }
                        nestedDeclarations.Add(asSingle);
                    }
                }
            }

            var members = ArrayBuilder<MergedDeclaration>.GetInstance();
            var memberNames = ArrayBuilder<string>.GetInstance();

            if (nestedDeclarations != null)
            {
                var membersGrouped = nestedDeclarations.ToDictionary(m => m.Identity);
                nestedDeclarations.Free();

                foreach (var memberGroup in membersGrouped.Values)
                {
                    var merged = new MergedDeclaration(memberGroup);
                    members.Add(merged);
                    if (merged.Name != null) memberNames.Add(merged.Name);
                }
            }

            ImmutableInterlocked.InterlockedInitialize(ref _lazyChildren, members.ToImmutableAndFree());
            ImmutableInterlocked.InterlockedInitialize(ref _lazyChildNames, memberNames.ToImmutableAndFree());
        }

        public new ImmutableArray<MergedDeclaration> Children
        {
            get
            {
                if (_lazyChildren.IsDefault) MakeChildren();
                return _lazyChildren;
            }
        }

        public override ImmutableArray<string> ChildNames
        {
            get
            {
                if (_lazyChildNames.IsDefault) MakeChildren();
                return _lazyChildNames;
            }
        }
        
        protected override ImmutableArray<Declaration> GetDeclarationChildren()
        {
            return StaticCast<Declaration>.From(this.Children);
        }

        public static MergedDeclaration Create(ImmutableArray<SingleDeclaration> declarations)
        {
            return new MergedDeclaration(declarations);
        }

        public static MergedDeclaration Create(SingleDeclaration declaration)
        {
            return new MergedDeclaration(ImmutableArray.Create(declaration));
        }

        public static MergedDeclaration Create(
            MergedDeclaration mergedDeclaration,
            SingleDeclaration declaration)
        {
            return new MergedDeclaration(mergedDeclaration._declarations.Add(declaration));
        }

        public MutableObjectBase GetModelObject(MutableObjectBase parentObject, MutableModel model, DiagnosticBag diagnostics)
        {
            if (_modelObject == null)
            {
                lock (this) // We must lock, we do not want to create multiple symbols for the same declaration
                {
                    if (_modelObject != null) return _modelObject;
                    var modelObject = this.ModelObjectType.CreateMutable(model);
                    modelObject.MName = this.Name;
                    if (parentObject != null && !string.IsNullOrEmpty(this.ParentPropertyToAddTo))
                    {
                        var property = parentObject.MGetProperty(this.ParentPropertyToAddTo);
                        if (property != null)
                        {
                            try
                            {
                                parentObject.MAdd(property, modelObject);
                            }
                            catch (ModelException me)
                            {
                                diagnostics.Add(ModelErrorCode.ERR_CannotSetValueToProperty, this.NameLocations[0], property, modelObject, me.ToString());
                            }
                        }
                    }
                    Interlocked.CompareExchange(ref _modelObject, modelObject, null);
                }
            }
            return _modelObject;
        }
    }
}
