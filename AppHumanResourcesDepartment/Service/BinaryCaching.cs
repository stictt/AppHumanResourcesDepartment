
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using AppHumanResourcesDepartment.Model;

namespace AppHumanResourcesDepartment.Service
{
    public class BinaryCaching : IBinaryCaching
    {
        public bool TryLoad<T>(out List<T> loadData, out Exception errorMessage) where T : FileRepresentation, new()
        {
            errorMessage = null;
            loadData = null;
            BinaryFormatter formatter = new BinaryFormatter();

            try
            {
                using (FileStream fs = new FileStream(new T().FileName + ".dat", FileMode.Open))
                {
                    loadData = (List<T>)formatter.Deserialize(fs);
                }
                return true;
            }
            catch (Exception e)
            {
                errorMessage = e;
                return false;
            }
        }

        public bool TrySave<T>(List<T> loadData, out Exception errorMessage) where T : FileRepresentation, new()
        {
            errorMessage = null;
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream(new T().FileName + ".dat", FileMode.Create))
                {
                    formatter.Serialize(fs, loadData);
                }
                return true;
            }
            catch (Exception e)
            {
                errorMessage = e;
                return false;
            }
        }
    }
}
