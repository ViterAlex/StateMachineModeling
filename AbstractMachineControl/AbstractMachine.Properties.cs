#region Header

// Файл создан 17.05.2016
// Александром Витером для AbstractMachineControl
// viter.alex@gmail.com
// Skype: viter.alex

#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace AbstractMachineControl
{
    public partial class AbstractMachine
    {
        private int _initialStateIndex;
        private string _initialStateString;
        /// <summary>
        ///     Список выходных сигналов
        /// </summary>
        private List<string> _outputs;

        /// <summary>
        ///     Событие возникающее после создания машины
        /// </summary>
        [Description("Событие возникающее после создания машины")] public EventHandler<MachineEventArgs> MachineCreated;

        /// <summary>
        ///     Список возможных состояний машины
        /// </summary>
        internal List<string> States;

        /// <summary>
        ///     Начальное состояние машины
        /// </summary>
        [TypeConverter(typeof (InitialStateConverter))]
        [Description("Устанавливает начальное состояние машины.")]
        [DisplayName("Начальное состояние")]
        public string InitialState
        {
            get { return States[_initialStateIndex==-1?0:_initialStateIndex]; }
            set
            {
                _initialStateString = value;
                _initialStateIndex = States.IndexOf(value);
                MarkInitialState();
            }
        }

        /// <summary>
        ///     Префикс для обозначения входных сигналов
        /// </summary>
        [Description("Префикс для обозначения входных сигналов")]
        public string InputPrefix
        {
            get { return inputLabel.Text.Substring(0, inputLabel.Text.Length - 1).ToLower(); }
            set
            {
                inputLabel.Text = $"{value.ToUpper()}:";
                UpdatePrefixes();
            }
        }

        /// <summary>
        ///     Префикс для обозначения состояний
        /// </summary>
        [Description("Префикс для обозначения состояний")]
        public string StatePrefix
        {
            get { return statesLabel.Text.Substring(0, statesLabel.Text.Length - 1).ToLower(); }
            set
            {
                statesLabel.Text = $"{value.ToUpper()}:";
                UpdatePrefixes();
            }
        }

        /// <summary>
        ///     Префикс для обозначения выходных сигналов
        /// </summary>
        [Description("Префикс для обозначения выходных сигналов")]
        public string OutputPrefix
        {
            get { return outputLabel.Text.Substring(0, outputLabel.Text.Length - 1).ToLower(); }
            set
            {
                outputLabel.Text = $"{value.ToUpper()}:";
                UpdatePrefixes();
            }
        }

        /// <summary>
        ///     Определяет тип создаваемого автомата. True — если автомат Мура.
        /// </summary>
        [Description("Определяет тип создаваемого автомата")]
        [DisplayName("Тип машины")]
        [TypeConverter(typeof (MachineKindConverter))]
        public bool IsMoore
        {
            get { return mooreRadioButton.Checked; }
            set
            {
                mooreRadioButton.Checked = value;
                mealyRadioButton.Checked = !value;
            }
        }

        /// <summary>
        ///     Количество состояний автомата
        /// </summary>
        [Description("Количество состояний автомата")]
        public int StatesCount
        {
            get { return (int) statesNumericUpDown.Value; }
            set { statesNumericUpDown.Value = value; }
        }

        /// <summary>
        ///     Количество входных сигналов
        /// </summary>
        [Description("Количество входных сигналов")]
        public int InputsCount
        {
            get { return (int) inputNumericUpDown.Value; }
            set { inputNumericUpDown.Value = value; }
        }

        /// <summary>
        ///     Количество выходных сигналов
        /// </summary>
        [Description("Количество выходных сигналов")]
        public int OutputsCount
        {
            get { return (int) outputNumericUpDown.Value; }
            set { outputNumericUpDown.Value = value; }
        }
    }
}