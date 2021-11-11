using System.Drawing;

namespace ASE_assignment
{
    partial class mainWindow
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
            this.CommandLine = new System.Windows.Forms.TextBox();
            this.RunProgramButton = new System.Windows.Forms.Button();
            this.RunCommandButton = new System.Windows.Forms.Button();
            this.ProgramInput = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // CommandLine
            // 
            this.CommandLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CommandLine.Location = new System.Drawing.Point(12, 10);
            this.CommandLine.Name = "CommandLine";
            this.CommandLine.Size = new System.Drawing.Size(423, 22);
            this.CommandLine.TabIndex = 0;
            this.CommandLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CommandLine_KeyDown);
            // 
            // RunProgramButton
            // 
            this.RunProgramButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RunProgramButton.Location = new System.Drawing.Point(540, 8);
            this.RunProgramButton.Name = "RunProgramButton";
            this.RunProgramButton.Size = new System.Drawing.Size(82, 24);
            this.RunProgramButton.TabIndex = 1;
            this.RunProgramButton.Text = "Run Program";
            this.RunProgramButton.UseVisualStyleBackColor = true;
            this.RunProgramButton.Click += new System.EventHandler(this.RunProgramButton_Click);
            // 
            // RunCommandButton
            // 
            this.RunCommandButton.Location = new System.Drawing.Point(441, 8);
            this.RunCommandButton.Name = "RunCommandButton";
            this.RunCommandButton.Size = new System.Drawing.Size(93, 24);
            this.RunCommandButton.TabIndex = 3;
            this.RunCommandButton.Text = "Run Command";
            this.RunCommandButton.UseVisualStyleBackColor = true;
            this.RunCommandButton.Click += new System.EventHandler(this.RunCommandButton_Click);
            // 
            // ProgramInput
            // 
            this.ProgramInput.Location = new System.Drawing.Point(12, 38);
            this.ProgramInput.Multiline = true;
            this.ProgramInput.Name = "ProgramInput";
            this.ProgramInput.Size = new System.Drawing.Size(300, 300);
            this.ProgramInput.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(322, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 300);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // mainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(634, 351);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ProgramInput);
            this.Controls.Add(this.RunCommandButton);
            this.Controls.Add(this.RunProgramButton);
            this.Controls.Add(this.CommandLine);
            this.Name = "mainWindow";
            this.Text = "Turtle Draw";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox CommandLine;
        private System.Windows.Forms.Button RunProgramButton;
        private System.Windows.Forms.Button RunCommandButton;
        private System.Windows.Forms.TextBox ProgramInput;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

