using System;
using BLL;
using DAL;
using Microsoft.Extensions.Configuration;
using System.IO;
using DTO;

namespace ConsoleApp
{
    class Program
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();
        static void Main(string[] args)
        {
            var staffDbManager = new StaffManager(Configuration);
            var customerDbManager = new CredentialsManager(Configuration);


            /*
            Console.WriteLine("--GET 1 staff--");
            Staff staff = staffDbManager.GetStaff(1);
            Console.WriteLine("Check db");
            Console.WriteLine(staff.name);
            */



                    Console.WriteLine("Username");
                    string usernameC = Console.ReadLine();


                    Console.WriteLine("Password");
                    string passwordC = Console.ReadLine();


                    int idCustomerTryingToConnect = customerDbManager.GetIdCredentials(usernameC);

                    //En fonction de l'id du customer
                    while (passwordC != customerDbManager.GetPassword(idCustomerTryingToConnect, usernameC))
                    {

                        Console.WriteLine(passwordC);
                        Console.WriteLine("Connection denied. Try again");

                        Console.WriteLine("Username");
                        usernameC = Console.ReadLine();

                        Console.WriteLine("Password");
                        passwordC = Console.ReadLine();

                        idCustomerTryingToConnect = customerDbManager.GetIdCredentials(usernameC);
                    }

                    Console.WriteLine("Connection successful");

                    //Program.Suite(idCustomerTryingToConnect);


                

            

        }
    }
}
