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
            States = transitDataGridView.Columns.OfType<DataGridViewColumn>().Select(c => $"{StatePrefix}{c.Index + 1}").ToList();
            _outputs = Enumerable.Range(1, OutputsCount).Select(n => $"{OutputPrefix}{n}").ToList();
            transitDataGridView.Columns.OfType<DataGridViewComboBoxColumn>().ToList().ForEach(c => c.DataSource = States);
            outputDataGridView.Columns.OfType<DataGridViewComboBoxColumn>().ToList().ForEach(c => c.DataSource = _outputs);
            InitialState = _initialStateString;
        }
        /// <summary>
        /// Сохранение в файл
        /// </summary>
        /// <param name="fileName">Путь к файлу</param>
        private void SaveToFile(string fileName)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("{0}\n", IsMoore ? 1 : 0);
            sb.AppendFormat("StatesCount: {0}\n", StatesCount);
            sb.AppendFormat("InputsCount: {0}\n", InputsCount);
            sb.AppendFormat("OutputCouns: {0}\n", OutputsCount);
            foreach (DataGridViewRow row in transitDataGridView.Rows)
            {
                sb.AppendFormat("{0}:", row.HeaderCell.Value);
                for (int i = 0, n = row.Cells.Count; i < n; i++)
                {
                    sb.AppendFormat("{0};{1}{2}",
                        transitDataGridView.Columns[i].HeaderText,
                        row.Cells[i].Value,
                        i == 0 || i == n - 1 ? "" : ";");
                }
                sb.AppendLine();
            }
            if (!IsMoore)
            {
                foreach (DataGridViewRow row in outputDataGridView.Rows)
                {
                    sb.AppendFormat("{0}:", row.HeaderCell.Value);
                    for (int i = 0, n = row.Cells.Count; i < n; i++)
                    {
                        sb.AppendFormat("{0};{1}{2}",
                            outputDataGridView.Columns[i].HeaderText,
                            row.Cells[i].Value,
                            i == 0 || i == n - 1 ? "" : ";");
                    }
                    sb.AppendLine();
                }
            }
            File.WriteAllText(fileName, sb.ToString());
        }
        /// <summary>
        /// Открытие файла с описанием машины
        /// </summary>
        /// <param name="fileName">Путь к файлу</param>
        private void OpenFile(string fileName)
        {
            var strings = File.ReadAllLines(fileName);
            //TODO:Импорт файла в таблицы
        }
        /// <summary>
        /// Обновление количества строк в таблицах
        /// </summary>
        /// <param name="value">Требуемое количество строк</param>
        private void UpdateRows(int value)
        {
            if (value == transitDataGridView.RowCount) return;
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
                    transitDataGridView.Rows[index].HeaderCell.Value = $"{InputPrefix}{index + 1}";
                    outputDataGridView.Rows[index].HeaderCell.Value = $"{InputPrefix}{index + 1}";
                }
            }
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
                    var column = new DataGridViewComboBoxColumn
                    {
                        Name = $"{StatePrefix}{transitDataGridView.ColumnCount}",
                        HeaderText = $"{StatePrefix}{transitDataGridView.ColumnCount + 1}"
                    };
                    transitDataGridView.Columns.Add(column);
                    var column1 = new DataGridViewComboBoxColumn
                    {
                        Name = $"{StatePrefix}{outputDataGridView.ColumnCount}",
                        HeaderText = $"{StatePrefix}{outputDataGridView.ColumnCount + 1}"
                    };
                    outputDataGridView.Columns.Add(column1);
                }
            }
            UpdateLists();
            MarkInitialState();
        }
        /// <summary>
        /// Обновление префиксов
        /// </summary>
        private void UpdatePrefixes()
        {
            foreach (DataGridViewRow row in transitDataGridView.Rows)
                row.HeaderCell.Value = $"{InputPrefix}{row.Index + 1}";
            foreach (DataGridViewRow row in outputDataGridView.Rows)
                row.HeaderCell.Value = $"{InputPrefix}{row.Index + 1}";
            foreach (DataGridViewColumn column in transitDataGridView.Columns)
                column.HeaderText = $"{StatePrefix}{column.Index + 1}";
            foreach (DataGridViewColumn column in outputDataGridView.Columns)
                column.HeaderText = $"{StatePrefix}{column.Index + 1}";
            UpdateLists();
        }
        /// <summary>
        /// Выделение столбца с начальным состоянием
        /// </summary>
        private void MarkInitialState()
        {
            foreach (DataGridViewColumn column in transitDataGridView.Columns)
            {
                column.HeaderCell.Style.BackColor = column.Index == _initialStateIndex
                    ? Color.Orange
                    : SystemColors.Control;
            }
            foreach (DataGridViewColumn column in outputDataGridView.Columns)
            {
                column.HeaderCell.Style.BackColor = column.Index == _initialStateIndex
                    ? Color.Orange
                    : SystemColors.Control;
            }
        }
        //TODO:Создание машины
        private void CreateMachine(bool isMoore)
        {
            MachineBase mb;
            if (isMoore)
            {
                mb = new MooreMachine(InitialState);
            }
            else
            {
                mb = new MealyMachine(InitialState);
            }
            //Перебор строк в таблице переходов
            foreach (DataGridViewRow row in transitDataGridView.Rows)
            {
                //Перебор ячеек в каждой строке
                foreach (DataGridViewComboBoxCell cell in row.Cells)
                {
                    //Если ячейка пустая, то такого перехода не существует.
                    if (cell.Value == null) continue;
                    //Строка текущего состояния
                    var from = transitDataGridView.Columns[cell.ColumnIndex].HeaderText;
                    //Строка входного сигнала
                    var input = row.HeaderCell.Value.ToString();
                    //Строка нового состояния
                    var to = cell.Value.ToString();
                    //Индекс строки из которой берём выходной сигнал.
                    //Для Мура это 0 строка, для Мили — соответствующая
                    var index = isMoore ? 0 : cell.RowIndex;
                    //Строка выходного сигнала
                    var output = outputDataGridView[cell.ColumnIndex, index].Value.ToString();
                    mb.AddTransition(from, input, to, output);
                }
            }
            MachineCreated?.Invoke(this, new MachineEventArgs(mb, mb.GetType()));
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
            outputDataGridView.Rows[0].HeaderCell.Value = IsMoore ? "" : $"{InputPrefix}1";
        }
    }
}
