using System;

namespace AbstractMachines
{
    public class MealyMachine : MachineBase
    {
        public MealyMachine(Func<string> stateAccessor, Action<string> stateMutator)
            : base(stateAccessor, stateMutator)
        {
        }

        public MealyMachine(string initialState)
            : base(initialState)
        {
        }

        #region Overrides of MachineBase

        public override void Create()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
