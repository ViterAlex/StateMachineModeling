using System;
using System.Windows.Forms;

namespace AbstractMachineControl
{
    public partial class AbstractMachine : UserControl
    {
        public AbstractMachine()
        {
            InitializeComponent();
            StatePrefix = "a";
            InputPrefix = "z";
            OutputPrefix = "ω";
            mealyRadioButton.Checked = true;
            UpdateColumns(StatesCount);
            UpdateRows(InputsCount);
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
                    break;
                case "inputNumericUpDown":
                    UpdateRows((int)upDown.Value);
                    break;
                case "outputNumericUpDown":
                    UpdateLists();
                    break;
            }
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
            ((DataGridView) sender)[e.ColumnIndex, e.RowIndex].Value = null;
        }
    }
}
