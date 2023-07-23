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
            API.OnProgramStart.Initialize("APP NAME", "APP SECRET", "APP VERSION");

            Misc.RandomTitle();
            Misc.Logo1();
            Console.WriteLine("\n[1] Login");
            Console.WriteLine("[2] Register");
            if (!API.ApplicationSettings.freeMode)
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
                Console.Write("\n2FA code (if enabled): ");
                string twoFactorCode = Console.ReadLine();

                if (API.Login(username, password, twoFactorCode))
                {
                    MessageBox.Show("Successfully Logged In!", API.OnProgramStart.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    API.Log(API.User.Username, "User logged in");
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
                    //do code that you want
                    Console.WriteLine("Press 1 to enable 2FA, press 2 to disable 2FA:");
                    option = Console.ReadLine();
                    if (option == "1")
                    {
                        API.CreateQRCode();
                        Console.WriteLine("QR Code:");
                        twoFactorCode = Console.ReadLine();
                        API.Verify2FA(twoFactorCode);
                        Console.ReadLine();
                    }
                    else if (option == "2")
                    {
                        Console.WriteLine("QR Code:");
                        twoFactorCode = Console.ReadLine();
                        API.Disable2FA(twoFactorCode);
                        Console.ReadLine();
                    }
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
                string license = "N/A";
                if (!API.ApplicationSettings.freeMode)
                {
                    Console.Write("\nLicense: ");
                    license = Console.ReadLine();
                }

                if (API.Register(username, password, email, license))
                {
                    MessageBox.Show("Successfully Registered!", API.OnProgramStart.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    API.Log(API.User.Username, "User registered");
                    Console.ReadLine();
                    //do code that you want
                }
                else
                {
                    Console.ReadLine();
                    Process.GetCurrentProcess().Kill();
                }
            }
            if (!API.ApplicationSettings.freeMode)
            {
                if (option == "3")
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
                        API.Log(API.User.Username, "User extended");
                        Console.ReadLine();
                        //do code that you want
                    }
                    else
                    {
                        Process.GetCurrentProcess().Kill();
                    }
                }
            }
        }
    }
}