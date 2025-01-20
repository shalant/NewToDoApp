using NewToDoApp.Models;

namespace NewToDoApp.Client.Services
{
    public interface IToDoService
    {
        event Action ToDosChanged;
        List<TodoItem> ToDos {  get; set; }
        Task GetAllToDos();
        Task<TodoItem> AddToDo(TodoItem item);
        Task DeleteTodo(int id);
    }
}
