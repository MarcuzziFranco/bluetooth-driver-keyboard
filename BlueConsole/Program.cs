﻿using BlueConsole.Config;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueConsole
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Initialice...");
            //new ManagerConfiguration();

            new SerialPortProgram(new ManagerConfiguration().LoadConfiguration());

            Console.ReadLine();
             
        }
    }
}
