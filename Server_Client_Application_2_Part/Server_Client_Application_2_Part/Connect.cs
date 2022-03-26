using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server_Client_Application_2_Part
{
    public class Connect
    {
        private Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private IPAddress iPAddress = null;

        private const int port = 8080;
        public void ConnectToServer()
        {
            IPAddress.TryParse("127.0.0.1", out iPAddress);
            try
            {
                client.Connect(iPAddress, port);
                SendMessege();
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
            }
        }
        public void SendMessege()
        {
            string command = string.Empty;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(new String('=', 30));
                byte[] bufferRecived = new byte[1024];
                int recive = client.Receive(bufferRecived);
                string reciveText = Encoding.ASCII.GetString(bufferRecived, 0, recive);
                Console.WriteLine(reciveText);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Enter: ");
                string messege = Console.ReadLine();
                byte[] byfferSend = Encoding.ASCII.GetBytes(messege);
                client.Send(byfferSend);

                Console.ForegroundColor = ConsoleColor.Blue;
                byte[] bufferRecived2 = new byte[1024];
                int recive2 = client.Receive(bufferRecived2);
                string reciveText2 = Encoding.ASCII.GetString(bufferRecived2, 0, recive2);
                Console.WriteLine(reciveText2);
                Console.ForegroundColor = ConsoleColor.White;




            }
        }
    }
}
