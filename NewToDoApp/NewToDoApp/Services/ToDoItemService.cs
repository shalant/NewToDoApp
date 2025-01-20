using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using NewToDoApp.Data;
using NewToDoApp.Models;

namespace NewToDoApp.Services
{
    public class ToDoItemService : IToDoItemService
    {
        private readonly ApplicationDbContext _context;

        public ToDoItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<TodoItem>>> GetItemsAsync()
        {
            var response = new ServiceResponse<List<TodoItem>>
            {
                Data = await _context.TodoItems.ToListAsync()
            };

            return response;
        }

        public async Task<TodoItem> AddItemAsync(TodoItem todoItem)
        {
            await _context.TodoItems.AddAsync(todoItem);
            await _context.SaveChangesAsync();
            return todoItem;
        }

        public async Task<ServiceResponse<bool>> DeleteItemAsync(int id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);
            if (todoItem == null) 
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Success = false,
                    Message = "Item does not exist"
                };
            }

            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync() ;

            return new ServiceResponse<bool> {Data = true};
        }
    }
}
