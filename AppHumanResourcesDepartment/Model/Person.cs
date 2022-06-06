using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppHumanResourcesDepartment.Model
{
    public class Person
    {
        public int Id { get; set; }
        public Security HumanSecurity { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDay { get; set; }
        public string Gender { get; set; }
        public bool HR { get; set; }
        public Work Work { get; set; }
        public int? WorkId { get; set; }
    }
}
