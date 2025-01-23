using NewToDoApp.Models;

namespace NewToDoApp.Client.Services
{
    public interface IToDoService
    {
        event Action ToDosChanged;
        List<TodoItem> ToDos {  get; set; }
        string Message { get; set; }
        Task<List<TodoItem>> GetAllToDos();
        Task<List<TodoItem>> GetActiveTodos();
        Task<List<TodoItem>> GetCompletedTodos();
        Task<ServiceResponse<TodoItem>> GetTodoItemById(int id);
        Task<TodoItem> AddToDo(TodoItem item);
        Task UpdateTodoItem(TodoItem item);
        Task DeleteTodo(int id);
        Task<List<TodoItem>> DeleteAllCompleted();
    }
}
