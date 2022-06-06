using AppHumanResourcesDepartment.Model;
using AppHumanResourcesDepartment.Service;
using Microsoft.EntityFrameworkCore;
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
    public partial class AddFieldForm : Form
    {
        public RefineField ItemRefineField;
        public bool IsChanges = false;
        private int _idWork;
        public AddFieldForm(int idWork)
        {
            _idWork = idWork;
            InitializeComponent();
        }

        private async Task<bool> Save()
        {
            try
            {
                using (HumanResourcesContext context = new HumanResourcesContext())
                {
                    var work = await context.Works
                        .Include(x => x.RefineFields)
                        .ThenInclude(x => x.Perent)
                        .ThenInclude(x => x.Next)
                        .FirstOrDefaultAsync(x => x.Id == _idWork);

                    var fieldsPerent = work?.RefineFields.FirstOrDefault(x => x?.Next == null);

                    ItemRefineField = new RefineField()
                    {
                        Name = NameFieldTextBox1.Text,
                        Perent = fieldsPerent,
                        WorkID = work?.Id ?? 0
                    };
                }
            }
            catch
            {
                MessageBox.Show("Ошибка проведения данных.");
                return false;
            }
            return true;
        }

        private async void OkButton1_Click(object sender, EventArgs e)
        {
            if (NameFieldTextBox1.Text == string.Empty)
            {
                MessageBox.Show("Заполните название поля");
                return;
            }
            if (await Save())
            {
                IsChanges = true;
                this.Close();
            }
        }

        private void CancelButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
