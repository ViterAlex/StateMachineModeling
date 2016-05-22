using System;
using AbstractMachines;

namespace AbstractMachineControl
{
    /// <summary>
    /// Аргументы события для абстрактной автомата
    /// </summary>
    public class MachineEventArgs : EventArgs
    {
        /// <summary>
        /// Созданный автомат
        /// </summary>
        public MachineBase Machine { get; private set; }
        /// <summary>
        /// Тип созданной автомата
        /// </summary>
        public Type MachineType { get; private set; }

        public MachineEventArgs(MachineBase machine, Type machineType)
        {
            Machine = machine;
            MachineType = machineType;
        }
    }
}