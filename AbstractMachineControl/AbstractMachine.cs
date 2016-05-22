using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace AbstractMachineControl
{
    public partial class AbstractMachine : UserControl, INotifyPropertyChanged
    {
        public AbstractMachine()
        {
            InitializeComponent();
            InputPrefix = "z";
            StatePrefix = "a";
            OutputPrefix = "ω";
            mealyRadioButton.Checked = true;
            PropertyChanged += AbstractMachine_PropertyChanged;
        }

        private void AbstractMachine_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            createButton.Enabled = InitialState != -1;
            saveToolStripButton.Enabled = transitDataGridView.RowCount > 0 && transitDataGridView.ColumnCount > 0;
        }

        /// <summary>
        /// Задание перехода для таблицы переходов
        /// </summary>
        /// <param name="input">Входной сигнал</param>
        /// <param name="state">Состояние</param>
        /// <param name="newState">Новое состояние</param>
        public void SetTransition(string input, string state, string newState)
        {
            DataGridViewRow row =
                transitDataGridView.Rows.Cast<DataGridViewRow>()
                                   .FirstOrDefault(r => r.HeaderCell.Value.ToString().Equals(input) && r.Index != -1);
            if (row != null)
            {
                row.Cells[state].Value = newState;
            }
        }
        /// <summary>
        /// Заднание выходного сигнала для таблицы выходов
        /// </summary>
        /// <param name="input">Входной сигнал</param>
        /// <param name="state">Состояние</param>
        /// <param name="output">Выходной сигнал</param>
        public void SetOutput(string input, string state, string output)
        {
            DataGridViewRow row =
                outputDataGridView.Rows.Cast<DataGridViewRow>()
                                   .FirstOrDefault(r => r.HeaderCell.Value.ToString().Equals(input) && r.Index != -1);
            if (row != null)
            {
                row.Cells[state].Value = output;
            }
        }
        /// <summary>
        /// Смена значения в одном из числовых полей
        /// </summary>
        private void NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            var upDown = sender as NumericUpDown;
            if (upDown == null) return;
            switch (upDown.Name)
            {
                case "statesNumericUpDown":
                    UpdateColumns((int)upDown.Value);
                    UpdateLists();
                    UpdateDataSources();
                    break;
                case "inputNumericUpDown":
                    UpdateRows((int)upDown.Value);
                    break;
                case "outputNumericUpDown":
                    UpdateLists();
                    UpdateDataSources();
                    break;
            }
            OnPropertyChanged();
        }
        /// <summary>
        /// Смена состояния флажка
        /// </summary>
        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            IsMoore = mooreRadioButton.Checked;
            ChangeMachineKind();
        }
        /// <summary>
        /// Кнопка "Сохранить"
        /// </summary>
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = Properties.Resources.dialogFilter;
                if (dialog.ShowDialog() != DialogResult.OK) return;
                SaveToFile(dialog.FileName);
            }
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = Properties.Resources.dialogFilter;
                if (dialog.ShowDialog() != DialogResult.OK) return;
                OpenFile(dialog.FileName);
            }
        }
        /// <summary>
        /// Кнопка "Создать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createButton_Click(object sender, EventArgs e)
        {
            CreateMachine(IsMoore);
        }
        /// <summary>
        /// Событие при ошибке в привязанных к ячейке данных
        /// </summary>
        private void DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            ((DataGridView)sender)[e.ColumnIndex, e.RowIndex].Value = null;
        }
        /// <summary>
        /// Двойной клик по заголовку столбца делает это состояние начальным
        /// </summary>
        private void transitDataGridView_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            InitialState = e.ColumnIndex;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
