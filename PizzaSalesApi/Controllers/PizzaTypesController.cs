using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaPlace.Api.Services;
using PizzaPlaceApi.Data;
using PizzaPlaceApi.Data.DTO;
using PizzaPlaceApi.Data.Models;

namespace PizzaPlace.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PizzaTypesController : ControllerBase
    {
        private readonly IPizzaTypesService _pizzaTypeService;

        public PizzaTypesController(IPizzaTypesService  pizzaTypesService)
        {
            _pizzaTypeService = pizzaTypesService;
        }

        // GET: api/PizzaTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PizzaType>>> GetPizzaTypes()
        {
            IEnumerable<PizzaType>? pizzTypeList = await _pizzaTypeService.Getpizza_types();
            if(pizzTypeList == null)
                pizzTypeList = new List<PizzaType>();

            return pizzTypeList.ToList();
        }

        // GET: api/PizzaTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PizzaType>> GetPizzaType(int? id)
        {
            if (id == null)
                return BadRequest();

            var pizzaType = await _pizzaTypeService.GetPizzaType(id);

            if (pizzaType == null)
            {
                return NotFound();
            }

            return pizzaType;
        }

        // PUT: api/PizzaTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePizzaType(int? id, PizzaType? pizzaType)
        {
            if (id == null)
                return BadRequest();

            if (pizzaType == null)
                return BadRequest();

            if (id != pizzaType.id)
            {
                return BadRequest();
            }         
            try
            {
                bool isUpdated = await _pizzaTypeService.PutPizzaType(id, pizzaType);
                if (!isUpdated)
                {
                    return Problem(detail: "Update pizza type failed",title: "PutPizzaType", statusCode:304);
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PizzaTypeExists(id))
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

        // POST: api/PizzaTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PizzaType>> AddPizzaType(PizzaTypeRequest pizzaTypeReq)
        {
            if(pizzaTypeReq == null)
                return BadRequest();
            if(string.IsNullOrEmpty(pizzaTypeReq.pizza_type_id))
                return BadRequest();
            if (string.IsNullOrEmpty(pizzaTypeReq.name))
                return BadRequest();

            PizzaType newPizzaType = new PizzaType();
            newPizzaType.pizza_type_id = pizzaTypeReq.pizza_type_id;
            newPizzaType.ingredients = pizzaTypeReq.ingredients;
            newPizzaType.category = pizzaTypeReq.category;
            newPizzaType.name = pizzaTypeReq.name;

            PizzaType? createdPizzaType = await _pizzaTypeService.PostPizzaType(newPizzaType);
            if(createdPizzaType == null)
                return Problem(detail: "Add pizza type failed", title: "PostPizzaType", statusCode: 400);

            return CreatedAtAction("PostPizzaType", new { id = createdPizzaType.id }, createdPizzaType);
        }

        // DELETE: api/PizzaTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePizzaType(int? id)
        {
            if (id == null)
                return BadRequest();

            bool isDeleted = await _pizzaTypeService.DeletePizzaType(id);
            if (!isDeleted)
            {
                return NotFound();
            }         
            return NoContent();
        }

        private bool PizzaTypeExists(int? id)
        {
            return _pizzaTypeService.PizzaTypeExists(id);
        }
    }
}
