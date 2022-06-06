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
    public partial class DepartmentForm : Form
    {
        public Department ItemDepartment;
        public bool IsChanges = false;
        public DepartmentForm(int id = -1)
        {
            InitializeComponent();
            FillFields(id);
        }

        private async void FillFields(int id)
        {
            if (id == -1)
            {
                CreateDepartment();
                return;
            }
            await LoadDepartmentToForm(id);

            if (ItemDepartment == null)
            {
                this.Close();
                MessageBox.Show("Ошибка загрузки данных.");
                return;
            }

            DepartmentTextBox1.Text = ItemDepartment.Name;
        }

        private void CreateDepartment()
        {
            ItemDepartment = new Department();
        }

        private async Task LoadDepartmentToForm(int id)
        {
            using (HumanResourcesContext context = new HumanResourcesContext())
            {
                ItemDepartment = await context.Departments
                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync();
            }
        }

        private async Task<bool> Save()
        {
            try
            {
                using (HumanResourcesContext context = new HumanResourcesContext())
                {
                    if (ItemDepartment.Id == default)
                    {
                        context.Departments.Add(ItemDepartment);
                    }
                    else
                    {
                        var temp = await context.Departments.FirstOrDefaultAsync(x => x.Id == ItemDepartment.Id);
                        temp.Name = ItemDepartment.Name;
                    }
                    await context.SaveChangesAsync();
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
            IsChanges = true;
            ItemDepartment.Name = DepartmentTextBox1.Text;

            if (await Save())
            {
                this.Close();
            }
        }

        private void CancelButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
