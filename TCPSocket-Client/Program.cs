using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace TCPSocket_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //b1 xac dinh dia chi server
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
            //b2 tao socket
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //b3 ket noi toi server
            client.Connect(ip);
            //b4 truyen nhan du lieu
            string s = "hello server!";
            byte[] send = new byte[1024];
            send = Encoding.ASCII.GetBytes(s);
            client.Send(send, s.Length, SocketFlags.None);

            byte[] rec = new byte[1024];
            int num = client.Receive(rec);
            string a = Encoding.ASCII.GetString(rec, 0, num);
            Console.WriteLine("client nhan: {0}", a);
            //b5 dong socket
            client.Close();
            Console.ReadKey();
        }
    }
}
