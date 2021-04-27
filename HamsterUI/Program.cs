using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend;
using Backend.Events;
using HamsterData;
using System.Threading.Tasks;
using System.Threading;

namespace HamsterUI
{
    class Program
    {
        static void Main(string[] args)
        {
            UI userInterface = new UI();
            userInterface.Run();
        } 
    }
}
