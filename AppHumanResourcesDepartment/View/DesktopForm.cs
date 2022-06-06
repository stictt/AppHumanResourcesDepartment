using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppHumanResourcesDepartment.Model;
using AppHumanResourcesDepartment.Service;

namespace AppHumanResourcesDepartment.View
{
    public partial class DesktopForm : Form
    {
        private Person _users;
        HumanResourcesContext _context;
        public DesktopForm()
        {
            _context = new HumanResourcesContext();
            InitializeComponent();
        }

        private void DialogAuthorization()
        {
            var form = new AuthorizationForm();
            form.FormClosed += (object? sender, FormClosedEventArgs e) =>
            {
                if (form.UsersAuthorization != null)
                {
                    _users = form.UsersAuthorization;
                }
                else
                {
                    Application.Exit();
                }
            };
            form.ShowDialog();
        }

        private void Desktop_Shown(object sender, EventArgs e)
        {
            DialogAuthorization();
        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ListUserForm listUser = new ListUserForm();
            listUser.Show();
        }

        private void учетПодразделенийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DivisionStructureForm divisionStructure = new DivisionStructureForm();
            divisionStructure.Show();
        }
    }
}
