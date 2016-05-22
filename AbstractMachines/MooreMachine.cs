using System;

namespace AbstractMachines
{
    public class MooreMachine : MachineBase
    {
        public MooreMachine(Func<string> stateAccessor, Action<string> stateMutator)
            : base(stateAccessor, stateMutator)
        {
        }

        public MooreMachine(string initialState)
            : base(initialState)
        {
        }
        
    }
}
