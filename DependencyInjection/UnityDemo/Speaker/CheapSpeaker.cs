﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityDemo
{
    public class CheapSpeaker : ISpeaker
    {
        public void Start()
        {
            Console.WriteLine("Sounds cheap");
        }
    }
}
