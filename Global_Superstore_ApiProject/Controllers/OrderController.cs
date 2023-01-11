using CsvHelper.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Models.ViewModels;
using Services.ServicesForModels;
using System;
using System.Globalization;
using System.IO;

namespace Global_Superstore_ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public OrderService _orderService;


        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [Authorize(Roles = "admin, user")]
        [HttpGet("get-all-orders")]
        public IActionResult GetAllOrders()
        {
            var allOrders = _orderService.GetAllOrders();
            return Ok(allOrders);
        }

        [Authorize(Roles = "admin, user")]
        [HttpGet("get-orders-by-id/{id}")]
        public IActionResult GetOrdersById(int id)
        {
            var orders = _orderService.GetOrdersById(id);
            return Ok(orders);
        }

        [Authorize(Roles = "admin")]
        [HttpPost("add-order")]
        public IActionResult AddOrder([FromBody] Order order)
        {
            _orderService.AddOrder(order);
            return Ok();
        }

        [Authorize(Roles = "admin")]
        [HttpPut("update-order-by-id/{id}")]
        public IActionResult UpdateOrderById(int id, [FromBody] OrderVM order)
        {
            var updateOrder = _orderService.UpdateOrdersById(id, order);
            return Ok(updateOrder);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("delete-orders-by-id/{id}")]
        public IActionResult DeleteOrderById(int id)
        {
            _orderService.DeleteOrderById(id);
            return Ok();
        }
    }
}
