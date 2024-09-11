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
    public class PizzasController : ControllerBase
    {
        private readonly IPizzasService _pizzaService;
        public PizzasController(IPizzasService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        // GET: api/Pizzas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pizza>>> GetPizzas()
        {
            IEnumerable<Pizza>? pizzaList = await _pizzaService.Getpizzas();
            if (pizzaList == null)
                pizzaList = new List<Pizza>();

            return pizzaList.ToList();
        }

        // GET: api/Pizzas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pizza>> GetPizza(int? id)
        {
            if (id == null)
                return BadRequest();

            var pizza = await _pizzaService.GetPizza(id);

            if (pizza == null)
            {
                return NotFound();
            }

            return pizza;
        }

        // PUT: api/Pizzas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePizza(int? id, Pizza pizza)
        {
            if (id == null)
                return BadRequest();

            if (pizza == null)
                return BadRequest();

            if (id != pizza.id)
            {
                return BadRequest();
            }
            try
            {
                bool isUpdated = await _pizzaService.PutPizza(id, pizza);
                if (!isUpdated)
                {
                    return Problem(detail: "Update pizza failed", title: "PutPizza", statusCode: 304);
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PizzaExists(id))
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

        // POST: api/Pizzas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pizza>> AddPizza(PizzaRequest pizza)
        {
            if (pizza == null)
                return BadRequest();
            if (string.IsNullOrEmpty(pizza.pizza_id))
                return BadRequest();
            if (string.IsNullOrEmpty(pizza.pizza_type_id))
                return BadRequest();
            if (string.IsNullOrEmpty(pizza.size))
                return BadRequest();

            Pizza newPizza = new Pizza();
            newPizza.pizza_id = pizza.pizza_id;
            newPizza.pizza_type_id = pizza.pizza_type_id;
            newPizza.size = pizza.size;
            newPizza.price = pizza.price;

            Pizza? createdPizza = await _pizzaService.PostPizza(newPizza);
            if (createdPizza == null)
                return Problem(detail: "Add pizza failed", title: "PostPizza", statusCode: 400);

            return CreatedAtAction("PostPizza", new { id = createdPizza.id }, createdPizza);
        }

        // DELETE: api/Pizzas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePizza(int? id)
        {
            if (id == null)
                return BadRequest();

            bool isDeleted = await _pizzaService.DeletePizza(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }

        private bool PizzaExists(int? id)
        {
            return _pizzaService.PizzaExists(id);
        }
    }
}
