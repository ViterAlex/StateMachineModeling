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

        #region Overrides of MachineBase

        public override void Create()
        {
            //Configure(State).
        }

        #endregion
    }
}
