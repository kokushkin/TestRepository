using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityDemo
{
    public interface ITuner
    {
        string Manufacturer();

        int TunedFrequency();

        bool SelfCheck();

        string SerialNumber();
    }
}
