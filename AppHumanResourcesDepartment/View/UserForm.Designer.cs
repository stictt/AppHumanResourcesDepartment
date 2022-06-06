
namespace AppHumanResourcesDepartment.View
{
    partial class UserForm
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
            this.FIOtextBox1 = new System.Windows.Forms.TextBox();
            this.FIOLable = new System.Windows.Forms.Label();
            this.birthDateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.maleCheckBox1 = new System.Windows.Forms.CheckBox();
            this.femCheckBox2 = new System.Windows.Forms.CheckBox();
            this.departmentComboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.workComboBox2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.loginLabel = new System.Windows.Forms.Label();
            this.loginTextBox1 = new System.Windows.Forms.TextBox();
            this.newPasswordButton1 = new System.Windows.Forms.Button();
            this.HRcheckBox1 = new System.Windows.Forms.CheckBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FIOtextBox1
            // 
            this.FIOtextBox1.Location = new System.Drawing.Point(8, 88);
            this.FIOtextBox1.Name = "FIOtextBox1";
            this.FIOtextBox1.Size = new System.Drawing.Size(272, 23);
            this.FIOtextBox1.TabIndex = 0;
            // 
            // FIOLable
            // 
            this.FIOLable.AutoSize = true;
            this.FIOLable.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.FIOLable.Location = new System.Drawing.Point(104, 56);
            this.FIOLable.Name = "FIOLable";
            this.FIOLable.Size = new System.Drawing.Size(69, 32);
            this.FIOLable.TabIndex = 1;
            this.FIOLable.Text = "ФИО";
            // 
            // birthDateTimePicker1
            // 
            this.birthDateTimePicker1.Location = new System.Drawing.Point(104, 136);
            this.birthDateTimePicker1.Name = "birthDateTimePicker1";
            this.birthDateTimePicker1.Size = new System.Drawing.Size(176, 23);
            this.birthDateTimePicker1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "День рождения";
            // 
            // maleCheckBox1
            // 
            this.maleCheckBox1.AutoSize = true;
            this.maleCheckBox1.FlatAppearance.BorderSize = 2;
            this.maleCheckBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.maleCheckBox1.Location = new System.Drawing.Point(83, 181);
            this.maleCheckBox1.Name = "maleCheckBox1";
            this.maleCheckBox1.Size = new System.Drawing.Size(50, 19);
            this.maleCheckBox1.TabIndex = 4;
            this.maleCheckBox1.Text = "Муж\r\n";
            this.maleCheckBox1.UseVisualStyleBackColor = true;
            this.maleCheckBox1.CheckedChanged += new System.EventHandler(this.maleCheckBox1_CheckedChanged);
            // 
            // femCheckBox2
            // 
            this.femCheckBox2.AutoSize = true;
            this.femCheckBox2.FlatAppearance.BorderSize = 2;
            this.femCheckBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.femCheckBox2.Location = new System.Drawing.Point(150, 181);
            this.femCheckBox2.Name = "femCheckBox2";
            this.femCheckBox2.Size = new System.Drawing.Size(48, 19);
            this.femCheckBox2.TabIndex = 5;
            this.femCheckBox2.Text = "Жен";
            this.femCheckBox2.UseVisualStyleBackColor = true;
            this.femCheckBox2.CheckedChanged += new System.EventHandler(this.femCheckBox2_CheckedChanged);
            // 
            // departmentComboBox1
            // 
            this.departmentComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.departmentComboBox1.FormattingEnabled = true;
            this.departmentComboBox1.Location = new System.Drawing.Point(83, 224);
            this.departmentComboBox1.Name = "departmentComboBox1";
            this.departmentComboBox1.Size = new System.Drawing.Size(197, 23);
            this.departmentComboBox1.TabIndex = 6;
            this.departmentComboBox1.SelectionChangeCommitted += new System.EventHandler(this.departmentComboBox1_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 228);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Отдел";
            // 
            // workComboBox2
            // 
            this.workComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.workComboBox2.FormattingEnabled = true;
            this.workComboBox2.Location = new System.Drawing.Point(83, 273);
            this.workComboBox2.Name = "workComboBox2";
            this.workComboBox2.Size = new System.Drawing.Size(197, 23);
            this.workComboBox2.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 277);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Должность";
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.Location = new System.Drawing.Point(29, 9);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(37, 15);
            this.loginLabel.TabIndex = 10;
            this.loginLabel.Text = "Login";
            // 
            // loginTextBox1
            // 
            this.loginTextBox1.Location = new System.Drawing.Point(12, 38);
            this.loginTextBox1.Name = "loginTextBox1";
            this.loginTextBox1.Size = new System.Drawing.Size(75, 23);
            this.loginTextBox1.TabIndex = 11;
            // 
            // newPasswordButton1
            // 
            this.newPasswordButton1.Location = new System.Drawing.Point(104, 37);
            this.newPasswordButton1.Name = "newPasswordButton1";
            this.newPasswordButton1.Size = new System.Drawing.Size(161, 23);
            this.newPasswordButton1.TabIndex = 12;
            this.newPasswordButton1.Text = "Установить новый пароль";
            this.newPasswordButton1.UseVisualStyleBackColor = true;
            this.newPasswordButton1.Click += new System.EventHandler(this.newPasswordButton1_Click);
            // 
            // HRcheckBox1
            // 
            this.HRcheckBox1.AutoSize = true;
            this.HRcheckBox1.Location = new System.Drawing.Point(104, 310);
            this.HRcheckBox1.Name = "HRcheckBox1";
            this.HRcheckBox1.Size = new System.Drawing.Size(100, 19);
            this.HRcheckBox1.TabIndex = 13;
            this.HRcheckBox1.Text = "Отдел кадров";
            this.HRcheckBox1.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(12, 355);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 14;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(209, 355);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 15;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 390);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.HRcheckBox1);
            this.Controls.Add(this.newPasswordButton1);
            this.Controls.Add(this.loginTextBox1);
            this.Controls.Add(this.loginLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.workComboBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.departmentComboBox1);
            this.Controls.Add(this.femCheckBox2);
            this.Controls.Add(this.maleCheckBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.birthDateTimePicker1);
            this.Controls.Add(this.FIOLable);
            this.Controls.Add(this.FIOtextBox1);
            this.MaximumSize = new System.Drawing.Size(312, 429);
            this.MinimumSize = new System.Drawing.Size(312, 429);
            this.Name = "User";
            this.Text = "User";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FIOtextBox1;
        private System.Windows.Forms.Label FIOLable;
        private System.Windows.Forms.DateTimePicker birthDateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox maleCheckBox1;
        private System.Windows.Forms.CheckBox femCheckBox2;
        private System.Windows.Forms.ComboBox departmentComboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox workComboBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.TextBox loginTextBox1;
        private System.Windows.Forms.Button newPasswordButton1;
        private System.Windows.Forms.CheckBox HRcheckBox1;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
    }
}