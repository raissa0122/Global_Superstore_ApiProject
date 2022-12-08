using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using CsvHelper;
using System.Globalization;
using Models.ViewModels ;
using CsvHelper.Configuration;
using Data;
using Models;


namespace Global_Superstore_ApiProject
{
    public class Program
    {
        public AppDbContext _context;
        public static void Main(string[] args)
        {
            String resultOfLine;
            String filePath = @"C:\Files\Global_Superstore2.csv";

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ","
            };

            using (StreamReader streamReader = new StreamReader(filePath))
            using (var csvReader = new CsvReader(streamReader, config))
            {
                var records = csvReader.GetRecords<AllTablesModel>().ToList();
                    
                records.ForEach(delegate (AllTablesModel currentResult)
                {
                    Area area = new Area();
                    area.Sity = currentResult.City;
                    area.State = currentResult.State;
                   

                });
            }

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
