using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppHumanResourcesDepartment.Model
{
    public class Work
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<RefineField> RefineFields { get; set; }
        public Department Department { get; set; }
        public int DepartmentID { get; set; }
        public Work Perent { get; set; }
        public int? PerentID { get; set; }
        public Work Next { get; set; }
        public List<Person> People { get; set; }
    }
}
