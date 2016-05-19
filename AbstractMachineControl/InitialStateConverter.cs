using System;
using System.ComponentModel;
using System.Diagnostics;

namespace AbstractMachineControl
{
    /// <summary>
    /// Конвертер для отображения списка возможных состояний для исходного состояния в свойствах компонента
    /// </summary>
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
            
            return m != null ? new StandardValuesCollection(m.States) : null;
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }

        #endregion
    }
}
