using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Languages.Ecore.Model.Internal
{
    internal class EcoreImplementation : EcoreImplementationBase
    {
        internal override void EcoreBuilderInstance(EcoreBuilderInstance _this)
        {
            EcoreFactory f = new EcoreFactory(_this.MModel);
            _this.EJavaObject = f.EDataType();
            _this.EJavaObject.Name = "EJavaObject";
            _this.EJavaClass = f.EDataType();
            _this.EJavaClass.Name = "EJavaClass";
            _this.EBoolean = f.EDataType();
            _this.EBoolean.Name = "EBoolean";
            _this.EString = f.EDataType();
            _this.EString.Name = "EString";
            _this.EByte = f.EDataType();
            _this.EByte.Name = "EByte";
            _this.EByteArray = f.EDataType();
            _this.EByteArray.Name = "EByteArray";
            _this.EChar = f.EDataType();
            _this.EChar.Name = "EChar";
            _this.EShort = f.EDataType();
            _this.EShort.Name = "EShort";
            _this.EInt = f.EDataType();
            _this.EInt.Name = "EInt";
            _this.ELong = f.EDataType();
            _this.ELong.Name = "ELong";
            _this.EFloat = f.EDataType();
            _this.EFloat.Name = "EFloat";
            _this.EDouble = f.EDataType();
            _this.EDouble.Name = "EDouble";
            _this.EByteObject = f.EDataType();
            _this.EByteObject.Name = "EByteObject";
            _this.ECharObject = f.EDataType();
            _this.ECharObject.Name = "ECharObject";
            _this.EShortObject = f.EDataType();
            _this.EShortObject.Name = "EShortObject";
            _this.EIntObject = f.EDataType();
            _this.EIntObject.Name = "EIntObject";
            _this.ELongObject = f.EDataType();
            _this.ELongObject.Name = "ELongObject";
            _this.EFloatObject = f.EDataType();
            _this.EFloatObject.Name = "EFloatObject";
            _this.EDoubleObject = f.EDataType();
            _this.EDoubleObject.Name = "EDoubleObject";
            _this.EDate = f.EDataType();
            _this.EDate.Name = "EDate";
            _this.EBigInteger = f.EDataType();
            _this.EBigInteger.Name = "EBigInteger";
            _this.EBigDecimal = f.EDataType();
            _this.EBigDecimal.Name = "EBigDecimal";
            _this.EResource = f.EDataType();
            _this.EResource.Name = "EResource";
            _this.EResourceSet = f.EDataType();
            _this.EResourceSet.Name = "EResourceSet";
            _this.EFeatureMap = f.EDataType();
            _this.EFeatureMap.Name = "EFeatureMap";
            _this.EFeatureMapEntry = f.EDataType();
            _this.EFeatureMapEntry.Name = "EFeatureMapEntry";
            _this.EEList = f.EDataType();
            _this.EEList.Name = "EEList";
            _this.EEnumerator = f.EDataType();
            _this.EEnumerator.Name = "EEnumerator";
            _this.ETreeIterator = f.EDataType();
            _this.ETreeIterator.Name = "ETreeIterator";
        }
    }
}
