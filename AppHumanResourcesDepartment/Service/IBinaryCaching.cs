using AppHumanResourcesDepartment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppHumanResourcesDepartment.Service
{
    public interface IBinaryCaching
    {
        public bool TryLoad<T>(out List<T> loadData, out Exception errorMessage) where T : FileRepresentation, new();

        public bool TrySave<T>(List<T> loadData, out Exception errorMessage) where T : FileRepresentation, new();
    }
}
