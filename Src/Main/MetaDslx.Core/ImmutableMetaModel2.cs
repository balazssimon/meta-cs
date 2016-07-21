using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MetaDslx.Core.Immutable;
using System.Diagnostics;

namespace Core
{
    public enum MetaCollectionKind
    {
    	MultiSet,
    	List,
    	Set,
    	MultiList
    }
    
    public enum MetaPropertyKind
    {
    	Normal,
    	Readonly,
    	Lazy,
    	Derived,
    	DerivedUnion,
    	Containment
    }
    
}

