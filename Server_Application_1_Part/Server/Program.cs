using BASE_MSQL.Classes;
using Server.Classes;
using System;
using System.Net;
using System.Net.Sockets;

class Program
{
    static void Main(string[] args)
    {
        Connect connect = new Connect();
        connect.StartTheServer();
        connect.WaitUser();
    }
}