using System;
using System.ComponentModel;
using System.Diagnostics;

namespace AbstractMachineControl
{
    internal class InitialStateConverter : StringConverter
    {
        #region Overrides of TypeConverter

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        }
        
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            var m = context.Instance as AbstractMachine;
            
            if (m != null) return new StandardValuesCollection(m.States);
            Debug.WriteLine($"{nameof(m)} is null.");
            return null;
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }

        #endregion
    }
}
