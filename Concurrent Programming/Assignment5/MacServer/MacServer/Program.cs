using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MacServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Chattserver"; //Sets the consoletitle
            ClientListener listener = new ClientListener(); //New instance of Clientlistener
            Console.WriteLine("Starting server...");
            Console.WriteLine("Press x to exit");
            while(Console.ReadLine() != "x") //Aslong as the user doesnt press x, dont close.
            {

            }

        }
    }
}
