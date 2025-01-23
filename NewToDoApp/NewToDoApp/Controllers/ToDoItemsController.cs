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
        private readonly IToDoItemService _toDoItemService;

        public TodoItemController(IToDoItemService toDoItemService)
        {
            _toDoItemService = toDoItemService;
        }

        // GET: api/TodoItems
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<TodoItem>>>> GetTodoItems()
        {
            var result = await _toDoItemService.GetItemsAsync();
            return Ok(result);
        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<TodoItem>>> GetTodoItem(int id)
        {
            var result = await _toDoItemService.GetItemByIdAsync(id);
            return Ok(result);
        }

        // PUT: api/TodoItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateToDoItem(int id, TodoItem todoItem)
        {
            var result = await _toDoItemService.UpdateItemAsync(id, todoItem);
            return Ok(result);
        }

        // POST: api/TodoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem item)
        {
            var todoItem = new TodoItem
            {
                IsComplete = item.IsComplete,
                Name = item.Name,
                ShortDescription = item.ShortDescription
            };

            _toDoItemService.AddItemAsync(todoItem);

            return Ok(todoItem);
        }

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
