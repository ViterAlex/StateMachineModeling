using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AbstractMachines;

namespace AbstractMachineControl
{
    public partial class AbstractMachine
    {
        /// <summary>
        /// Обновление списков состояний и выходных сигналов
        /// </summary>
        private void UpdateLists()
        {
            States = Enumerable.Range(1, StatesCount).Select(n => string.Format("{0}{1}", StatePrefix, n)).ToList();
            _inputs = Enumerable.Range(1, InputsCount).Select(n => string.Format("{0}{1}", InputPrefix, n)).ToList();
            _outputs = Enumerable.Range(1, OutputsCount).Select(n => string.Format("{0}{1}", OutputPrefix, n)).ToList();
            _initialState = _initialState > States.Count - 1 ? -1 : _initialState;
        }
        /// <summary>
        /// Сохранение в файл
        /// </summary>
        /// <param name="fileName">Путь к файлу</param>
        private void SaveToFile(string fileName)
        {
            MachineDescription machineDescription = CreateMachineDescription();
            MachineDescription.Serialize(fileName, machineDescription);
        }
        /// <summary>
        /// Создание описания конечного автомата на основе таблиц переходов и выходов
        /// </summary>
        private MachineDescription CreateMachineDescription()
        {
            var md = new MachineDescription(InputsCount, StatesCount, OutputsCount, InitialState, IsMoore)
            {
                InputPrefix = InputPrefix,
                OutputPrefix = OutputPrefix,
                StatePrefix = StatePrefix
            };
            foreach (DataGridViewRow row in transitDataGridView.Rows)
            {
                for (int i = 0, n = row.Cells.Count; i < n; i++)
                {
                    if (row.Cells[i].Value == null) continue; ;
                    md.Transitions.Add(new Transition(
                        row.HeaderCell.Value.ToString(),
                        transitDataGridView.Columns[i].HeaderText,
                        row.Cells[i].Value.ToString()));
                }
            }

            foreach (DataGridViewRow row in outputDataGridView.Rows)
            {
                if (!row.Visible) continue;
                for (int i = 0, n = row.Cells.Count; i < n; i++)
                {
                    if (row.Cells[i].Value == null) continue;
                    md.Outputs.Add(new Output(
                        row.HeaderCell.Value.ToString(),
                        outputDataGridView.Columns[i].HeaderText,
                        row.Cells[i].Value.ToString()));
                }
            }
            return md;
        }

        /// <summary>
        /// Открытие файла с описанием машины
        /// </summary>
        /// <param name="fileName">Путь к файлу</param>
        private void OpenFile(string fileName)
        {
            MachineDescription md = MachineDescription.Deserialize(fileName);
            if (md == null) return;
            StatesCount = md.StatesCount;
            InputsCount = md.InputsCount;
            OutputsCount = OutputsCount;
            InputPrefix = md.InputPrefix;
            OutputPrefix = md.OutputPrefix;
            StatePrefix = md.StatePrefix;
            InitialState = md.InitialState;
            IsMoore = md.IsMoore;
            Clear();
            UpdateLists();
            UpdateColumns(StatesCount);
            UpdatePrefixes();
            MarkInitialState(-1, InitialState);
            foreach (Transition transition in md.Transitions)
            {
                SetTransition(transition.Input, transition.OldState, transition.NewState);
            }
            foreach (Output output in md.Outputs)
            {
                SetOutput(output.Input, output.State, output.OutputSignal);
            }
        }
        /// <summary>
        /// Очистка таблиц
        /// </summary>
        private void Clear()
        {
            transitDataGridView.Rows.Clear();
            transitDataGridView.Columns.Clear();
            outputDataGridView.Rows.Clear();
            outputDataGridView.Columns.Clear();
        }

