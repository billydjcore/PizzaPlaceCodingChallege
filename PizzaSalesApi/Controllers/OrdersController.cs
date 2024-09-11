using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaPlace.Api.Data;
using PizzaPlace.Api.Services;
using PizzaPlaceApi.Data;
using PizzaPlaceApi.Data.DTO;
using PizzaPlaceApi.Data.Models;

namespace PizzaPlace.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    //[Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            IEnumerable<Order>? orderList = await _orderService.Getorders();
            if (orderList == null)
                orderList = new List<Order>();

            return orderList.ToList();
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int? id)
        {
            if (id == null)
                return BadRequest();

            Order? order = await _orderService.GetOrder(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int? id, Order updatedOrder)
        {
            if (id == null)
                return BadRequest();

            if (updatedOrder == null)
                return BadRequest();

            if (id != updatedOrder.order_id)
            {
                return BadRequest();
            }
            
            try
            {
                bool isUpdated = await _orderService.PutOrder(id, updatedOrder);
                if (!isUpdated)
                {
                    return Problem(detail: "Update order failed", title: "PutOrder", statusCode: 304);
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Order>> AddOrder(OrderRequest order)
        {
            if (order == null)
                return BadRequest();
            if (order.order_id == null)
                return BadRequest();
            if (string.IsNullOrEmpty(order.date))
                return BadRequest();
            if (string.IsNullOrEmpty(order.time))
                return BadRequest();

            Order? newOrder = new Order();
            //DateTime orderDate = Convert.ToDateTime(order.date).Add(TimeSpan.Parse(order.time));
            newOrder.date = order.date;
            newOrder.time = order.time;
            Order? createdOrder = await _orderService.PostOrder(newOrder);
            if (createdOrder == null)
                return Problem(detail: "Add order failed", title: "PostOrder", statusCode: 400);

            return CreatedAtAction("PostOrder", new { id = createdOrder.order_id }, createdOrder);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int? id)
        {
            if (id == null)
                return BadRequest();

            bool isDeleted = await _orderService.DeleteOrder(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }

        private bool OrderExists(int? id)
        {
            return _orderService.OrderExists(id);
        }
    }
}
