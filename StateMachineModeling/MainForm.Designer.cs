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
            this.SuspendLayout();
            // 
            // abstractMachine1
            // 
            this.abstractMachine1.AutoSize = true;
            this.abstractMachine1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.abstractMachine1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.abstractMachine1.InitialState = "a2";
            this.abstractMachine1.InputPrefix = "z";
            this.abstractMachine1.InputsCount = 3;
            this.abstractMachine1.IsMoore = true;
            this.abstractMachine1.Location = new System.Drawing.Point(0, 0);
            this.abstractMachine1.Name = "abstractMachine1";
            this.abstractMachine1.OutputPrefix = "ω";
            this.abstractMachine1.OutputsCount = 3;
            this.abstractMachine1.Size = new System.Drawing.Size(625, 247);
            this.abstractMachine1.StatePrefix = "a";
            this.abstractMachine1.StatesCount = 5;
            this.abstractMachine1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 247);
            this.Controls.Add(this.abstractMachine1);
            this.Name = "MainForm";
            this.Text = "Моделирование конечного автомата";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AbstractMachineControl.AbstractMachine abstractMachine1;
    }
}

