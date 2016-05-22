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
    [DefaultEvent("MachineCreated")]
    public partial class AbstractMachine
    {
        private int _initialState;
        /// <summary>
        ///     Список выходных сигналов
        /// </summary>
        private List<string> _outputs;
        /// <summary>
        /// Список входных сигналов
        /// </summary>
        private List<string> _inputs;
        /// <summary>
        ///     Событие возникающее после создания автомата
        /// </summary>
        [Description("Событие возникающее после создания автомата")]
        public event EventHandler<MachineEventArgs> MachineCreated;

        /// <summary>
        ///     Список возможных состояний автомата
        /// </summary>
        internal List<string> States;

        /// <summary>
        ///     Начальное состояние автомата
        /// </summary>
        [TypeConverter(typeof(InitialStateConverter))]
        [Description("Устанавливает начальное состояние автомата.")]
        [DisplayName("Начальное состояние")]
        [Category("Parameters")]
        public int InitialState
        {
            get { return _initialState; }
            set
            {
                MarkInitialState(_initialState, value);
                _initialState = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Префикс для обозначения входных сигналов
        /// </summary>
        [Description("Префикс для обозначения входных сигналов")]
        [Category("Parameters")]
        public string InputPrefix
        {
            get { return inputLabel.Text.Substring(0, inputLabel.Text.Length - 1).ToLower(); }
            set
            {
                inputLabel.Text = string.Format("{0}:", value.ToUpper());
                UpdatePrefixes();
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Префикс для обозначения состояний
        /// </summary>
        [Description("Префикс для обозначения состояний")]
        [Category("Parameters")]
        public string StatePrefix
        {
            get { return statesLabel.Text.Substring(0, statesLabel.Text.Length - 1).ToLower(); }
            set
            {
                statesLabel.Text = string.Format("{0}:", value.ToUpper());
                UpdatePrefixes();
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Префикс для обозначения выходных сигналов
        /// </summary>
        [Description("Префикс для обозначения выходных сигналов")]
        [Category("Parameters")]
        public string OutputPrefix
        {
            get { return outputLabel.Text.Substring(0, outputLabel.Text.Length - 1).ToLower(); }
            set
            {
                outputLabel.Text = string.Format("{0}:", value.ToUpper());
                UpdatePrefixes();
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Определяет тип создаваемого автомата. True — если автомат Мура.
        /// </summary>
        [Description("Определяет тип создаваемого автомата")]
        [DisplayName("Тип автомата")]
        [TypeConverter(typeof(MachineKindConverter))]
        [Category("Parameters")]
        public bool IsMoore
        {
            get { return mooreRadioButton.Checked; }
            set
            {
                mooreRadioButton.Checked = value;
                mealyRadioButton.Checked = !value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Количество состояний автомата
        /// </summary>
        [Description("Количество состояний автомата")]
        [Category("Parameters")]
        public int StatesCount
        {
            get { return (int)statesNumericUpDown.Value; }
            set
            {
                statesNumericUpDown.Value = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Количество входных сигналов
        /// </summary>
        [Description("Количество входных сигналов")]
        [Category("Parameters")]
        public int InputsCount
        {
            get { return (int)inputNumericUpDown.Value; }
            set
            {
                inputNumericUpDown.Value = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Количество выходных сигналов
        /// </summary>
        [Description("Количество выходных сигналов")]
        [Category("Parameters")]
        public int OutputsCount
        {
            get { return (int)outputNumericUpDown.Value; }
            set
            {
                outputNumericUpDown.Value = value;
                OnPropertyChanged();
            }
        }
    }
}