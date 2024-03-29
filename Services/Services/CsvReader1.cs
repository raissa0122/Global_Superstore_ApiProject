﻿using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Services.ServicesForModels;

namespace Services 
{
    public class CsvReader1 : ICsvService
    {

     public List<Area> ReadAreasFromFile(string filename)
        {
            String resultOfLine;

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ","
            };

            using (StreamReader streamReader = new StreamReader (filename))
            // using (var reader = new StreamReader(@"C:\Users\Raissa\source\repos\Global_Superstore_ApiProject\Services\bin\Debug\net5.0\Files\Global_Superstore2.csv"))
            using (var csvReader = new CsvReader(streamReader, config))
            {
                var records = csvReader.GetRecords<Area>().ToList();
                return records;
            }

           
        }

        public List<Continent> ReadContinentsFromFile(string filename)
        {
            String resultOfLine;

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ","
            };

            using (StreamReader streamReader = new StreamReader(filename))
            // using (var reader = new StreamReader(@"C:\Users\Raissa\source\repos\Global_Superstore_ApiProject\Services\bin\Debug\net5.0\Files\Global_Superstore2.csv"))
            using (var csvReader = new CsvReader(streamReader, config))
            {
                var records = csvReader.GetRecords<Continent>().ToList();
                return records;
            }


        }

        public List<Country> ReadCountriesFromFile(string filename)
        {
            String resultOfLine;

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ","
            };

            using (StreamReader streamReader = new StreamReader(filename))
            // using (var reader = new StreamReader(@"C:\Users\Raissa\source\repos\Global_Superstore_ApiProject\Services\bin\Debug\net5.0\Files\Global_Superstore2.csv"))
            using (var csvReader = new CsvReader(streamReader, config))
            {
                var records = csvReader.GetRecords<Country>().ToList();
                return records;
            }


        }

        public List<Customer> ReadCustomersFromFile(string filename)
        {
            String resultOfLine;

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ","
            };

            using (StreamReader streamReader = new StreamReader(filename))
            // using (var reader = new StreamReader(@"C:\Users\Raissa\source\repos\Global_Superstore_ApiProject\Services\bin\Debug\net5.0\Files\Global_Superstore2.csv"))
            using (var csvReader = new CsvReader(streamReader, config))
            {
                var records = csvReader.GetRecords<Customer>().ToList();
                return records;
            }


        }

        public List<Order> ReadOrdersFromFile(string filename)
        {
            String resultOfLine;

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ","
            };

            using (StreamReader streamReader = new StreamReader(filename))
            // using (var reader = new StreamReader(@"C:\Users\Raissa\source\repos\Global_Superstore_ApiProject\Services\bin\Debug\net5.0\Files\Global_Superstore2.csv"))
            using (var csvReader = new CsvReader(streamReader, config))
            {
                var records = csvReader.GetRecords<Order>().ToList();
                return records;
            }


        }

        public List<Product> ReadProductsFromFile(string filename)
        {
            String resultOfLine;

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ","
            };

            using (StreamReader streamReader = new StreamReader(filename))
            // using (var reader = new StreamReader(@"C:\Users\Raissa\source\repos\Global_Superstore_ApiProject\Services\bin\Debug\net5.0\Files\Global_Superstore2.csv"))
            using (var csvReader = new CsvReader(streamReader, config))
            {
                var records = csvReader.GetRecords<Product>().ToList();
                return records;
            }


        }
    }
}
