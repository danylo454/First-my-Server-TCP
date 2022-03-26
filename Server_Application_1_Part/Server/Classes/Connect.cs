using BASE_MSQL.Classes;
using BASE_MSQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.Classes
{
    public class Connect
    {
        private const int PORT = 8080;
        private Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private IPAddress iPAddress = IPAddress.Any;
        public void StartTheServer()
        {
            IPEndPoint portEP = new IPEndPoint(iPAddress, PORT);
            socket.Bind(portEP);
            socket.Listen(5);
            WaitUser();
        }
        public void WaitUser()
        {
            string userMessage = $"1)See all products{Environment.NewLine}2)Show Intel products{Environment.NewLine}3)Show AMDcproducts{Environment.NewLine}4)Exit{Environment.NewLine}";
            Socket client = socket.Accept();
            byte[] buffer = new byte[1024];
            int numberOfRecivedBytes = 0;
            while (true)
            {
                byte[] msg = Encoding.ASCII.GetBytes(userMessage);
                client.Send(msg);
                Thread.Sleep(100);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(new String('=', 30));
                Console.ForegroundColor = ConsoleColor.White;
                try
                {
                    Console.OutputEncoding = Encoding.UTF8;
                    numberOfRecivedBytes = client.Receive(buffer);
                    string resivedDate = Encoding.ASCII.GetString(buffer, 0, numberOfRecivedBytes);
                    Console.Write($"Data from client: ");
                    Console.WriteLine(resivedDate);
                    if (resivedDate.Trim() == "1")
                    {
                        string messege = string.Empty;
                        List<Goods> goods = GoodsRepository.GetAllGoods();
                        foreach (var item in goods)
                        {
                            messege += $"{item.Id}){item.Name}  |  {item.Models}  |  {item.Count}  |  {item.Price}{Environment.NewLine}";
                            Console.WriteLine(item.Name + "\t" + item.Models);
                        }
                        byte[] mes = Encoding.ASCII.GetBytes(messege);
                        client.Send(mes);
                    }
                    else if (resivedDate.Trim() == "2")
                    {
                        string messege = string.Empty;
                        List<Goods> goods = GoodsRepository.GetAllGoods();
                        List<Goods> intel = goods.Where(p => p.Models.StartsWith("Intel")).ToList();
                        foreach (var item in intel)
                        {
                            messege += $"{item.Id}){item.Name}  |  {item.Models}  |  {item.Count}  |  {item.Price}{Environment.NewLine}";
                            Console.WriteLine(item.Name + "\t" + item.Models);
                        }
                        messege += Environment.NewLine;
                        byte[] mes = Encoding.ASCII.GetBytes(messege);
                        client.Send(mes);

                    }
                    else if (resivedDate.Trim() == "3")
                    {
                        string messege = string.Empty;
                        List<Goods> goods = GoodsRepository.GetAllGoods();
                        List<Goods> amd = goods.Where(p => p.Models.StartsWith("AMD")).ToList();
                        foreach (var item in amd)
                        {
                            messege += $"{item.Id}){item.Name}  |  {item.Models}  |  {item.Count}  |  {item.Price}{Environment.NewLine}";
                            Console.WriteLine(item.Name + "\t" + item.Models);
                        }
                        messege += Environment.NewLine;
                        byte[] mes = Encoding.ASCII.GetBytes(messege);
                        client.Send(mes);
                    }
                    else if (resivedDate.Trim() == "4")
                    {
                        Console.WriteLine("user disconnect");
                        client.Close();
                        client.Dispose();
                        break;
                    }
                    Array.Clear(buffer, 0, buffer.Length);
                    numberOfRecivedBytes = 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    client.Close();
                    client.Dispose();
                    break;
                }

            }
        }
    }
}
