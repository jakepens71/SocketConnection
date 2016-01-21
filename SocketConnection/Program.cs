using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketConnection
{
    class Program
    {
        static Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        static bool connectionEstablished = false;

        static void Main(string[] args)
        {
            string host = "192.168.213.128";

            

            while (connectionEstablished == false)
            {
                Console.WriteLine("Establishing Connection to {0}", host);
                establishConnection(host, 9);
            }



            Console.ReadLine();


        }

        public static void establishConnection(string host, int port)
        {
            IPAddress[] IPs = Dns.GetHostAddresses(host);

            try
            {
                s.Connect(IPs[0], 80);


                //Console.WriteLine(hostName);

                Console.WriteLine("Connection Established");
                connectionEstablished = true;
            }
            catch (SystemException ex)
            {
                Console.WriteLine("Error occured");
            }

            
        }

    }
}
