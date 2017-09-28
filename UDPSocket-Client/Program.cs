using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;

namespace UDPSocket_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Khoi tao client!");
            //b1 xac dinh ip server
            IPEndPoint ipServer = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
            //b2 tao socket
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            //b3 gui nhan data
            Console.WriteLine("Client gui data:");
            EndPoint epServer = (EndPoint)ipServer;
            try
            {
                byte[] send = Encoding.ASCII.GetBytes("Hello server!");    
                client.SendTo(send, epServer);
                byte[] rec = new byte[25];
                client.ReceiveFrom(rec, ref epServer);
                Console.WriteLine("Client nhan data: {0}", Encoding.ASCII.GetString(rec));
            }
            catch(Exception ex)
            {
                Console.WriteLine("Khong the ket noi server!");
                Console.Write(ex);
            }
           
            //b4 dong client socket
            client.Close();
        }
    }
}
