using System;
using System.Collections.Generic;

namespace SolutionIP
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> ip, mark, net;
            Console.Write("IP: ");
            string[] ips = Console.ReadLine().Split('.');
            ip = new List<int>();
            for (int i = 0; i < ips.Length; i++)
                ip.Add(int.Parse(ips[i]));
            Console.Write("Subnet mark: ");
            string[] nets = Console.ReadLine().Split('.');
            mark = new List<int>();
            for (int i = 0; i < ips.Length; i++)
                mark.Add(int.Parse(nets[i]));

            net = new List<int>();
            for(int i=0;i<ip.Count;i++)
            {
                int temp = ip[i] & mark[i];
                net.Add(temp);
            }
            Console.Write("Net address: ");
            for (int i = 0; i < net.Count-1; i++)
                Console.Write(net[i] + ".");
            Console.Write(net[net.Count - 1]);
            Console.ReadKey();
        }
    }
}
