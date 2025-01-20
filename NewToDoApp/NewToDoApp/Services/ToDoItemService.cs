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
    }
}
