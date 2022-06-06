using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppHumanResourcesDepartment.Model
{
    [SerializableAttribute]
    public abstract class FileRepresentation
    {
        public FileRepresentation()
        {
            if (Attribute.GetCustomAttribute(this.GetType(), typeof(SerializableAttribute)) == null)
            {
                throw new NotImplementedException("No have SerializableAttribute.");
            }
        }
        public string FileName { get; protected set; }
    }
}
