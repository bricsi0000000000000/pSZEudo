using ContractStore.Models.People;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ContractStore.Models;

namespace ContractStore
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Person a = new Person();
            Person b = new Person();
            Person c = new Person();
            Person d = new Person();
            Person e = new Person();

            a.FirstName = "Patrik";
            b.FirstName = "Balazs";
            c.FirstName = "Richard";
            d.FirstName = "Gergo";
            e.FirstName = "Dora";

            PersonManager.addToList(a);
            PersonManager.addToList(b);
            PersonManager.addToList(c);
            PersonManager.addToList(d);
            PersonManager.addToList(e);

            Contract contract = new VehicleContract(a, b);
            contract.createPdf();


            Trace.WriteLine(PersonManager.getList()[0].FirstName);
            Trace.WriteLine(PersonManager.getList()[1].FirstName);
            Trace.WriteLine(PersonManager.getList()[2].FirstName);
            Trace.WriteLine(PersonManager.getList()[3].FirstName);
            Trace.WriteLine(PersonManager.getList()[4].FirstName);

            PersonManager.sortByFirstName();
            Trace.WriteLine(PersonManager.getList()[0].FirstName);
            Trace.WriteLine(PersonManager.getList()[1].FirstName);
            Trace.WriteLine(PersonManager.getList()[2].FirstName);
            Trace.WriteLine(PersonManager.getList()[3].FirstName);
            Trace.WriteLine(PersonManager.getList()[4].FirstName);

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
