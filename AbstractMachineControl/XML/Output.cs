using System.Xml.Serialization;

namespace AbstractMachineControl
{
    /// <summary>
    /// Класс описания выходов конечного автомата
    /// </summary>
    [XmlType(AnonymousType = true)]
    public class Output
    {
        /// <summary>
        /// Входной сигнал
        /// </summary>
        [XmlAttribute()]
        public string Input { get; set; }

        /// <summary>
        /// Состояние
        /// </summary>
        [XmlAttribute()]
        public string State { get; set; }

        /// <summary>
        /// Выходной сигнал
        /// </summary>
        [XmlAttribute("Output")]
        public string OutputSignal { get; set; }

        public Output()
        {
            
        }
        public Output(string input, string state, string outputSignal)
        {
            Input = input;
            State = state;
            OutputSignal = outputSignal;
        }
    }
}