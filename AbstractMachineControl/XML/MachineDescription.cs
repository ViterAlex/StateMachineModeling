using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;

namespace AbstractMachineControl
{

    /// <summary>
    /// Класс для сериализации конечного автомата
    /// </summary>
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class MachineDescription
    {
        /// <summary>
        /// Коллекция описаний переходов
        /// </summary>
        [XmlArrayItem("Transition", IsNullable = false)]
        public List<Transition> Transitions { get; set; }

        /// <summary>
        /// Коллекция описаний выходов
        /// </summary>
        [XmlArrayItem("OutputSignal", IsNullable = false)]
        public List<Output> Outputs { get; set; }

        /// <summary>
        /// Количество входных сигналов
        /// </summary>
        [XmlAttribute()]
        public int InputsCount { get; set; }

        /// <summary>
        /// Количество состояний
        /// </summary>
        [XmlAttribute()]
        public int StatesCount { get; set; }

        /// <summary>
        /// Количество выходов
        /// </summary>
        [XmlAttribute()]
        public int OutputsCount { get; set; }

        /// <summary>
        /// Начальное состояние
        /// </summary>
        [XmlAttribute()]
        public int InitialState { get; set; }

        /// <summary>
        /// Префикс для обозначения входных сигналов
        /// </summary>
        [XmlAttribute()]
        public string InputPrefix { get; set; }

        /// <summary>
        /// Префикс для обозначения выходных сигналов
        /// </summary>
        [XmlAttribute()]
        public string OutputPrefix { get; set; }

        /// <summary>
        /// Префикс для обозначения состояний
        /// </summary>
        [XmlAttribute()]
        public string StatePrefix { get; set; }

        /// <summary>
        /// Автомат Мура или Мили
        /// </summary>
        [XmlAttribute()]
        public bool IsMoore { get; set; }

        public MachineDescription()
        {
            
        }
        /// <summary>
        /// Создание нового описания
        /// </summary>
        /// <param name="inputsCount">Количество входных сигналов</param>
        /// <param name="statesCount">Количество состояний</param>
        /// <param name="outputsCount">Количество выходных сигналов</param>
        /// <param name="initialState">Начальное состояние</param>
        /// <param name="isMoore">Автомат Мура или Мили</param>
        public MachineDescription(int inputsCount, int statesCount, int outputsCount, int initialState, bool isMoore)
        {
            InputsCount = inputsCount;
            StatesCount = statesCount;
            OutputsCount = outputsCount;
            InitialState = initialState;
            IsMoore = isMoore;
            Transitions = new List<Transition>();
            Outputs = new List<Output>();
        }
        /// <summary>
        /// Сериализация описания конечного автомата
        /// </summary>
        /// <param name="fileName">Имя файла</param>
        /// <param name="machineDescription">Описание конечного автомата</param>
        public static void Serialize(string fileName, MachineDescription machineDescription)
        {
            using (var reader = new StreamWriter(fileName))
            {
                var serializer = new XmlSerializer(machineDescription.GetType());
                try
                {
                    serializer.Serialize(reader, machineDescription);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Ошибка сериализации:\n{0}", ex.InnerException);
                }
            }
        }
        /// <summary>
        /// Десериализация файла в описание автомата.
        /// </summary>
        /// <param name="fileName">Имя файла</param>
        public static MachineDescription Deserialize(string fileName)
        {
            MachineDescription machineDescription = null;
            using (var reader = new StreamReader(fileName))
            {
                var serializer = new XmlSerializer(typeof(MachineDescription));
                try
                {
                    machineDescription = (MachineDescription)serializer.Deserialize(reader);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Ошибка десериализации:\n{0}", ex.InnerException);
                }
            }
            return machineDescription;
        }
    }
}
