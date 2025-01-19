using NewToDoApp.Models;

namespace NewToDoApp.Client.Services
{
    public interface IToDoService
    {
        List<TodoItem> ToDos {  get; set; }
        Task GetAllToDos();
    }
}