        /// <summary>
        /// Обновление количества строк в таблицах
        /// </summary>
        /// <param name="value">Требуемое количество строк</param>
        private void UpdateRows(int value)
        {
            if (value == transitDataGridView.RowCount) return;
            if (transitDataGridView.ColumnCount == 0 && outputDataGridView.ColumnCount == 0) return;
            if (transitDataGridView.Rows.Count > value)
            {
                //Удаление строк
                while (transitDataGridView.RowCount > value)
                {
                    transitDataGridView.Rows.RemoveAt(transitDataGridView.RowCount - 1);
                    outputDataGridView.Rows.RemoveAt(outputDataGridView.RowCount - 1);
                }
            }
            else
            {
                //Добавление строк
                for (int i = 0, n = value - transitDataGridView.RowCount; i < n; i++)
                {
                    var index = transitDataGridView.Rows.Add();
                    outputDataGridView.Rows.Add();
                    transitDataGridView.Rows[index].HeaderCell.Value = string.Format("{0}{1}", InputPrefix, index + 1);
                    outputDataGridView.Rows[index].HeaderCell.Value = string.Format("{0}{1}", InputPrefix, index + 1);
                }
            }
            ChangeMachineKind();
        }
        /// <summary>
        /// Обновление количества столбцов в таблицах
        /// </summary>
        /// <param name="value">Требуемое количество столбцов</param>
        private void UpdateColumns(int value)
        {
            if (value == transitDataGridView.ColumnCount) return;

            //Удаление столбцов
            if (transitDataGridView.ColumnCount > value)
            {
                while (transitDataGridView.ColumnCount > value)
                {
                    transitDataGridView.Columns.RemoveAt(transitDataGridView.ColumnCount - 1);
                    outputDataGridView.Columns.RemoveAt(outputDataGridView.ColumnCount - 1);
                }
            }
            else
            {
                //Добавление столбцов
                for (int i = 0, n = value - transitDataGridView.ColumnCount; i < n; i++)
                {
                    //в таблицу переходов
                    var column = new DataGridViewComboBoxColumn
                    {
                        Name = string.Format("{0}{1}", StatePrefix, transitDataGridView.ColumnCount + 1),
                        HeaderText = string.Format("{0}{1}", StatePrefix, transitDataGridView.ColumnCount + 1),
                        DataSource = States
                    };
                    transitDataGridView.Columns.Add(column);
                    //в таблицу выходов
                    var column1 = new DataGridViewComboBoxColumn
                    {
                        Name = string.Format("{0}{1}", StatePrefix, outputDataGridView.ColumnCount + 1),
                        HeaderText = string.Format("{0}{1}", StatePrefix, outputDataGridView.ColumnCount + 1),
                        DataSource = _outputs
                    };
                    outputDataGridView.Columns.Add(column1);
                }
            }
            UpdateRows(InputsCount);
        }
        /// <summary>
        /// Обновление префиксов
        /// </summary>
        private void UpdatePrefixes()
        {
            foreach (DataGridViewRow row in transitDataGridView.Rows)
                row.HeaderCell.Value = string.Format("{0}{1}", InputPrefix, row.Index + 1);
            ChangeMachineKind();
            foreach (DataGridViewColumn column in transitDataGridView.Columns)
            {
                column.HeaderText = string.Format("{0}{1}", StatePrefix, column.Index + 1);
                column.Name = column.HeaderText;
            }
            foreach (DataGridViewColumn column in outputDataGridView.Columns)
            {
                column.HeaderText = string.Format("{0}{1}", StatePrefix, column.Index + 1);
                column.Name = column.HeaderText;
            }
            UpdateLists();
        }
        /// <summary>
        /// Выделение столбца с начальным состоянием
        /// </summary>
        private void MarkInitialState(int oldIndex, int newIndex)
        {
            if (transitDataGridView.ColumnCount == 0 || outputDataGridView.ColumnCount == 0) return;
            if (oldIndex == -1 && newIndex != -1)
            {
                transitDataGridView.Columns[newIndex].HeaderCell.Style.BackColor = Color.Orange;
                outputDataGridView.Columns[newIndex].HeaderCell.Style.BackColor = Color.Orange;
            }
            else if (oldIndex != -1 && newIndex == -1)
            {
                transitDataGridView.Columns[oldIndex].HeaderCell.Style.BackColor = SystemColors.Control;
                outputDataGridView.Columns[oldIndex].HeaderCell.Style.BackColor = SystemColors.Control;
            }
            else if (oldIndex != -1 && newIndex != -1)
            {
                transitDataGridView.Columns[oldIndex].HeaderCell.Style.BackColor = SystemColors.Control;
                transitDataGridView.Columns[newIndex].HeaderCell.Style.BackColor = Color.Orange;
                outputDataGridView.Columns[oldIndex].HeaderCell.Style.BackColor = SystemColors.Control;
                outputDataGridView.Columns[newIndex].HeaderCell.Style.BackColor = Color.Orange;
            }
        }
        //TODO:Создание машины
        private void CreateMachine(bool isMoore)
        {
            MachineBase mb;
            if (isMoore)
            {
                mb = new MooreMachine(States[InitialState]);
            }
            else
            {
                mb = new MealyMachine(States[InitialState]);
            }
            //Создание описания машины из таблиц
            MachineDescription md = CreateMachineDescription();
            foreach (Transition transition in md.Transitions)
            {
                //TODO:Уточнить соответствие состояний и выходных сигналов. От чего зависит выходной сигнал: от предыдущего или от следующего состояния.
                Output output = md.Outputs.FirstOrDefault(o => (isMoore || o.Input.Equals(transition.Input)) && o.State.Equals(transition.OldState));
                //Описание выходного состояния для данного перехода
                if (output != null)
                {
                    mb.AddTransition(transition.OldState,transition.Input,  transition.NewState, output.OutputSignal);
                }
            }
            if (MachineCreated != null) MachineCreated.Invoke(this, new MachineEventArgs(mb, mb.GetType()));
        }
        /// <summary>
        /// Смена типа машины. Скрываются строки, ненужные для автомата Мура
        /// </summary>
        private void ChangeMachineKind()
        {
            if (outputDataGridView.RowCount == 0) return;
            for (var i = outputDataGridView.RowCount - 1; i > 0; i--)
            {
                outputDataGridView.Rows[i].Visible = !IsMoore;
            }
            outputDataGridView.Rows[0].HeaderCell.Value = IsMoore ? "" : string.Format("{0}1", InputPrefix);
        }
        /// <summary>
        /// Обновление списков в таблице переходов и выходов
        /// </summary>
        private void UpdateDataSources()
        {
            transitDataGridView.Columns.OfType<DataGridViewComboBoxColumn>().ToList().ForEach(c => c.DataSource = States);
            outputDataGridView.Columns.OfType<DataGridViewComboBoxColumn>().ToList().ForEach(c => c.DataSource = _outputs);
        }
    }
}
