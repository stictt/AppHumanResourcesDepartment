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
    public partial class ListUserForm : Form
    {
        DataTable _dataTable;
        public ListUserForm()
        {
            InitializeComponent();
            CreateTable();
            LoadData();
        }

        private void CreateTable()
        {
            _dataTable = new DataTable();
            _dataTable.Columns.Add("Полное имя", typeof(string));
            _dataTable.Columns.Add("Id", typeof(int));
            _dataTable.Columns.Add("Дата рождения", typeof(string));
            _dataTable.Columns.Add("Пол", typeof(string));
            _dataTable.Columns.Add("Отдел кадров", typeof(string));
            _dataTable.Columns.Add("Должность", typeof(string));
            _dataTable.Columns.Add("Отдел", typeof(string));
            _dataTable.Columns.Add("Последние учетные данные", typeof(string));
            dataGridView1.DataSource = _dataTable;
            dataGridView1.Columns[1].Visible = false;
        }

        private async void LoadData()
        {
            List<Person> people;
            using (HumanResourcesContext context = new HumanResourcesContext())
            {
                people = await context.Persons
                     .Include(x => x.Work)
                     .ThenInclude(x => x.Department)
                     .ToListAsync();
            }

            people.ForEach(x =>
            {
                AddPersonToTable(x);
            });
        }

        private void AddPersonToTable(Person person)
        {
            _dataTable.Rows
                    .Add(
                        person.FullName,
                        person.Id,
                        person.BirthDay.ToString("D"),
                        person.Gender,
                        person.HR.ToString(),
                        person.Work == null ? "Нет работы" : person.Work.Name,
                        person.Work == null ? "Нет отдела" : person.Work.Department.Name,
                        "");
        }

        private void EditPersonToTable(Person person)
        {
            DataRow findRow = null;
            foreach (var item in _dataTable.Rows)
            {
                if (item is DataRow && (int)(((DataRow)item)[1]) == person.Id)
                {
                    findRow = ((DataRow)item);
                    break;
                }
            }

            findRow[0] = person.FullName;
            findRow[2] = person.BirthDay.ToString("D");
            findRow[3] = person.Gender;
            findRow[4] = person.HR.ToString();
            findRow[5] = person.Work == null ? "Нет работы" : person.Work.Name;
            findRow[6] = person.Work == null ? "Нет отдела" : person.Work.Department.Name;
        }

        private void NewPersonButton1_Click(object sender, EventArgs e)
        {
            UserForm user = new UserForm();
            user.FormClosed += (object? sender, FormClosedEventArgs e) =>
            {
                if (user.IsChanges)
                {
                    AddPersonToTable(user.PersonForm);
                }
            };
            user.ShowDialog();
        }

        private void EditPersonButton2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                return;
            }

            int idUser = (int)dataGridView1.CurrentRow.Cells[1].Value;
            UserForm user = new UserForm(idUser);
            user.FormClosed += (object? sender, FormClosedEventArgs e) =>
            {
                if (user.IsChanges)
                {
                    EditPersonToTable(user.PersonForm);
                }
            };
            user.ShowDialog();
        }

        private bool CheckedField(DataGridViewRow row,string value)
        {
            List<bool> containsValue = new List<bool>();
            foreach (string item in value.ToLower().Split(" "))
            {
                if (((string)row.Cells[0].Value).ToLower().Contains(item))
                {
                    containsValue.Add(true);
                    continue;
                }
                if (((string)row.Cells[2].Value).ToLower().Contains(item))
                {
                    containsValue.Add(true);
                    continue;
                }
                if (((string)row.Cells[3].Value).ToLower().Contains(item))
                {
                    containsValue.Add(true);
                    continue;
                }
                if (((string)row.Cells[4].Value).ToLower().Contains(item))
                {
                    containsValue.Add(true);
                    continue;
                }
                if (((string)row.Cells[5].Value).ToLower().Contains(item))
                {
                    containsValue.Add(true);
                    continue;
                }
                if (((string)row.Cells[6].Value).ToLower().Contains(item))
                {
                    containsValue.Add(true);
                    continue;
                }
                containsValue.Add(false);
                continue;
            }
            return containsValue.All(x=>x);
        }

        private void FindTextBox1_TextChanged(object sender, EventArgs e)
        {
            List<DataGridViewRow> showRow = new List<DataGridViewRow>();
            List<DataGridViewRow> hideRow = new List<DataGridViewRow>();
            if (FindTextBox1.Text == String.Empty)
            {
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    showRow.Add(item);
                }

            }
            else
            {
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    if (CheckedField(item, FindTextBox1.Text))
                    {
                        showRow.Add(item);
                    }
                    else
                    {
                        hideRow.Add(item);
                    }
                }
            }
            dataGridView1.CurrentCell = null;
            showRow.ForEach(x => x.Visible = true);
            hideRow.ForEach(x => x.Visible = false);
        }

        private async Task DeleteUser(int id)
        {
            using (HumanResourcesContext context = new HumanResourcesContext())
            {
                var person = await context.Persons
                    .Where(x=>x.Id == id)
                    .FirstOrDefaultAsync();

                context.Persons.Remove(person);
                await context.SaveChangesAsync();
            }
        }

        private bool DeleteUserToTable(int id)
        {
            foreach (DataRow item in _dataTable.Rows)
            {
                if (((int)item[1]) == id)
                {
                    _dataTable.Rows.Remove(item);
                    return true;
                }
            }
            return false;
        }

        private async void DeleteButton3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                return;
            }

            int idUser = (int)dataGridView1.CurrentRow.Cells[1].Value;
            try
            {
                await DeleteUser(idUser);
            }
            catch
            {
                MessageBox.Show("Ошибка удаления данных. Возможно данные устарели");
                return;
            }
            DeleteUserToTable(idUser);
        }

        private async Task RaisePerson(int id)
        {
            using (HumanResourcesContext context = new HumanResourcesContext())
            {
                var person = await context.Persons
                    .Include(x=>x.Work)
                    .ThenInclude(x => x.Perent)
                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync();
                if (person.Work.Perent != null)
                {
                    person.Work = person.Work.Perent;
                }
                await context.SaveChangesAsync();
            }
        }

        private async Task<Person> GetPerson(int id)
        {
            using (HumanResourcesContext context = new HumanResourcesContext())
            {
                var person = await context.Persons
                    .Include(x=>x.HumanSecurity)
                    .Include(x => x.Work)
                    .ThenInclude(x => x.Department)
                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync();

                return person;
            }
        }

        private async void RaiseButton4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                return;
            }

            int idUser = (int)dataGridView1.CurrentRow.Cells[1].Value;
            try
            {
                await RaisePerson(idUser);
            }
            catch
            {
                MessageBox.Show("Ошибка проводки данных. Возможно данные устарели");
                return;
            }
            EditPersonToTable(await GetPerson(idUser));
        }
    }
}
