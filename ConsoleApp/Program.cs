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

            //Get all hotels
            Console.WriteLine("--GET 1 staff--");
            Staff staff = staffDbManager.GetStaff(1);
            Console.WriteLine("Check db");
            Console.WriteLine(staff.name);

        }
    }
}
