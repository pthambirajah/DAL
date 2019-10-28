using System;
using BLL;
using DAL;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

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
            var staffDb = new StaffDB(Configuration);

            //Get all hotels
            Console.WriteLine("--GET ALL HOTELS--");
            var staff = staffDbManager.GetStaff(1);
            Console.WriteLine(staff.name);

        }
    }
}
