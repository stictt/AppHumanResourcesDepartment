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
    public partial class AuthorizationForm : Form
    {
        AuthenticationUserService _authentication;
        public Person UsersAuthorization;
        public AuthorizationForm()
        {
            InitializeComponent();
            _authentication = new AuthenticationUserService();
        }

        private void LogInEnd()
        {
            this.Close();
        }

        private void InputAction()
        {
            _authentication.AddDefaultPerson();

            if (!_authentication.AuthenticationUsers(loginTextBox.Text, passwordTextBox.Text,out var person))
            {
                noAuthorizationLable.Visible = true;
            }
            else 
            {
                UsersAuthorization = person;
                LogInEnd(); 
            }
            loginTextBox.Clear();
            passwordTextBox.Clear();
        }

        private  void OkButton_Click(object sender, EventArgs e)
        {
            InputAction();
        }

        private void passwordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputAction();
            }
        }
    }
}
