
namespace AppHumanResourcesDepartment.View
{
    partial class DivisionStructureForm
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
            this.DepartmentTreeView1 = new System.Windows.Forms.TreeView();
            this.AddDepartmentButton1 = new System.Windows.Forms.Button();
            this.RemoveDepartmentButton2 = new System.Windows.Forms.Button();
            this.EditDepartmentButton3 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.EditWorkButton8 = new System.Windows.Forms.Button();
            this.RemoveWorkButton7 = new System.Windows.Forms.Button();
            this.AddWorkButton6 = new System.Windows.Forms.Button();
            this.DownWorkButton5 = new System.Windows.Forms.Button();
            this.UPWorkButton4 = new System.Windows.Forms.Button();
            this.WorkTreeView2 = new System.Windows.Forms.TreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // DepartmentTreeView1
            // 
            this.DepartmentTreeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.DepartmentTreeView1.Location = new System.Drawing.Point(3, 3);
            this.DepartmentTreeView1.Name = "DepartmentTreeView1";
            this.DepartmentTreeView1.Size = new System.Drawing.Size(218, 250);
            this.DepartmentTreeView1.TabIndex = 0;
            this.DepartmentTreeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.DepartmentTreeView1_AfterSelect);
            // 
            // AddDepartmentButton1
            // 
            this.AddDepartmentButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddDepartmentButton1.Location = new System.Drawing.Point(4, 254);
            this.AddDepartmentButton1.Name = "AddDepartmentButton1";
            this.AddDepartmentButton1.Size = new System.Drawing.Size(89, 32);
            this.AddDepartmentButton1.TabIndex = 1;
            this.AddDepartmentButton1.Text = "Добавить";
            this.AddDepartmentButton1.UseVisualStyleBackColor = true;
            this.AddDepartmentButton1.Click += new System.EventHandler(this.AddDepartmentButton1_Click);
            // 
            // RemoveDepartmentButton2
            // 
            this.RemoveDepartmentButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveDepartmentButton2.Location = new System.Drawing.Point(130, 254);
            this.RemoveDepartmentButton2.Name = "RemoveDepartmentButton2";
            this.RemoveDepartmentButton2.Size = new System.Drawing.Size(91, 32);
            this.RemoveDepartmentButton2.TabIndex = 2;
            this.RemoveDepartmentButton2.Text = "Удалить";
            this.RemoveDepartmentButton2.UseVisualStyleBackColor = true;
            this.RemoveDepartmentButton2.Click += new System.EventHandler(this.RemoveDepartmentButton2_Click);
            // 
            // EditDepartmentButton3
            // 
            this.EditDepartmentButton3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EditDepartmentButton3.Location = new System.Drawing.Point(3, 287);
            this.EditDepartmentButton3.Name = "EditDepartmentButton3";
            this.EditDepartmentButton3.Size = new System.Drawing.Size(218, 34);
            this.EditDepartmentButton3.TabIndex = 3;
            this.EditDepartmentButton3.Text = "Изменить";
            this.EditDepartmentButton3.UseVisualStyleBackColor = true;
            this.EditDepartmentButton3.Click += new System.EventHandler(this.EditDepartmentButton3_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.EditWorkButton8);
            this.panel1.Controls.Add(this.RemoveWorkButton7);
            this.panel1.Controls.Add(this.AddWorkButton6);
            this.panel1.Controls.Add(this.DownWorkButton5);
            this.panel1.Controls.Add(this.UPWorkButton4);
            this.panel1.Controls.Add(this.WorkTreeView2);
            this.panel1.Location = new System.Drawing.Point(243, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(307, 373);
            this.panel1.TabIndex = 4;
            // 
            // EditWorkButton8
            // 
            this.EditWorkButton8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EditWorkButton8.Location = new System.Drawing.Point(3, 287);
            this.EditWorkButton8.Name = "EditWorkButton8";
            this.EditWorkButton8.Size = new System.Drawing.Size(243, 34);
            this.EditWorkButton8.TabIndex = 4;
            this.EditWorkButton8.Text = "Просмотр";
            this.EditWorkButton8.UseVisualStyleBackColor = true;
            this.EditWorkButton8.Click += new System.EventHandler(this.EditWorkButton8_Click);
            // 
            // RemoveWorkButton7
            // 
            this.RemoveWorkButton7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveWorkButton7.Location = new System.Drawing.Point(155, 254);
            this.RemoveWorkButton7.Name = "RemoveWorkButton7";
            this.RemoveWorkButton7.Size = new System.Drawing.Size(91, 32);
            this.RemoveWorkButton7.TabIndex = 4;
            this.RemoveWorkButton7.Text = "Удалить";
            this.RemoveWorkButton7.UseVisualStyleBackColor = true;
            this.RemoveWorkButton7.Click += new System.EventHandler(this.RemoveWorkButton7_Click);
            // 
            // AddWorkButton6
            // 
            this.AddWorkButton6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddWorkButton6.Location = new System.Drawing.Point(3, 254);
            this.AddWorkButton6.Name = "AddWorkButton6";
            this.AddWorkButton6.Size = new System.Drawing.Size(89, 32);
            this.AddWorkButton6.TabIndex = 4;
            this.AddWorkButton6.Text = "Добавить";
            this.AddWorkButton6.UseVisualStyleBackColor = true;
            this.AddWorkButton6.Click += new System.EventHandler(this.AddWorkButton6_Click);
            // 
            // DownWorkButton5
            // 
            this.DownWorkButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DownWorkButton5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.DownWorkButton5.Location = new System.Drawing.Point(252, 58);
            this.DownWorkButton5.Name = "DownWorkButton5";
            this.DownWorkButton5.Size = new System.Drawing.Size(46, 42);
            this.DownWorkButton5.TabIndex = 2;
            this.DownWorkButton5.Text = "Down";
            this.DownWorkButton5.UseVisualStyleBackColor = false;
            this.DownWorkButton5.Click += new System.EventHandler(this.DownWorkButton5_Click);
            // 
            // UPWorkButton4
            // 
            this.UPWorkButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UPWorkButton4.BackColor = System.Drawing.Color.Lime;
            this.UPWorkButton4.Location = new System.Drawing.Point(252, 5);
            this.UPWorkButton4.Name = "UPWorkButton4";
            this.UPWorkButton4.Size = new System.Drawing.Size(47, 45);
            this.UPWorkButton4.TabIndex = 1;
            this.UPWorkButton4.Text = "Up";
            this.UPWorkButton4.UseVisualStyleBackColor = false;
            this.UPWorkButton4.Click += new System.EventHandler(this.UPWorkButton4_Click);
            // 
            // WorkTreeView2
            // 
            this.WorkTreeView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WorkTreeView2.Location = new System.Drawing.Point(3, 5);
            this.WorkTreeView2.Name = "WorkTreeView2";
            this.WorkTreeView2.Size = new System.Drawing.Size(243, 248);
            this.WorkTreeView2.TabIndex = 0;
            this.WorkTreeView2.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.WorkTreeView2_AfterSelect);
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.RemoveDepartmentButton2);
            this.panel2.Controls.Add(this.AddDepartmentButton1);
            this.panel2.Controls.Add(this.EditDepartmentButton3);
            this.panel2.Controls.Add(this.DepartmentTreeView1);
            this.panel2.Location = new System.Drawing.Point(6, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(231, 374);
            this.panel2.TabIndex = 5;
            // 
            // DivisionStructure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 397);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.MaximumSize = new System.Drawing.Size(578, 436);
            this.MinimumSize = new System.Drawing.Size(578, 436);
            this.Name = "DivisionStructure";
            this.Text = "DivisionStructure";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView DepartmentTreeView1;
        private System.Windows.Forms.Button AddDepartmentButton1;
        private System.Windows.Forms.Button RemoveDepartmentButton2;
        private System.Windows.Forms.Button EditDepartmentButton3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button EditWorkButton8;
        private System.Windows.Forms.Button RemoveWorkButton7;
        private System.Windows.Forms.Button AddWorkButton6;
        private System.Windows.Forms.Button DownWorkButton5;
        private System.Windows.Forms.Button UPWorkButton4;
        private System.Windows.Forms.TreeView WorkTreeView2;
        private System.Windows.Forms.Panel panel2;
    }
}