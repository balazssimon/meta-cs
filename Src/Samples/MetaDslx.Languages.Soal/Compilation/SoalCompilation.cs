using MetaDslx.Compiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Core;
using System.Collections.Immutable;
using MetaDslx.Compiler.Syntax;
using System.Threading;

namespace MetaDslx.Languages.Soal
{
    public class SoalCompilation : Compilation
    {
        public SoalCompilation(
            string name, 
            ImmutableArray<ImmutableModel> references, 
            bool isSubmission, 
            AsyncQueue<CompilationEvent> eventQueue) 
            : base(
                  name, 
                  references, 
                  isSubmission, 
                  eventQueue)
        {
        }

        public override bool IsCaseSensitive
        {
            get
            {
                return true;
            }
        }

        public override Language Language
        {
            get
            {
                return SoalLanguage.Instance;
            }
        }

        public override MessageProvider MessageProvider
        {
            get
            {
                return SoalMessageProvider.Instance;
            }
        }

        protected override IMetaSymbol CommonGlobalNamespace
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public new SoalCompilationOptions Options
        {
            get { }
        }

    }
}
