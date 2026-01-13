using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using todoapi_sqllite.Data;
using todoapi_sqllite.Models;

namespace todoapi_sqllite.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodosController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TodosController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var todos = await _context.Todos.ToListAsync();

            if (todos.Count == 0)
            {
                return Ok(new { message = "Tidak ada data todo", data = todos });
            }
            
            return Ok(todos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo == null) return NotFound();
            return Ok(todo);
        }
        
        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> Create([FromBody] Todo todo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();

            return Ok(new {
                message = "Todo berhasil dibuat",
                data = todo
            });

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Todo input)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo == null) return NotFound();

            todo.Title = input.Title;
            todo.IsDone = input.IsDone;
            await _context.SaveChangesAsync();
            return Ok(new { data = todo, message = "Update berhasil" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo == null) return NotFound();

            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();
            return Ok(new { data = todo, message = "Delete berhasil" });
        }
    }
}