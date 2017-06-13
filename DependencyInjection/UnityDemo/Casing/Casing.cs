using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityDemo
{
    public class Casing : ICasing
    {
        private readonly string _material;

        public Casing(string material)
        {
            _material = material;
        }

        public string TypeOfMaterial()
        {
            return "Material used :" + _material;
        }
    }
}
