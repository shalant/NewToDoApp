using NewToDoApp.Models;

namespace NewToDoApp.Client.Services
{
    public class IToDoService
    {
        Task<List<TodoItem>> ToDos {  get; set; }
    }
}
