using System.Xml.Serialization;

namespace AbstractMachineControl
{
    /// <summary>
    /// Класс для описания перехода конечного автомата
    /// </summary>
    [XmlType(AnonymousType = true)]
    public class Transition
    {
        /// <summary>
        /// Входной сигнал
        /// </summary>
        [XmlAttribute()]
        public string Input { get; set; }

        /// <summary>
        /// Предыдущее состояние
        /// </summary>
        [XmlAttribute()]
        public string OldState { get; set; }

        /// <summary>
        /// Новое состояние
        /// </summary>
        [XmlAttribute()]
        public string NewState { get; set; }

        public Transition()
        {
            
        }
        /// <summary>
        /// Создание нового описания перехода
        /// </summary>
        /// <param name="input">Входящий сигнал</param>
        /// <param name="oldState">Предыдущее состояние</param>
        /// <param name="newState">Новое состояние</param>
        public Transition(string input, string oldState, string newState)
        {
            Input = input;
            OldState = oldState;
            NewState = newState;
        }
    }
}