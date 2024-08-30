using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using MissingNumber;
using System;

namespace MissingNumber
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length > 0 && int.TryParse(args[0], out int number) && number > 0 && number <= 100)
            {

                var numberSet = new NaturalNumberSet();
                numberSet.Extract(number);
                Console.WriteLine($"Número extraído: {number}");
                Console.WriteLine($"Número faltante calculado: {numberSet.CalculateMissingNumber()}");
            }
            else
            {
                CreateHostBuilder(args).Build().Run();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Program>();
                });
    }
}
