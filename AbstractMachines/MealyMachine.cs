using System;
using System.Collections.Generic;

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
    }
}
