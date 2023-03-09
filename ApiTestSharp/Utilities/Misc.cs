using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlitzWare.Utilities
{
    public static class Misc
    {
        public static void Logo1()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("██████╗░██╗░░░░░██╗████████╗███████╗░██╗░░░░░░░██╗░█████╗░██████╗░███████╗");
            Console.WriteLine("██╔══██╗██║░░░░░██║╚══██╔══╝╚════██║░██║░░██╗░░██║██╔══██╗██╔══██╗██╔════╝");
            Console.WriteLine("██████╦╝██║░░░░░██║░░░██║░░░░░███╔═╝░╚██╗████╗██╔╝███████║██████╔╝█████╗░░");
            Console.WriteLine("██╔══██╗██║░░░░░██║░░░██║░░░██╔══╝░░░░████╔═████║░██╔══██║██╔══██╗██╔══╝░░");
            Console.WriteLine("██████╦╝███████╗██║░░░██║░░░███████╗░░╚██╔╝░╚██╔╝░██║░░██║██║░░██║███████╗");
            Console.WriteLine("╚═════╝░╚══════╝╚═╝░░░╚═╝░░░╚══════╝░░░╚═╝░░░╚═╝░░╚═╝░░╚═╝╚═╝░░╚═╝╚══════╝");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine();
        }
        public static void Logo2()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("██████╗░██╗░░░░░██╗████████╗███████╗░██╗░░░░░░░██╗░█████╗░██████╗░███████╗");
            Console.WriteLine("██╔══██╗██║░░░░░██║╚══██╔══╝╚════██║░██║░░██╗░░██║██╔══██╗██╔══██╗██╔════╝");
            Console.WriteLine("██████╦╝██║░░░░░██║░░░██║░░░░░███╔═╝░╚██╗████╗██╔╝███████║██████╔╝█████╗░░");
            Console.WriteLine("██╔══██╗██║░░░░░██║░░░██║░░░██╔══╝░░░░████╔═████║░██╔══██║██╔══██╗██╔══╝░░");
            Console.WriteLine("██████╦╝███████╗██║░░░██║░░░███████╗░░╚██╔╝░╚██╔╝░██║░░██║██║░░██║███████╗");
            Console.WriteLine("╚═════╝░╚══════╝╚═╝░░░╚═╝░░░╚══════╝░░░╚═╝░░░╚═╝░░╚═╝░░╚═╝╚═╝░░╚═╝╚══════╝");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine();
        }
        public static void RandomTitle()
        {
            {
                int size = 15;
                char[] chars = new char[62];
                string a = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
                chars = a.ToCharArray();

                RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();

                byte[] data = new byte[size];
                crypto.GetNonZeroBytes(data);

                StringBuilder result = new StringBuilder(size);

                foreach (byte b in data)
                    result.Append(chars[b % (chars.Length - 1)]);
                Console.Title = "" + result;

            }
        }
    }
}
