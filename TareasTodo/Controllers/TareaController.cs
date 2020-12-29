using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TareasTodo.Models;

namespace TareasTodo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private  readonly ApplicationDbContext context;

        public TareaController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IEnumerable<Tarea> Get()
        {
            return context.Tareas.ToList();
        }

        [HttpGet("{id}" , Name = "tareaCreada")]
        public IActionResult GetbyId(int id)
        {
            var tarea = context.Tareas.FirstOrDefault(item => item.Id == id);
            
            if (tarea == null)
            {
                return NotFound();

            }
            return Ok(tarea);
        }


        [HttpPost]
        public IActionResult Post([FromBody] Tarea tarea)
        {
            if (ModelState.IsValid)
            {
                context.Tareas.Add(tarea);
                context.SaveChanges();
                return new CreatedAtRouteResult("tareaCreada", new { id = tarea.Id },tarea);
            }
            return BadRequest(ModelState);

        }
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Tarea tarea, int id) {
            if (tarea.Id != id) 
            {
                return BadRequest();
            
            }
            context.Entry(tarea).State = EntityState.Modified;
            context.SaveChanges();
            return Ok(tarea);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var tarea = context.Tareas.FirstOrDefault(item => item.Id == id);

            if (tarea == null)
            {
                return NotFound();

            }
            context.Tareas.Remove(tarea);
            context.SaveChanges();
            return Ok(tarea);
        }
    }
}
