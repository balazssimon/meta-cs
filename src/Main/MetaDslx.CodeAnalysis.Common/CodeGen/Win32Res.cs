// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Generic;
using MetaDslx.CodeAnalysis.Text;
using Cci = MetaDslx.Cci;
using DWORD = System.UInt32;

namespace MetaDslx.CodeAnalysis.CodeGen
{
    internal class Win32Resource : Cci.IWin32Resource
    {
        private readonly byte[] _data;
        private readonly DWORD _codePage;
        private readonly DWORD _languageId;
        private readonly int _id;
        private readonly string _name;
        private readonly int _typeId;
        private readonly string _typeName;

        internal Win32Resource(
            byte[] data,
            DWORD codePage,
            DWORD languageId,
            int id,
            string name,
            int typeId,
            string typeName)
        {
            _data = data;
            _codePage = codePage;
            _languageId = languageId;
            _id = id;
            _name = name;
            _typeId = typeId;
            _typeName = typeName;
        }

        public string TypeName => _typeName;

        public int TypeId => _typeId;

        public string Name => _name;

        public int Id => _id;

        public DWORD LanguageId => _languageId;

        public DWORD CodePage => _codePage;

        public IEnumerable<byte> Data => _data;
    }
}
