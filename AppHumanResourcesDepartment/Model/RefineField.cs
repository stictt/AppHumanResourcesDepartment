using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppHumanResourcesDepartment.Model
{
    public class RefineField
    {
        public int Id { get; set; }
        [Required]
        public Work Work { get; set; }
        public int WorkID { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public RefineField Perent { get; set; }
        public int? PerentID { get; set; }
        public RefineField Next { get; set; }
    }
}
