using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppHumanResourcesDepartment.Model
{
    [SerializableAttribute]
    public class AppSettings : FileRepresentation
    {
        public AppSettings() => FileName = "AppSettings";

        public bool IsFirstRun;
    }
}
