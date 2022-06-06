
namespace AppHumanResourcesDepartment.View
{
    partial class DesktopForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ыToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.ыToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.учетПодразделенийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.кадровыеДвиженияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(12, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 398);
            this.panel1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ыToolStripMenuItem,
            this.ыToolStripMenuItem1,
            this.кадровыеДвиженияToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ыToolStripMenuItem
            // 
            this.ыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ыToolStripMenuItem2});
            this.ыToolStripMenuItem.Name = "ыToolStripMenuItem";
            this.ыToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.ыToolStripMenuItem.Text = "Сотрудники";
            // 
            // ыToolStripMenuItem2
            // 
            this.ыToolStripMenuItem2.Name = "ыToolStripMenuItem2";
            this.ыToolStripMenuItem2.Size = new System.Drawing.Size(188, 22);
            this.ыToolStripMenuItem2.Text = "Список сотрудников";
            this.ыToolStripMenuItem2.Click += new System.EventHandler(this.ToolStripMenuItem2_Click);
            // 
            // ыToolStripMenuItem1
            // 
            this.ыToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.учетПодразделенийToolStripMenuItem});
            this.ыToolStripMenuItem1.Name = "ыToolStripMenuItem1";
            this.ыToolStripMenuItem1.Size = new System.Drawing.Size(57, 20);
            this.ыToolStripMenuItem1.Text = "Фирма";
            // 
            // учетПодразделенийToolStripMenuItem
            // 
            this.учетПодразделенийToolStripMenuItem.Name = "учетПодразделенийToolStripMenuItem";
            this.учетПодразделенийToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.учетПодразделенийToolStripMenuItem.Text = "Учет подразделений";
            this.учетПодразделенийToolStripMenuItem.Click += new System.EventHandler(this.учетПодразделенийToolStripMenuItem_Click);
            // 
            // кадровыеДвиженияToolStripMenuItem
            // 
            this.кадровыеДвиженияToolStripMenuItem.Name = "кадровыеДвиженияToolStripMenuItem";
            this.кадровыеДвиженияToolStripMenuItem.Size = new System.Drawing.Size(130, 20);
            this.кадровыеДвиженияToolStripMenuItem.Text = "Кадровые движения";
            // 
            // Desktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Desktop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.Desktop_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ыToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem ыToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem учетПодразделенийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem кадровыеДвиженияToolStripMenuItem;
    }
}

