using NewToDoApp.Models;

namespace NewToDoApp.Services
{
    public interface IToDoItemService
    {
        Task<ServiceResponse<List<TodoItem>>> GetItemsAsync();
    }
}
