using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityDemo
{
    public interface IRadio
    {
        IBattery Battery { get; set; }
        string Name { get; set; }
        ITuner Tuner { get; set; }

        string RadioName();
        void Start();
    }
}
