namespace Vektorel.Tpl.FormApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnCancel = new Button();
            btnWait = new Button();
            btnFill = new Button();
            txtNum1 = new TextBox();
            txtNum2 = new TextBox();
            txtSum = new TextBox();
            lstNumbers = new ListBox();
            btnSum = new Button();
            SuspendLayout();
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(12, 388);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Boşver";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnWait
            // 
            btnWait.Location = new Point(93, 388);
            btnWait.Name = "btnWait";
            btnWait.Size = new Size(75, 23);
            btnWait.TabIndex = 1;
            btnWait.Text = "Beklet";
            btnWait.UseVisualStyleBackColor = true;
            btnWait.Click += btnWait_Click;
            // 
            // btnFill
            // 
            btnFill.Location = new Point(174, 388);
            btnFill.Name = "btnFill";
            btnFill.Size = new Size(75, 23);
            btnFill.TabIndex = 2;
            btnFill.Text = "Doldur";
            btnFill.UseVisualStyleBackColor = true;
            // 
            // txtNum1
            // 
            txtNum1.Location = new Point(255, 12);
            txtNum1.Name = "txtNum1";
            txtNum1.Size = new Size(153, 23);
            txtNum1.TabIndex = 3;
            // 
            // txtNum2
            // 
            txtNum2.Location = new Point(255, 51);
            txtNum2.Name = "txtNum2";
            txtNum2.Size = new Size(153, 23);
            txtNum2.TabIndex = 4;
            // 
            // txtSum
            // 
            txtSum.Location = new Point(255, 89);
            txtSum.Name = "txtSum";
            txtSum.ReadOnly = true;
            txtSum.Size = new Size(153, 23);
            txtSum.TabIndex = 5;
            // 
            // lstNumbers
            // 
            lstNumbers.FormattingEnabled = true;
            lstNumbers.ItemHeight = 15;
            lstNumbers.Location = new Point(12, 11);
            lstNumbers.Name = "lstNumbers";
            lstNumbers.Size = new Size(237, 364);
            lstNumbers.TabIndex = 6;
            // 
            // btnSum
            // 
            btnSum.Location = new Point(333, 118);
            btnSum.Name = "btnSum";
            btnSum.Size = new Size(75, 23);
            btnSum.TabIndex = 7;
            btnSum.Text = "Topla";
            btnSum.UseVisualStyleBackColor = true;
            btnSum.Click += btnSum_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(423, 425);
            Controls.Add(btnSum);
            Controls.Add(lstNumbers);
            Controls.Add(txtSum);
            Controls.Add(txtNum2);
            Controls.Add(txtNum1);
            Controls.Add(btnFill);
            Controls.Add(btnWait);
            Controls.Add(btnCancel);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            Text = "TPL";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancel;
        private Button btnWait;
        private Button btnFill;
        private TextBox txtNum1;
        private TextBox txtNum2;
        private TextBox txtSum;
        private ListBox lstNumbers;
        private Button btnSum;
    }
}
