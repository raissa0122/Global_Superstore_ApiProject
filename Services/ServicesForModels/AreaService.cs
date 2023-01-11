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
    public class AreaService
    {
        private AppDbContext _context;
       public AreaService(AppDbContext context)
        {

            _context = context;
        }



        //change repo position from controller to service 
        public void SaveAreasToDb()
        {
            String filePath = @"C:\Users\Raissa\source\repos\Global_Superstore_ApiProject\Services\Files\Global_Superstore2.csv";

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ",",
                MissingFieldFound = null
            };
            //07.12.22г.
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
                    
                   
                    var checkForCustomer = false;
                    var checkForContinent = false;
                    var checkForCountry = false;
                    var checkForProduct = false;
                    var checkForOrder = false;

                 
                    //Customer
                    for (int i = 0; i < _context.Customers.Count(); i++)
                    {
                        var currentCustomer = _context.Customers.ToList().ElementAt(i);
                        if (currentCustomer.CustomerName == currentResult.CustomerName)
                        {
                            area.CustomerId = currentCustomer.Id;
                            checkForCustomer = true;
                        }
                    }
                    //ContinentsCheck
                    for (int i = 0; i < _context.Continents.Count(); i++)
                    {
                        var currentContinent = _context.Continents.ToList().ElementAt(i);
                        if (currentContinent.ContinentName == currentResult.Region)
                        {
                            area.ContinentId = currentContinent.Id;
                            checkForContinent = true;
                        }
                    }
                    //CountriesCheck
                    for (int i = 0; i < _context.Countries.Count(); i++)
                    {
                        var currentCountry = _context.Countries.ToList().ElementAt(i);
                        if (currentCountry.CountryName == currentResult.Country)
                        {
                            area.CountryId = currentCountry.Id;
                            checkForCountry = true;
                        }
                    }
                    //ProductsCheck
                    for (int i = 0; i < _context.Products.Count(); i++)
                    {
                        var currentProduct = _context.Products.ToList().ElementAt(i);
                        if (currentProduct.ProductName == currentResult.ProductName)
                        {
                            area.ProductId = currentProduct.Id;
                            checkForProduct = true;
                        }
                    }
                    //OrdersCheck
                    for (int i = 0; i < _context.Orders.Count(); i++)
                    {
                        var currentOrder = _context.Orders.ToList().ElementAt(i);
                        if (currentOrder.OrderDate == currentResult.OrderDate)
                        {
                            area.OrderId = currentOrder.Id;
                            checkForOrder = true;
                        }
                    }



                    //!CustomerCheck
                    if (checkForCustomer == false)
                    {
                        Customer customer = new Customer();
                        customer.CustomerName = currentResult.CustomerName;
                        customer.CustomerID = currentResult.CustomerID;
                        customer.Segment = currentResult.Segment;


                        _context.Customers.Add(customer);
                        _context.SaveChanges();

                        area.CustomerId = customer.Id;
                    }
                  //!ContinentCheck
                    if (checkForContinent == false)
                    {
                        Continent continent = new Continent();
                        continent.ContinentName = currentResult.Region;

                        _context.Continents.Add(continent);
                        _context.SaveChanges();

                        area.ContinentId = continent.Id;
                    }                  
                    //!CountryCheck
                    if (checkForCountry == false)
                    {
                       Country country = new Country();
                        country.CountryName = currentResult.Country;

                        _context.Countries.Add(country);
                        _context.SaveChanges();

                        area.CountryId = country.Id;
                    }                 
                    //!ProductCheck
                    if (checkForProduct == false)
                    {
                        Product product = new Product();
                        product.ProductName = currentResult.ProductName;
                        product.Category = currentResult.Category;
                        product.SubCategory = currentResult.Sub_Category;
                        product.ProductID = currentResult.ProductID;


                        _context.Products.Add(product);
                        _context.SaveChanges();

                        area.ProductId = product.Id;
                    }
                    //!OrdersCheck
                    if (checkForOrder == false)
                    {
                        Order order = new Order();
                        order.SalesCount = currentResult.Sales;
                        order.Quantity = currentResult.Quantity;
                        order.Discount = currentResult.Discount;
                        order.Profit = currentResult.Profit;
                        order.ShippingCost = currentResult.ShippingCost;
                        order.OrderPriority = currentResult.OrderPriority;
                        order.OrderID = currentResult.OrderID;
                        order.OrderDate = currentResult.OrderDate;
                        order.ShipDate = currentResult.ShipDate;
                        order.ShipMode = currentResult.ShipMode;


                        _context.Orders.Add(order);
                        _context.SaveChanges();

                        area.OrderId = order.Id;
                    }
                    var checkIsItHere = false;
                    for (int i = 0; i < _context.Areas.Count(); i++)
                    {
                        var currentArea = _context.Areas.ToList().ElementAt(i);
                        if (currentArea.Sity == area.Sity)
                        {
                            checkIsItHere = true;
                        }
                    }

                    if (checkIsItHere == false)
                    {
                        _context.Areas.Add(area);
                        _context.SaveChanges();
                      // AddArea(area);
                    }
                });
            }
        }


        public void AddArea(Area area)
        {
            var _area = new Area()
            {
                Sity = area.Sity,
                State = area.State,
                PostCode = area.PostCode,
                Market = area.Market
            };
            _context.Areas.Add(_area);
            _context.SaveChanges();
        }

        //GetAll
        public List<Area> GetAllAreas() => _context.Areas.ToList();

        //GetById
        public Area GetAreaById(int areaId) => _context.Areas.FirstOrDefault(n => n.Id == areaId);
        
        //Update
        public Area UpdateAreaById(int areaId, AreaVM area)
        {
            var _area = _context.Areas.FirstOrDefault(n => n.Id == areaId);
            if (_area != null)
            {
                _area.Sity = area.Sity;
                _area.State = area.State;
                _area.PostCode = area.PostCode;
                _area.Market = area.Market;
                _context.SaveChanges();
            }
            return _area;   
        }
        
        //Delete
        public void DeleteAreaById(int areaId)
        {
            var _area = _context.Areas.FirstOrDefault(n => n.Id == areaId);
            if(_area != null)
            {
                _context.Areas.Remove(_area);
                _context.SaveChanges();
            }
        }
    }
}
