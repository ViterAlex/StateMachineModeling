using System;
using AbstractMachines;

namespace AbstractMachineControl
{
    /// <summary>
    /// Аргументы события для абстрактной машины
    /// </summary>
    public class MachineEventArgs : EventArgs
    {
        /// <summary>
        /// Созданная машина
        /// </summary>
        public MachineBase Machine { get; private set; }
        /// <summary>
        /// Тип созданной машины
        /// </summary>
        public Type MachineType { get; private set; }

        public MachineEventArgs(MachineBase machine, Type machineType)
        {
            Machine = machine;
            MachineType = machineType;
        }
    }
}