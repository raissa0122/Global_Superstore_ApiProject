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
    public class ProductService
    {
        private AppDbContext _context;
        public ProductService(AppDbContext context)
        {

            _context = context;
        }


        public void SaveProductsToDb()
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
                    Product product = new Product();
                    product.ProductName = currentResult.ProductName;
                    product.Category = currentResult.Category;
                    product.SubCategory = currentResult.Sub_Category;
                    product.ProductID = currentResult.ProductID;
                });
            }
        }

        public void AddProduct(Product product)
        {
            var _product = new Product()
            {
                ProductName = product.ProductName,
                Category = product.Category,
                SubCategory = product.SubCategory,
                ProductID = product.ProductID,

            };
            _context.Products.Add(_product);
            _context.SaveChanges();
        }

        //GetAll
        public List<Product> GetAllProducts() => _context.Products.ToList();

        //GetById
        public Product GetProductsById(int productId) => _context.Products.FirstOrDefault(n => n.Id == productId);

        //Update
        public Product UpdateProductsById(int productId, ProductVM product)
        {
            var _product = _context.Products.FirstOrDefault(n => n.Id == productId);
            if (_product != null)
            {
                _product.ProductName = product.ProductName;
                _product.Category = product.Category;
                _product.SubCategory = product.SubCategory;
                _product.ProductID = product.ProductID;
                _context.SaveChanges();
            }
            return _product;
        }

        //Delete
        public void DeleteProductById(int productId)
        {
            var _product = _context.Products.FirstOrDefault(n => n.Id == productId);
            if (_product != null)
            {
                _context.Products.Remove(_product);
                _context.SaveChanges();
            }
        }
    }
}

