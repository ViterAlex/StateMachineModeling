using System;
using System.ComponentModel;
using System.Globalization;

namespace AbstractMachineControl
{
    internal class MachineKindConverter : BooleanConverter
    {
        private const string MOORE = "Мура";
        private const string MEALY = "Мили";

        #region Overrides of TypeConverter

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            return (bool)value ? MOORE : MEALY;
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            return (string)value == MOORE;
        }

        #endregion
    }
}
