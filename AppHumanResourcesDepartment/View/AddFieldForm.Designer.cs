
namespace AppHumanResourcesDepartment.View
{
    partial class AddFieldForm
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
            this.OkButton1 = new System.Windows.Forms.Button();
            this.CancelButton2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.NameFieldTextBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // OkButton1
            // 
            this.OkButton1.Location = new System.Drawing.Point(12, 128);
            this.OkButton1.Name = "OkButton1";
            this.OkButton1.Size = new System.Drawing.Size(75, 23);
            this.OkButton1.TabIndex = 0;
            this.OkButton1.Text = "Ok";
            this.OkButton1.UseVisualStyleBackColor = true;
            this.OkButton1.Click += new System.EventHandler(this.OkButton1_Click);
            // 
            // CancelButton2
            // 
            this.CancelButton2.Location = new System.Drawing.Point(197, 128);
            this.CancelButton2.Name = "CancelButton2";
            this.CancelButton2.Size = new System.Drawing.Size(75, 23);
            this.CancelButton2.TabIndex = 1;
            this.CancelButton2.Text = "Cancel";
            this.CancelButton2.UseVisualStyleBackColor = true;
            this.CancelButton2.Click += new System.EventHandler(this.CancelButton2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Название поля";
            // 
            // NameFieldTextBox1
            // 
            this.NameFieldTextBox1.Location = new System.Drawing.Point(43, 62);
            this.NameFieldTextBox1.Name = "NameFieldTextBox1";
            this.NameFieldTextBox1.Size = new System.Drawing.Size(183, 23);
            this.NameFieldTextBox1.TabIndex = 3;
            // 
            // AddAddFieldForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 172);
            this.Controls.Add(this.NameFieldTextBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CancelButton2);
            this.Controls.Add(this.OkButton1);
            this.MaximumSize = new System.Drawing.Size(300, 211);
            this.MinimumSize = new System.Drawing.Size(300, 211);
            this.Name = "AddAddFieldForm";
            this.Text = "Добавить поле";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OkButton1;
        private System.Windows.Forms.Button CancelButton2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NameFieldTextBox1;
    }
}