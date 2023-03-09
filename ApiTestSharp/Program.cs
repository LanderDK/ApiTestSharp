using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Security.Principal;
using BlitzWare.Utilities;
using System.Diagnostics;

namespace BlitzWare
{
    class Program
    {
        static void Main(string[] args)
        {
            API.OnProgramStart.Initialize("BlitzWare Test", "3f842f1ad6f7eeace6a87bbe51a00e15db6642b354a420eeba105c2fbd0eda2b", "1.0");

            Misc.RandomTitle();
            Misc.Logo1();
            Console.WriteLine("\n[1] Login");
            Console.WriteLine("[2] Register");
            Console.WriteLine("[3] Extend Subscription");
            Console.WriteLine("\nOption:");
            string option = Console.ReadLine();

            if (option == "1")
            {
                Console.Clear();
                Misc.Logo1();
                Console.Write("\nUsername: ");
                string username = Console.ReadLine();
                Console.Write("\nPassword: ");
                string password = Console.ReadLine();

                if (API.Login(username, password))
                {
                    MessageBox.Show("Successfully Logged In!", API.OnProgramStart.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Console.Clear();
                    Misc.Logo1();
                    Console.WriteLine("ID: " + API.User.ID);
                    Console.WriteLine("Username: " + API.User.Username);
                    Console.WriteLine("Email: " + API.User.Email);
                    Console.WriteLine("Subscription Expiry: " + API.User.Expiry);
                    Console.WriteLine("HWID: " + API.User.HWID);
                    Console.WriteLine("Last Login: " + API.User.LastLogin);
                    Console.WriteLine("IP: " + API.User.IP);
                    Console.ReadLine();
                }
                else
                {
                    Process.GetCurrentProcess().Kill();
                }
            }
            else if (option == "2")
            {
                Console.Clear();
                Misc.Logo1();
                Console.Write("\nUsername: ");
                string username = Console.ReadLine();
                Console.Write("\nPassword: ");
                string password = Console.ReadLine();
                Console.Write("\nEmail: ");
                string email = Console.ReadLine();
                Console.Write("\nLicense: ");
                string license = Console.ReadLine();

                if (API.Register(username, password, email, license))
                {
                    MessageBox.Show("Successfully Registered!", API.OnProgramStart.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Console.ReadLine();
                }
                else
                {
                    Console.ReadLine();
                    Process.GetCurrentProcess().Kill();
                }
            }
            else if (option == "3")
            {
                Console.Clear();
                Misc.Logo1();
                Console.Write("\nUsername: ");
                string username = Console.ReadLine();
                Console.Write("\nPassword: ");
                string password = Console.ReadLine();
                Console.Write("\nLicense: ");
                string license = Console.ReadLine();

                if (API.ExtendSub(username, password, license))
                {
                    MessageBox.Show("Successfully Extended Your Subscription!", API.OnProgramStart.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Console.ReadLine();
                }
                else
                {
                    Process.GetCurrentProcess().Kill();
                }
            }
        }
    }
}
