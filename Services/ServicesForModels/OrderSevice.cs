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
using System.Text;
using System.Threading.Tasks;

namespace Services.ServicesForModels
{
    public class OrderService
    {
        private AppDbContext _context;
        public OrderService(AppDbContext context)
        {

            _context = context;
        }


        public void SaveOrdersToDb()
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
                });
            }
        }

        public void AddOrder(Order order)
        {
            var _order = new Order()
            {
                SalesCount = order.SalesCount,
                Quantity = order.Quantity,
                Discount = order.Discount,
                Profit = order.Profit,
                ShippingCost = order.ShippingCost,
                OrderPriority = order.OrderPriority,
                OrderID = order.OrderID,
                OrderDate = order.OrderDate,
                ShipDate = order.ShipDate,
                ShipMode = order.ShipMode,
            };
            _context.Orders.Add(_order);
            _context.SaveChanges();
        }

        //GetAll
        public List<Order> GetAllOrders() => _context.Orders.ToList();

        //GetById
        public Order GetOrdersById(int orderId) => _context.Orders.FirstOrDefault(n => n.Id == orderId);

        //Update
        public Order UpdateOrdersById(int orderId, OrderVM order)
        {
            var _order = _context.Orders.FirstOrDefault(n => n.Id == orderId);
            if (_order != null)
            {
                _order.SalesCount = order.SalesCount;
                _order.Quantity = order.Quantity;
                _order.Discount = order.Discount;
                _order.Profit = order.Profit;
                _order.ShippingCost = order.ShippingCost;
                _order.OrderPriority = order.OrderPriority;
                _order.OrderID = order.OrderID;
                _order.OrderDate = order.OrderDate;
                _order.ShipDate = order.ShipDate;
                _order.ShipMode = order.ShipMode;

                _context.SaveChanges();
            }
            return _order;
        }

        //Delete
        public void DeleteOrderById(int orderId)
        {
            var _order = _context.Orders.FirstOrDefault(n => n.Id == orderId);
            if (_order != null)
            {
                _context.Orders.Remove(_order);
                _context.SaveChanges();
            }
        }
    }
}

