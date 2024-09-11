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
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailsService _iOrderDetailsService;
        public OrderDetailsController(IOrderDetailsService  orderDetailsService)
        {
            _iOrderDetailsService = orderDetailsService;
        }

        // GET: api/OrderDetails
        [HttpGet("{orderId}")]
        public async Task<ActionResult<IEnumerable<OrderDetails>?>> GetListOfOrderDetails(int? orderId)
        {
            IEnumerable<OrderDetails>? orderDetailsList = await _iOrderDetailsService.GetListOfOrder_details(orderId);
            if (orderDetailsList == null)
                orderDetailsList = new List<OrderDetails>();

            return orderDetailsList.ToList();
        }

        // GET: api/OrderDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDetails>> GetOrderDetails(int? id)
        {
            if (id == null)
                return BadRequest();

            OrderDetails? orderDetail = await _iOrderDetailsService.GetOrderDetail(id);

            if (orderDetail == null)
            {
                return NotFound();
            }

            return orderDetail;
        }

        // PUT: api/OrderDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderDetails(int? id, OrderDetails? updatedOrderDetail)
        {
            if (id == null)
                return BadRequest();

            if (updatedOrderDetail == null)
                return BadRequest();

            if (string.IsNullOrEmpty(updatedOrderDetail.pizza_id))
            {
                return BadRequest();
            }

            try
            {
                bool isUpdated = await _iOrderDetailsService.PutOrderDetails(id, updatedOrderDetail);
                if (!isUpdated)
                {
                    return Problem(detail: "Update order failed", title: "PutOrder", statusCode: 304);
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderDetailsExists(id))
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

        // POST: api/OrderDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderDetails>> AddOrderDetails(OrderDetailsRequest? orderDetails)
        {
            if (orderDetails == null)
                return BadRequest();
            if (string.IsNullOrEmpty(orderDetails.pizza_id))
                return BadRequest();
            if (orderDetails.order_id == null)
                return BadRequest();
            if (orderDetails.quantity == null)
                return BadRequest();

            OrderDetails? newOrder = new OrderDetails();
            newOrder.pizza_id = orderDetails.pizza_id;
            newOrder.quantity = orderDetails.quantity;
            newOrder.order_details_id = orderDetails.order_detail_id;
            newOrder.order_id = orderDetails.order_id;
            OrderDetails? createdOrderDetail = await _iOrderDetailsService.PostOrderDetails(newOrder);
            if (createdOrderDetail == null)
                return Problem(detail: "Add orderdetail failed", title: "PostOrderDetails", statusCode: 400);

            return CreatedAtAction("PostOrderDetails", new { id = createdOrderDetail.order_id }, createdOrderDetail);
        }

        // DELETE: api/OrderDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderDetails(int? id)
        {
            if (id == null)
                return BadRequest();

            bool isDeleted = await _iOrderDetailsService.DeleteOrderDetails(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }

        private bool OrderDetailsExists(int? id)
        {
            return _iOrderDetailsService.OrderDetailsExists(id);
        }
    }
}
