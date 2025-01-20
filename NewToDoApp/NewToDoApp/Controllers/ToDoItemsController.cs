using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewToDoApp.Data;
using NewToDoApp.Models;
using NewToDoApp.Services;

namespace NewToDoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {

        //private readonly ApplicationDbContext _context;

        //public TodoItemsController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        private readonly IToDoItemService _toDoItemService;

        public TodoItemController(IToDoItemService toDoItemService)
        {
            _toDoItemService = toDoItemService;
        }

        // GET: api/TodoItems
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<ToDoItemDTO>>> GetTodoItems()
        //public async Task<ActionResult<IEnumerable<ToDoItem>>> GetTodoItems()
        public async Task<ActionResult<ServiceResponse<List<TodoItem>>>> GetTodoItems()
        {
            var result = await _toDoItemService.GetItemsAsync();
            return Ok(result);
        }

        // GET: api/TodoItems/5
        // <snippet_GetByID>
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<TodoItem>>> GetTodoItem(int id)
        {
            var result = _toDoItemService.GetItemByIdAsync(id);
            return Ok(result);
        }
        // </snippet_GetByID>

        // PUT: api/TodoItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // <snippet_Update>
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutTodoItem(long id, ToDoItemDTO todoDTO)
        //{
        //if (id != todoDTO.Id)
        //{
        //    return BadRequest();
        //}

        //var todoItem = await _context.TodoItems.FindAsync(id);
        //if (todoItem == null)
        //{
        //    return NotFound();
        //}

        //todoItem.Name = todoDTO.Name;
        //todoItem.IsComplete = todoDTO.IsComplete;

        //try
        //{
        //    await _context.SaveChangesAsync();
        //}
        //catch (DbUpdateConcurrencyException) when (!TodoItemExists(id))
        //{
        //    return NotFound();
        //}

        //    return NoContent();
        //}
        // </snippet_Update>

        // POST: api/TodoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // <snippet_Create>
        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem item)
        {
            var todoItem = new TodoItem
            {
                IsComplete = item.IsComplete,
                Name = item.Name,
                Secret = item.Secret
            };

            _toDoItemService.AddItemAsync(todoItem);

            return Ok(todoItem);

            //return CreatedAtAction(
            //    nameof(GetTodoItem),
            //    new { id = todoItem.Id },
            //    ItemToDTO(todoItem));
        }
        // </snippet_Create>

        //DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(int id)
        {
            var result = await _toDoItemService.DeleteItemAsync(id);
            return Ok(result);
        }

        //private bool TodoItemExists(long id)
        //{
        //    return _context.TodoItems.Any(e => e.Id == id);
        //}

        private static ToDoItemDTO ItemToDTO(TodoItem todoItem) =>
           new ToDoItemDTO
           {
               Id = todoItem.Id,
               Name = todoItem.Name,
               IsComplete = todoItem.IsComplete
           };
    }
    }
