namespace AbstractMachineControl
{
    public partial class AbstractMachine
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AbstractMachine));
            this.statesNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.inputNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.mealyRadioButton = new System.Windows.Forms.RadioButton();
            this.mooreRadioButton = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.transitDataGridView = new System.Windows.Forms.DataGridView();
            this.outputDataGridView = new System.Windows.Forms.DataGridView();
            this.outputTableLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.createButton = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.outputNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.outputLabel = new System.Windows.Forms.Label();
            this.statesLabel = new System.Windows.Forms.Label();
            this.inputLabel = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.statesNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputNumericUpDown)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transitDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputDataGridView)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.outputNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // statesNumericUpDown
            // 
            this.statesNumericUpDown.Location = new System.Drawing.Point(26, 3);
            this.statesNumericUpDown.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.statesNumericUpDown.Name = "statesNumericUpDown";
            this.statesNumericUpDown.Size = new System.Drawing.Size(52, 20);
            this.statesNumericUpDown.TabIndex = 1;
            this.statesNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.statesNumericUpDown.ValueChanged += new System.EventHandler(this.NumericUpDown_ValueChanged);
            // 
            // inputNumericUpDown
            // 
            this.inputNumericUpDown.Location = new System.Drawing.Point(107, 3);
            this.inputNumericUpDown.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.inputNumericUpDown.Name = "inputNumericUpDown";
            this.inputNumericUpDown.Size = new System.Drawing.Size(52, 20);
            this.inputNumericUpDown.TabIndex = 2;
            this.inputNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.inputNumericUpDown.ValueChanged += new System.EventHandler(this.NumericUpDown_ValueChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(606, 292);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 2);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.mealyRadioButton, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.mooreRadioButton, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 28);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(600, 23);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // mealyRadioButton
            // 
            this.mealyRadioButton.AutoSize = true;
            this.mealyRadioButton.Location = new System.Drawing.Point(3, 3);
            this.mealyRadioButton.Name = "mealyRadioButton";
            this.mealyRadioButton.Size = new System.Drawing.Size(98, 17);
            this.mealyRadioButton.TabIndex = 0;
            this.mealyRadioButton.TabStop = true;
            this.mealyRadioButton.Text = "Автомат Мили";
            this.mealyRadioButton.UseVisualStyleBackColor = true;
            this.mealyRadioButton.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // mooreRadioButton
            // 
            this.mooreRadioButton.AutoSize = true;
            this.mooreRadioButton.Location = new System.Drawing.Point(303, 3);
            this.mooreRadioButton.Name = "mooreRadioButton";
            this.mooreRadioButton.Size = new System.Drawing.Size(97, 17);
            this.mooreRadioButton.TabIndex = 1;
            this.mooreRadioButton.TabStop = true;
            this.mooreRadioButton.Text = "Автомат Мура";
            this.mooreRadioButton.UseVisualStyleBackColor = true;
            this.mooreRadioButton.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel3, 2);
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.transitDataGridView, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.outputDataGridView, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.outputTableLabel, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 89);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(600, 200);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // transitDataGridView
            // 
            this.transitDataGridView.AllowUserToAddRows = false;
            this.transitDataGridView.AllowUserToResizeRows = false;
            this.transitDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.transitDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders;
            this.transitDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.transitDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transitDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.transitDataGridView.EnableHeadersVisualStyles = false;
            this.transitDataGridView.Location = new System.Drawing.Point(3, 16);
            this.transitDataGridView.Name = "transitDataGridView";
            this.transitDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.transitDataGridView.Size = new System.Drawing.Size(294, 181);
            this.transitDataGridView.TabIndex = 1;
            this.transitDataGridView.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.transitDataGridView_ColumnHeaderMouseDoubleClick);
            this.transitDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DataGridView_DataError);
            // 
            // outputDataGridView
            // 
            this.outputDataGridView.AllowUserToAddRows = false;
            this.outputDataGridView.AllowUserToResizeRows = false;
            this.outputDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.outputDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders;
            this.outputDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.outputDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.outputDataGridView.EnableHeadersVisualStyles = false;
            this.outputDataGridView.Location = new System.Drawing.Point(303, 16);
            this.outputDataGridView.Name = "outputDataGridView";
            this.outputDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.outputDataGridView.Size = new System.Drawing.Size(294, 181);
            this.outputDataGridView.TabIndex = 2;
            this.outputDataGridView.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.transitDataGridView_ColumnHeaderMouseDoubleClick);
            this.outputDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DataGridView_DataError);
            // 
            // outputTableLabel
            // 
            this.outputTableLabel.AutoSize = true;
            this.outputTableLabel.Location = new System.Drawing.Point(303, 0);
            this.outputTableLabel.Name = "outputTableLabel";
            this.outputTableLabel.Size = new System.Drawing.Size(96, 13);
            this.outputTableLabel.TabIndex = 5;
            this.outputTableLabel.Text = "Таблица выходов";
            this.outputTableLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Таблица переходов";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStrip1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.toolStrip1, 2);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripButton,
            this.saveToolStripButton,
            this.createButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(606, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openToolStripButton.Text = "&Открыть";
            this.openToolStripButton.ToolTipText = "Открыть файл с описанием автомата";
            this.openToolStripButton.Click += new System.EventHandler(this.openToolStripButton_Click);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "&Сохранить";
            this.saveToolStripButton.ToolTipText = "Сохранить данный автомат в файл";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // createButton
            // 
            this.createButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.createButton.Image = ((System.Drawing.Image)(resources.GetObject("createButton.Image")));
            this.createButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(54, 22);
            this.createButton.Text = "Создать";
            this.createButton.ToolTipText = "Создать автомат по указанным данным";
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel4.ColumnCount = 6;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel4, 2);
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.Controls.Add(this.outputNumericUpDown, 5, 0);
            this.tableLayoutPanel4.Controls.Add(this.outputLabel, 4, 0);
            this.tableLayoutPanel4.Controls.Add(this.statesLabel, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.inputNumericUpDown, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.inputLabel, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.statesNumericUpDown, 1, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 57);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(245, 26);
            this.tableLayoutPanel4.TabIndex = 6;
            this.toolTip1.SetToolTip(this.tableLayoutPanel4, "Алфавит состояний");
            // 
            // outputNumericUpDown
            // 
            this.outputNumericUpDown.Location = new System.Drawing.Point(190, 3);
            this.outputNumericUpDown.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.outputNumericUpDown.Name = "outputNumericUpDown";
            this.outputNumericUpDown.Size = new System.Drawing.Size(52, 20);
            this.outputNumericUpDown.TabIndex = 3;
            this.outputNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.outputNumericUpDown.ValueChanged += new System.EventHandler(this.NumericUpDown_ValueChanged);
            // 
            // outputLabel
            // 
            this.outputLabel.AutoSize = true;
            this.outputLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputLabel.Location = new System.Drawing.Point(165, 0);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(19, 26);
            this.outputLabel.TabIndex = 5;
            this.outputLabel.Text = "Ω:";
            this.outputLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.outputLabel, "Выходные сигналы");
            // 
            // statesLabel
            // 
            this.statesLabel.AutoSize = true;
            this.statesLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statesLabel.Location = new System.Drawing.Point(3, 0);
            this.statesLabel.Name = "statesLabel";
            this.statesLabel.Size = new System.Drawing.Size(17, 26);
            this.statesLabel.TabIndex = 3;
            this.statesLabel.Text = "A:";
            this.statesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.statesLabel, "Алфавит состояний");
            // 
            // inputLabel
            // 
            this.inputLabel.AutoSize = true;
            this.inputLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputLabel.Location = new System.Drawing.Point(84, 0);
            this.inputLabel.Name = "inputLabel";
            this.inputLabel.Size = new System.Drawing.Size(17, 26);
            this.inputLabel.TabIndex = 4;
            this.inputLabel.Text = "Z:";
            this.inputLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.inputLabel, "Входные сигналы");
            // 
            // AbstractMachine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AbstractMachine";
            this.Size = new System.Drawing.Size(606, 292);
            ((System.ComponentModel.ISupportInitialize)(this.statesNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputNumericUpDown)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transitDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputDataGridView)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.outputNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown statesNumericUpDown;
        private System.Windows.Forms.NumericUpDown inputNumericUpDown;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label outputLabel;
        private System.Windows.Forms.Label inputLabel;
        private System.Windows.Forms.Label statesLabel;
        private System.Windows.Forms.NumericUpDown outputNumericUpDown;
        private System.Windows.Forms.DataGridView transitDataGridView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.RadioButton mealyRadioButton;
        private System.Windows.Forms.RadioButton mooreRadioButton;
        private System.Windows.Forms.DataGridView outputDataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label outputTableLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton createButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
