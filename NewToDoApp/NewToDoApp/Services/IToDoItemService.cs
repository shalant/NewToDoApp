using NewToDoApp.Models;

namespace NewToDoApp.Services
{
    public interface IToDoItemService
    {
        Task<ServiceResponse<List<TodoItem>>> GetItemsAsync();
        Task<TodoItem> AddItemAsync(TodoItem todoItem);
        Task<ServiceResponse<bool>> DeleteItemAsync(int id);
        Task<ServiceResponse<TodoItem>> GetItemByIdAsync(int id);
    }
}
