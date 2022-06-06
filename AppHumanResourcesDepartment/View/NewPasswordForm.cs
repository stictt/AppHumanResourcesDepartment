using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppHumanResourcesDepartment.View
{
    public partial class NewPasswordForm : Form
    {
        public string Password = String.Empty;
        public NewPasswordForm()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            Password = PasswordTextBox.Text;
            this.Close();
        }
    }
}
