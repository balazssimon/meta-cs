﻿using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.BuildTasks
{
    public class Antlr4RoslynGenerationTask : Task
    {
        private const string DefaultGeneratedSourceExtension = "g4";
        private List<ITaskItem> _generatedCodeFiles = new List<ITaskItem>();

        public Antlr4RoslynGenerationTask()
        {
            this.GeneratedSourceExtension = DefaultGeneratedSourceExtension;
        }
        
        [Required]
        public string OutputPath
        {
            get;
            set;
        }

        public string Encoding
        {
            get;
            set;
        }

        public ITaskItem[] SourceCodeFiles
        {
            get;
            set;
        }

        public string GeneratedSourceExtension
        {
            get;
            set;
        }

        public string TargetNamespace
        {
            get;
            set;
        }

        [Output]
        public ITaskItem[] GeneratedCodeFiles
        {
            get
            {
                return this._generatedCodeFiles.ToArray();
            }
            set
            {
                this._generatedCodeFiles = new List<ITaskItem>(value);
            }
        }

        public override bool Execute()
        {
            AssemblyResolver.Enable();
            return true;
        }
    }
}
