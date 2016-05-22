using System.Linq;
using System.Threading;
using System.Windows.Forms;
using AbstractMachines;

namespace StateMachineModeling
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private MachineBase machine;
        private bool _stop;

        private void abstractMachine1_MachineCreated(object sender, AbstractMachineControl.MachineEventArgs e)
        {
            machine = e.Machine;
            machine.StateChanged += Machine_StateChanged;
            runMachine.Enabled = machine != null;
        }

        private void Machine_StateChanged(object sender, StateChangedEventArgs e)
        {
            richTextBox1.AppendText(string.Format("Переход из состояния {0} в {2} по сигналу {1}. Выходной сигнал {3}\r\n", e.OldState, e.Input, e.NewState, e.Output));
        }

        private void runMachine_Click(object sender, System.EventArgs e)
        {

            if (machine == null) return;
            stopMachineButton.Enabled = true;
            _stop = false;
            string prevState;
            do
            {
                if (_stop)
                {
                    break;
                }
                prevState = machine.State;
                if (machine.PermittedTriggers.Any())
                {
                    machine.Fire(machine.PermittedTriggers.FirstOrDefault());
                    Thread.Sleep(200);
                }
                Application.DoEvents();
            } while (!machine.State.Equals(prevState));
            stopMachineButton.Enabled = false;
        }

        private void stopMachineButton_Click(object sender, System.EventArgs e)
        {
            _stop = true;
        }
    }
}
