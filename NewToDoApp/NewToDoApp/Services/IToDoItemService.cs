using Microsoft.AspNetCore.Mvc;
using NewToDoApp.Models;

namespace NewToDoApp.Services
{
    public interface IToDoItemService
    {
        Task<ServiceResponse<List<TodoItem>>> GetItemsAsync();
        Task<TodoItem> AddItemAsync(TodoItem todoItem);
        Task<ServiceResponse<TodoItem>> GetItemByIdAsync(int id);
        //Task<ServiceResponse<TodoItem>> UpdateItemAsync(int id);
        Task<ActionResult<TodoItem>> UpdateItemAsync(int id, TodoItem todoItem);
        Task<ServiceResponse<bool>> DeleteItemAsync(int id);

    }
}
