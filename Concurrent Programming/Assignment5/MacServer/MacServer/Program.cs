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
        private static string ip = "";
        private static int port = 0;

        static void Main(string[] args)
        {
            Console.Title = "Chattserver";
            //Console.WriteLine("Specify your ip: ");
            //ip = Console.ReadLine();
            //Console.WriteLine("Specify your port: ");
            //Console.ReadLine();
            ClientListener listener = new ClientListener();
            Console.WriteLine("Starting server...");
            Console.WriteLine("Press x to exit");
            while(Console.ReadLine() != "x")
            {

            }

        }
    }
}
