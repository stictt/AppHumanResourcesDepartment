using AppHumanResourcesDepartment.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppHumanResourcesDepartment.Service
{
    public class AuthenticationUserService
    {
        HumanResourcesContext _context;
        public AuthenticationUserService()
        {
            _context = new HumanResourcesContext();
        }

        public void AddDefaultPerson()
        {
            if (_context.Persons.Where(x=>x.HR).Count() != 0) return;

            Person root = new Person()
            {
                HumanSecurity = new Security("Admin", "Admin") ,
                BirthDay = DateTime.Now,
                FullName = "Admin",
                Gender = "nan",
                HR = true
            };
            _context.Persons.Add(root);
            _context.SaveChanges();
        }
        public bool AuthenticationUsers(string user, string password,out Person person)
        {
             person = _context.Persons
                 .Include(x => x.HumanSecurity)
                 .Where(x => x.HumanSecurity.Login == user)
                 .Where(x=>x.HR)
                 .FirstOrDefault();

            if (person != null && person.HumanSecurity.ComparePassword(password))
            {
                return true;
            }
            return false;
        }
    }
}
