using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace AbstractMachines
{
    /// <summary>
    /// Базовый класс для создания конечных автоматов.
    /// </summary>
    public abstract class MachineBase : Stateless.StateMachine<string, string>
    {

        [Description("Событие при смене состояния автомата")]
        public event EventHandler<StateChangedEventArgs> StateChanged;
        protected MachineBase(Func<string> stateAccessor, Action<string> stateMutator)
            : base(stateAccessor, stateMutator)
        {
            //При переходе машины из одного состояния в другое вызываем событие StateChanged
            //через виртуальный метод OnStateChanged
            OnTransitioned(t =>
            OnStateChanged(new StateChangedEventArgs(
                t.Trigger,
                t.Source,
                t.Destination,
                Outputs[new KeyValuePair<string, string>(t.Trigger, t.Source)])));
        }

        protected MachineBase(string initialState)
            : base(initialState)
        {
            //При переходе машины из одного состояния в другое вызываем событие StateChanged
            //через виртуальный метод OnStateChanged
            OnTransitioned(t =>
            OnStateChanged(new StateChangedEventArgs(
                t.Trigger,
                t.Source,
                t.Destination,
                Outputs[new KeyValuePair<string, string>(t.Trigger, t.Source)])));
        }

        /// <summary>
        /// Метод создания логики работы машины на основе информации о переходах.
        /// </summary>
        public void Create()
        {
            foreach (KeyValuePair<KeyValuePair<string, string>, string> pair in Transitions)
            {
                //Добавление переходов в Stateless
                //Если начальное и конечное состояния совпадают.
                if (pair.Key.Value.Equals(pair.Value))
                    Configure(pair.Key.Value).Ignore(pair.Key.Key);
                else
                    Configure(pair.Key.Value).Permit(pair.Key.Key, pair.Value);
            }
        }
        /// <summary>
        /// Создание перехода машины в другое состояние
        /// </summary>
        /// <param name="fromState">Текущее состояние машины</param>
        /// <param name="input">Входной сигнал</param>
        /// <param name="toState">Следующее состояние машины</param>
        /// <param name="output">Выходной сигнал</param>
        public void AddTransition(string fromState, string input, string toState, string output)
        {
            if (Transitions == null)
            {
                Transitions = new Dictionary<KeyValuePair<string, string>, string>();
            }
            Transitions.Add(new KeyValuePair<string, string>(input, fromState), toState);
            Configure(fromState).Permit(input, toState);
            if (Outputs == null)
            {
                Outputs = new Dictionary<KeyValuePair<string, string>, string>();
            }
            Outputs.Add(new KeyValuePair<string, string>(input, fromState), output);
        }
        /// <summary>
        /// Словарь выходных сигналов. Ключ словаря — входной сигнал и текущее состояние машины. Значение словаря — новый выходной сигнал
        /// </summary>
        public Dictionary<KeyValuePair<string, string>, string> Outputs { get; set; }
        /// <summary>
        /// Словарь переходов. Ключ словаря — входной сигнал и текущее состояние машины. Значение словаря — новое состояние машины
        /// </summary>
        public Dictionary<KeyValuePair<string, string>, string> Transitions { get; set; }

        protected virtual void OnStateChanged(StateChangedEventArgs e)
        {
            EventHandler<StateChangedEventArgs> handler = StateChanged;
            if (handler != null) handler(this, e);
        }
    }
}
