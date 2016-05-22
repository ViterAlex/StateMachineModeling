using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;

namespace AbstractMachineControl
{
    /// <summary>
    /// Конвертер для отображения списка возможных состояний для исходного состояния в свойствах компонента
    /// </summary>
    internal class InitialStateConverter : StringConverter
    {
        //TODO:Не работает выбор состояний в виде строк
        #region Overrides of TypeConverter

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        }

        #region Overrides of BaseNumberConverter

        public override bool CanConvertTo(ITypeDescriptorContext context, Type t)
        {
            return t == typeof(int) || base.CanConvertTo(context, t);
        }

        #endregion

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            var am = context.Instance as AbstractMachine;
            Debug.WriteLine("value: {0}", value);
            if (am.States != null && am.States.Count > 0)
            {
                return am.States.IndexOf((string)value);
            }
                return "";
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType != typeof(string)) return -1;
            if (context == null) return "";
            var am = context.Instance as AbstractMachine;
            //if (am.States != null && am.States.Count > 0 && (int)value != -1)
            //{
            //    return am.States[(int)value];
            //}
            Debug.WriteLine("deistinationType: {0}\tvalue: {1}", destinationType.Name, value);
            return value;
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
