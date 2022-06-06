using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppHumanResourcesDepartment.Model
{
    public class Security
    {

        private string _password;
        public Person Person;
        public int PersonID;
        public int Id { get; set; }
        public string Login {get;set;}
        public string Password { set { _password = HashPassword(value); } }
        public Security()
        {
        }
        public Security(string login, string password)
        {
            Login = login;
            Password = password;
        }

        private string HashPassword(string value)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                List<byte> data = sha256Hash
                    .ComputeHash(Encoding.UTF8.GetBytes(value))
                    .ToList();

                StringBuilder result = new StringBuilder();
                data.ForEach(x => result.Append(x.ToString("x2")));

                return result.ToString();
            }
        }

        public bool ComparePassword(string password)
        {
            var result = HashPassword(password);

            return _password.CompareTo(result) == 0;
        }
    }
}
