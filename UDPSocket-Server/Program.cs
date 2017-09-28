using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace UDPSocket_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Khoi tao server!");
            //b1 tao socket udp
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint ip = new IPEndPoint(IPAddress.Any, 12345); 
            //b2 ket noi socket voi card mang
            server.Bind(ip);
            //b3 gui nhan data
            //server phai nhan data truoc
            byte[] rec = new byte[25];
            EndPoint client = (EndPoint)ip;
            server.ReceiveFrom(rec, ref client);
            Console.WriteLine("Server nhan data: {0}", Encoding.ASCII.GetString(rec));
            Console.WriteLine("Server gui data!");
            byte[] send = Encoding.ASCII.GetBytes("Hello client!");
            server.SendTo(send, client);
            //b4 dong server socket
            server.Close();
        }
    }
}
