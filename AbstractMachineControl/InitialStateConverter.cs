using System;
using System.ComponentModel;
using System.Globalization;

namespace AbstractMachineControl
{
    /// <summary>
    /// Конвертер для отображения списка для выбора исходного состояния в свойствах компонента
    /// </summary>
    internal class InitialStateConverter : Int32Converter
    {
        #region Overrides of TypeConverter

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type t)
        {
            return t == typeof(int) || base.CanConvertTo(context, t);
        }

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        /// <summary>
        /// Преобразование из строки в число
        /// </summary>
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            var am = context.Instance as AbstractMachine;
            if (am != null && (am.States != null && am.States.Count > 0))
            {
                return am.States.IndexOf((string)value);
            }
            return -1;
        }
        /// <summary>
        /// Преобразование из числа в строку
        /// </summary>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (value is int && value.Equals(-1)) return "";
            if (context.Instance == null) return "";
            var am = context.Instance as AbstractMachine;
            if (am != null && ( am.States != null && am.States.Count > 0 && value is int))
            {
                return am.States[(int)value];
            }
            return value;
        }
        
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            //Возвращаем доступный список возможных состояний автомата
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
