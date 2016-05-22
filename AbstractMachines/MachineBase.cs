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
            //При переходе автомата из одного состояния в другое вызываем событие StateChanged
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
            //При переходе автомата из одного состояния в другое вызываем событие StateChanged
            //через виртуальный метод OnStateChanged
            OnTransitioned(t =>
            OnStateChanged(new StateChangedEventArgs(
                t.Trigger,
                t.Source,
                t.Destination,
                Outputs[new KeyValuePair<string, string>(t.Trigger, t.Source)])));
        }

        /// <summary>
        /// Создание перехода автомата в другое состояние
        /// </summary>
        /// <param name="fromState">Текущее состояние автомата</param>
        /// <param name="input">Входной сигнал</param>
        /// <param name="toState">Следующее состояние автомата</param>
        /// <param name="output">Выходной сигнал</param>
        /// <param name="isMoore"></param>
        public void AddTransition(string fromState, string input, string toState, string output, bool isMoore)
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
            //
            Outputs.Add(new KeyValuePair<string, string>(input, isMoore ? toState : fromState), output);
        }
        /// <summary>
        /// Словарь выходных сигналов. Ключ словаря — входной сигнал и текущее состояние для автомата Мили и новое состояние для автомата Мура. Значение словаря — новый выходной сигнал
        /// </summary>
        public Dictionary<KeyValuePair<string, string>, string> Outputs { get; set; }
        /// <summary>
        /// Словарь переходов. Ключ словаря — входной сигнал и текущее состояние автомата. Значение словаря — новое состояние автомата
        /// </summary>
        public Dictionary<KeyValuePair<string, string>, string> Transitions { get; set; }

        protected virtual void OnStateChanged(StateChangedEventArgs e)
        {
            EventHandler<StateChangedEventArgs> handler = StateChanged;
            if (handler != null) handler(this, e);
        }
    }
}
