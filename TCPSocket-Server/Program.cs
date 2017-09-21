using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace TCPSocket_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            //b1 tao socket
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //b2 gan socket voi card mang
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
            server.Bind(ipe);
            //b3 lang nghe
            server.Listen(1);
            //b4 chap nhan ket noi client
            Socket client = server.Accept();
            //b5 truyen nhan
            byte[] rec = new byte[1024];
            int num = client.Receive(rec);
            string a = Encoding.ASCII.GetString(rec,0,num);
            Console.WriteLine("Server nhan: {0}", a);

            string s = "hello client!";
            byte[] send = new byte[1024];
            send = Encoding.ASCII.GetBytes(s);
            client.Send(send, s.Length, SocketFlags.None);
            //b6 dong socket
            client.Close();
            Console.ReadKey();
        }
    }
}
