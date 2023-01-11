using CsvHelper;
using CsvHelper.Configuration;
using Data;
using Models;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Services.ServicesForModels
{
    public class CustomerService
    {
        private AppDbContext _context;
        public CustomerService(AppDbContext context)
        {

            _context = context;
        }


        public void SaveCustomersToDb()
        {
            String filePath = @"C:\Users\Raissa\source\repos\Global_Superstore_ApiProject\Services\Files\Global_Superstore2.csv";

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ","
            };
            //07.12.22г.
            using (StreamReader streamReader = new StreamReader(filePath))
            using (var csvReader = new CsvReader(streamReader, config))
            {
                var records = csvReader.GetRecords<AllTablesModel>().ToList();

                records.ForEach(delegate (AllTablesModel currentResult)
                {
                    Customer customer = new Customer();
                    customer.CustomerID = currentResult.CustomerID;
                    customer.CustomerName = currentResult.CustomerName;
                    customer.Segment = currentResult.Segment;
                });
            }
        }

        public void AddCustomer(Customer customer)
        {
            var _customer = new Customer()
            {
                CustomerID = customer.CustomerID,
                CustomerName = customer.CustomerName,
                Segment = customer.Segment

            };
            _context.Customers.Add(_customer);
            _context.SaveChanges();
        }

        //GetAll
        public List<Customer> GetAllCustomers() => _context.Customers.ToList();

        //GetById
        public Customer GetCustomersById(int customerId) => _context.Customers.Where(n => n.Id == customerId).FirstOrDefault();

        //Update
        public Customer UpdateCustomersById(int customerId, CustomerVM customer)
        {
            var _customer = _context.Customers.FirstOrDefault(n => n.Id == customerId);
            if (_customer != null)
            {
                _customer.CustomerName = customer.CustomerName;
                _customer.CustomerName = customer.CustomerName;
                _customer.Segment = customer.Segment;
                _context.SaveChanges();
            }
            return _customer;
        }

        //Delete
        public void DeleteCustomerById(int customerId)
        {
            var _customer = _context.Customers.FirstOrDefault(n => n.Id == customerId);
            if (_customer != null)
            {
                _context.Customers.Remove(_customer);
                _context.SaveChanges();
            }
        }
    }
}

