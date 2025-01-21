using NewToDoApp.Models;

namespace NewToDoApp.Client.Services
{
    public interface IToDoService
    {
        event Action ToDosChanged;
        List<TodoItem> ToDos {  get; set; }
        Task GetAllToDos();
        Task<ServiceResponse<TodoItem>> GetTodoItemById(int id);
        Task<TodoItem> AddToDo(TodoItem item);
        Task UpdateTodoItem(TodoItem item);
        Task DeleteTodo(int id);
    }
}
