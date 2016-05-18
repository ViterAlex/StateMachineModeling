using System;
using System.Collections.Generic;

namespace AbstractMachines
{
    public abstract class MachineBase : Stateless.StateMachine<String, string>
    {
        protected MachineBase(Func<string> stateAccessor, Action<string> stateMutator)
            : base(stateAccessor, stateMutator)
        {
        }

        protected MachineBase(string initialState)
            : base(initialState)
        {
        }
        /// <summary>
        /// Метод создания логики работы машины на основе информации о переходах.
        /// <para>Каждый класс реализует этот метод по-своему.</para>
        /// </summary>
        public abstract void Create();
        /// <summary>
        /// Создание перехода машины в другое состояние
        /// </summary>
        /// <param name="fromState">Текущее состояние машины</param>
        /// <param name="input">Входной сигнал</param>
        /// <param name="toState">Следующее состояние машины</param>
        /// <param name="output">Выходной сигнал</param>
        public void AddTransition(string fromState, string input, string toState, string output)
        {
            Transitions.Add(new KeyValuePair<string, string>(input, fromState), toState);
            Outputs.Add(new KeyValuePair<string, string>(input, fromState), output);
        }
        /// <summary>
        /// Словарь выходных сигналов. Ключ словаря — входной сигнал и текущее состояние машины. Значение словаря — новый выходной сигнал
        /// </summary>
        public Dictionary<KeyValuePair<string, string>, string> Outputs { get; set; } = new Dictionary<KeyValuePair<string, string>, string>();
        /// <summary>
        /// Словарь переходов. Ключ словаря — входной сигнал и текущее состояние машины. Значение словаря — новое состояние машины
        /// </summary>
        public Dictionary<KeyValuePair<string, string>, string> Transitions { get; set; } = new Dictionary<KeyValuePair<string, string>, string>();
    }
}
