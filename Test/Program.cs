using System;
using NewLife.IO;
using NewLife.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using NewLife.Net.DNS;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
#if !DEBUG
                try
                {
#endif
                    Test1();
#if !DEBUG
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
#endif

                Console.WriteLine("OK!");
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key != ConsoleKey.C) break;
            }
        }

        static void Test1()
        {
            var file = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.bin").LastOrDefault();
            var buf = File.ReadAllBytes(file);

            var entity = DNSEntity.Read(buf);
            Console.WriteLine(entity);
        }

        static void Test2()
        {
        }
    }
}
