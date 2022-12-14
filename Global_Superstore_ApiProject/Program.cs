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
using Models.ViewModels;
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
                Delimiter = ",",
                HasHeaderRecord = true,
                
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
                    area.PostCode = currentResult.PostalCode;
                    area.Market = currentResult.Market;
                });

                records.ForEach(delegate (AllTablesModel currentResult)
                {
                    Continents continents = new Continents();
                    continents.ContinentName = currentResult.Region;
                });
                records.ForEach(delegate (AllTablesModel currentResult)
                {
                    Countries countries = new Countries();
                    countries.CountryName = currentResult.Country;
                });
                records.ForEach(delegate (AllTablesModel currentResult)
                {
                    Customer customer = new Customer();
                    customer.CustomerID = currentResult.CustomerID;
                    customer.CustomerName = currentResult.CustomerName;
                    customer.Segment = currentResult.Segment;
                });
                records.ForEach(delegate (AllTablesModel currentResult)
                {
                    Product product = new Product();
                    product.ProductName = currentResult.ProductName;
                    product.Category = currentResult.Category;
                    product.SubCategory = currentResult.Sub_Category;
                    product.ProductID = currentResult.ProductID;
                });
                records.ForEach(delegate (AllTablesModel currentResult)
                {
                    Sales sales = new Sales();
                    sales.SalesCount = currentResult.Sales;
                    sales.Quantity = currentResult.Quantity;
                    sales.Discount = currentResult.Discount;
                    sales.Profit = currentResult.Profit;
                    sales.ShippingCost = currentResult.ShippingCost;
                    sales.OrderPriority = currentResult.OrderPriority;
                    sales.OrderID = currentResult.OrderID;
                    sales.OrderDate = currentResult.OrderDate;
                    sales.ShipDate = currentResult.ShipDate;
                    sales.ShipMode = currentResult.ShipMode;
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
