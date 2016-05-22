using System;
using System.ComponentModel;

namespace AbstractMachines
{
    /// <summary>
    /// Класс, описывающий смену состояния конечного автомата.
    /// </summary>
    public class StateChangedEventArgs:EventArgs
    {
        public string Input { get; set; }
        public string OldState { get; set; }
        public string NewState { get; set; }
        public string Output { get; set; }
        public StateChangedEventArgs(string input, string oldState, string newState, string output)
        {
            Input = input;
            OldState = oldState;
            NewState = newState;
            Output = output;
        }
    }
}