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
using Microsoft.EntityFrameworkCore;

namespace AppHumanResourcesDepartment.View
{
    public partial class UserForm : Form
    {
        public Person PersonForm;
        public bool IsChanges = false;
        string _newPassword = String.Empty;
        

        public UserForm(int IdUser = -1)
        {
            InitializeComponent();
            FillFields(IdUser);
        }
        private async void FillFields(int idUser)
        {
            if (idUser == -1)
            {
                await DepartmentComboBoxInit();
                return;
            }
            await LoadPersonToForm(idUser);

            if (PersonForm == null) 
            {
                this.Close();
                MessageBox.Show("Ошибка загрузки данных.");
                return; 
            }

            HRcheckBox1.Checked = PersonForm.HR;

            FIOtextBox1.Text = PersonForm.FullName;
            birthDateTimePicker1.Value = PersonForm.BirthDay;

            await DepartmentComboBoxInit(true);
            await WorkComboBoxInit(PersonForm.Work?.Department,true);

            LoginTextBoxInit();
            GenderBoxInit();
        }

        private async Task LoadPersonToForm(int idUser)
        {
            using (HumanResourcesContext context = new HumanResourcesContext())
            {
                PersonForm = await context.Persons
                    .Include(x => x.HumanSecurity)
                    .Include(x => x.Work)
                    .ThenInclude(x => x.Department)
                    .Where(x => x.Id == idUser)
                    .FirstOrDefaultAsync();
            }
        }

        private void LoginTextBoxInit()
        {
            if (PersonForm.HumanSecurity == null)
            {
                return;
            }
            loginTextBox1.Text = PersonForm.HumanSecurity.Login ;

            if (PersonForm.HumanSecurity.Login != String.Empty)
            {
                loginTextBox1.Enabled = false;
            }
        }

        private void GenderBoxInit()
        {
            if (PersonForm.Gender == "Муж")
            {
                maleCheckBox1.Checked = true;
            }
            else if (PersonForm.Gender == "Жен")
            {
                femCheckBox2.Checked = true;
            }
        }

        private async Task DepartmentComboBoxInit(bool setDefault = false)
        {
            using (HumanResourcesContext context = new HumanResourcesContext())
            {
                var sourceDepartment = await context.Departments.ToListAsync();

                departmentComboBox1.DataSource = sourceDepartment;
                departmentComboBox1.DisplayMember = "Name";
                departmentComboBox1.ValueMember = "Id";

                if (setDefault)
                {
                    departmentComboBox1.SelectedItem = 
                        sourceDepartment.FirstOrDefault(x => x.Id == PersonForm.Work?.Department.Id);
                }
            }
        }

        private async Task WorkComboBoxInit(Department department, bool setDefault = false)
        {
            if (department == null)
            {
                return;
            }
            using (HumanResourcesContext context = new HumanResourcesContext()) 
            {
                var sourceWork = await context.Works
                    .Include(x => x.Department)
                    .Where(x => x.DepartmentID == department.Id)
                    .ToListAsync();

                workComboBox2.DataSource = SorterdWork(sourceWork);
                workComboBox2.DisplayMember = "Name";
                workComboBox2.ValueMember = "Id";

                if (setDefault)
                {
                    workComboBox2.SelectedItem =
                        sourceWork.FirstOrDefault(x => x.Id == PersonForm.Work?.Id);
                }
            }
        }

        private List<Work> SorterdWork(List<Work> works)
        {
            Work tempWork = works.FirstOrDefault(x => x.Perent == null);
            List<Work> result = new List<Work>();
            while(tempWork != null)
            {
                result.Add(tempWork);
                tempWork = tempWork.Next;
            }
            return result;
        }

        private void maleCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (maleCheckBox1.Checked)
            {
                femCheckBox2.Checked = false;
            }
        }

        private void femCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (femCheckBox2.Checked)
            {
                maleCheckBox1.Checked = false;
            }
        }

        private void newPasswordButton1_Click(object sender, EventArgs e)
        {
            NewPasswordForm newPassword = new NewPasswordForm();
            newPassword.ShowDialog();
            if (newPassword.Password != String.Empty)
            {
                _newPassword = newPassword.Password;
            }
        }

        private async void departmentComboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            workComboBox2.DataSource = null;
            workComboBox2.SelectedItem = null;
            await WorkComboBoxInit((Department)departmentComboBox1.SelectedItem);
        }

        private async Task GenerateFormResult()
        {
            Person uiDataPerson = GetUIDeclarationPersonData();
            using (HumanResourcesContext context = new HumanResourcesContext())
            {
                Person result;

                var tempWork = await context.Works
                    .Include(x=>x.Department)
                    .Where(x => x.Id == uiDataPerson.Work.Id)
                    .FirstAsync();

                if (PersonForm == null)
                {
                    result = CreatePerson(tempWork, uiDataPerson);
                    context.Persons.Add(result);
                }
                else
                {
                    var tempUser = await context.Persons
                        .Include(x => x.HumanSecurity)
                        .Include(x => x.Work)
                        .ThenInclude(x => x.Department)
                        .Where(x => x.Id == PersonForm.Id)
                        .FirstOrDefaultAsync();

                    result = UpdatePerson(tempUser, tempWork, uiDataPerson);
                }
                context.SaveChanges();
                PersonForm = result;
                IsChanges = true;
            }
        }

        private Person CreatePerson(Work work,Person uiDataPerson)
        {
            return UpdatePerson(new Person(), work, uiDataPerson);
        }

        private Person GetUIDeclarationPersonData()
        {
            Person person = new Person();
            person.FullName = FIOtextBox1.Text;
            person.BirthDay = birthDateTimePicker1.Value;
            person.HR = HRcheckBox1.Checked;
            person.Gender = femCheckBox2.Checked ? "Жен" : maleCheckBox1.Checked ? "Муж" : "Nan";
            person.Work = (Work)workComboBox2.SelectedItem;
            person.HumanSecurity = new Security(loginTextBox1.Text, "nan");

            return person;
        }

        private Person UpdatePerson(Person person,Work work, Person uiDataPerson)
        {
            person.FullName = uiDataPerson.FullName;
            person.BirthDay = uiDataPerson.BirthDay;
            person.HR = uiDataPerson.HR;
            person.Gender = uiDataPerson.Gender;
            person.Work = work;

            if (person.HumanSecurity == null && uiDataPerson.HumanSecurity.Login != String.Empty)
            {
                person.HumanSecurity = new Security(uiDataPerson.HumanSecurity.Login, _newPassword);
            }
            else if (person.HumanSecurity != null && _newPassword != String.Empty)
            {
                person.HumanSecurity.Password = _newPassword;
            }

            return person;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void okButton_Click(object sender, EventArgs e)
        {
            if (workComboBox2.SelectedItem == null)
            {
                MessageBox.Show("Заполните должность");
                return;
            }
            if (departmentComboBox1.SelectedItem == null)
            {
                MessageBox.Show("Заполните Отдел");
                return;
            }
            if (loginTextBox1.Enabled && loginTextBox1.Text != String.Empty && _newPassword == String.Empty)
            {
                MessageBox.Show("Введите пароль учетной записи. ");
                return;
            }
            try
            {
              await GenerateFormResult();
            }
            catch
            {
                MessageBox.Show("Ошибка проводки. Возможно данные устарели");
                return;
            }
            this.Close();
        }
    }
}
