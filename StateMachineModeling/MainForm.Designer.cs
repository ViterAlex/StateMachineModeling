namespace StateMachineModeling
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.abstractMachine1 = new AbstractMachineControl.AbstractMachine();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.runMachine = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.stopMachineButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // abstractMachine1
            // 
            this.abstractMachine1.AutoSize = true;
            this.abstractMachine1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.abstractMachine1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.abstractMachine1.InitialState = -1;
            this.abstractMachine1.InputPrefix = "z";
            this.abstractMachine1.InputsCount = 2;
            this.abstractMachine1.IsMoore = true;
            this.abstractMachine1.Location = new System.Drawing.Point(3, 16);
            this.abstractMachine1.Name = "abstractMachine1";
            this.abstractMachine1.OutputPrefix = "ω";
            this.abstractMachine1.OutputsCount = 2;
            this.abstractMachine1.Size = new System.Drawing.Size(587, 422);
            this.abstractMachine1.StatePrefix = "a";
            this.abstractMachine1.StatesCount = 3;
            this.abstractMachine1.TabIndex = 0;
            this.abstractMachine1.MachineCreated += new System.EventHandler<AbstractMachineControl.MachineEventArgs>(this.abstractMachine1_MachineCreated);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(602, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.tableLayoutPanel1.SetRowSpan(this.richTextBox1, 2);
            this.richTextBox1.Size = new System.Drawing.Size(593, 470);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // groupBox1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox1, 2);
            this.groupBox1.Controls.Add(this.abstractMachine1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(593, 441);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры автомата";
            // 
            // runMachine
            // 
            this.runMachine.AutoSize = true;
            this.runMachine.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.runMachine.Enabled = false;
            this.runMachine.Location = new System.Drawing.Point(3, 3);
            this.runMachine.Name = "runMachine";
            this.runMachine.Size = new System.Drawing.Size(114, 23);
            this.runMachine.TabIndex = 3;
            this.runMachine.Text = "Запустить автомат";
            this.runMachine.UseVisualStyleBackColor = true;
            this.runMachine.Click += new System.EventHandler(this.runMachine_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.richTextBox1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.runMachine, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.stopMachineButton, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1198, 476);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // stopMachineButton
            // 
            this.stopMachineButton.AutoSize = true;
            this.stopMachineButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.stopMachineButton.Enabled = false;
            this.stopMachineButton.Location = new System.Drawing.Point(123, 3);
            this.stopMachineButton.Name = "stopMachineButton";
            this.stopMachineButton.Size = new System.Drawing.Size(77, 23);
            this.stopMachineButton.TabIndex = 3;
            this.stopMachineButton.Text = "Остановить";
            this.stopMachineButton.UseVisualStyleBackColor = true;
            this.stopMachineButton.Click += new System.EventHandler(this.stopMachineButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 476);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainForm";
            this.Text = "Моделирование конечного автомата";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private AbstractMachineControl.AbstractMachine abstractMachine1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button runMachine;
        private System.Windows.Forms.Button stopMachineButton;
    }
}

