
namespace AppHumanResourcesDepartment.View
{
    partial class WorkForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.WorkTextBox1 = new System.Windows.Forms.TextBox();
            this.OkButton1 = new System.Windows.Forms.Button();
            this.CancelButton2 = new System.Windows.Forms.Button();
            this.AddFieldbutton1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(110, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Должность";
            // 
            // WorkTextBox1
            // 
            this.WorkTextBox1.Location = new System.Drawing.Point(44, 53);
            this.WorkTextBox1.Name = "WorkTextBox1";
            this.WorkTextBox1.Size = new System.Drawing.Size(261, 23);
            this.WorkTextBox1.TabIndex = 1;
            // 
            // OkButton1
            // 
            this.OkButton1.Location = new System.Drawing.Point(12, 102);
            this.OkButton1.Name = "OkButton1";
            this.OkButton1.Size = new System.Drawing.Size(75, 23);
            this.OkButton1.TabIndex = 2;
            this.OkButton1.Text = "Ok";
            this.OkButton1.UseVisualStyleBackColor = true;
            this.OkButton1.Click += new System.EventHandler(this.OkButton1_Click);
            // 
            // CancelButton2
            // 
            this.CancelButton2.Location = new System.Drawing.Point(275, 102);
            this.CancelButton2.Name = "CancelButton2";
            this.CancelButton2.Size = new System.Drawing.Size(75, 23);
            this.CancelButton2.TabIndex = 3;
            this.CancelButton2.Text = "Cancel";
            this.CancelButton2.UseVisualStyleBackColor = true;
            this.CancelButton2.Click += new System.EventHandler(this.CancelButton2_Click);
            // 
            // AddFieldbutton1
            // 
            this.AddFieldbutton1.Location = new System.Drawing.Point(110, 102);
            this.AddFieldbutton1.Name = "AddFieldbutton1";
            this.AddFieldbutton1.Size = new System.Drawing.Size(133, 23);
            this.AddFieldbutton1.TabIndex = 4;
            this.AddFieldbutton1.Text = "Добавить поля";
            this.AddFieldbutton1.UseVisualStyleBackColor = true;
            this.AddFieldbutton1.Click += new System.EventHandler(this.AddFieldbutton1_Click);
            // 
            // WorkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 561);
            this.Controls.Add(this.AddFieldbutton1);
            this.Controls.Add(this.CancelButton2);
            this.Controls.Add(this.OkButton1);
            this.Controls.Add(this.WorkTextBox1);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(378, 600);
            this.MinimumSize = new System.Drawing.Size(378, 39);
            this.Name = "WorkForm";
            this.Text = "WorkForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox WorkTextBox1;
        private System.Windows.Forms.Button OkButton1;
        private System.Windows.Forms.Button CancelButton2;
        private System.Windows.Forms.Button AddFieldbutton1;
    }
}