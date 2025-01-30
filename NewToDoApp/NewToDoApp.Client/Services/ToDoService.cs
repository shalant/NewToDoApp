using NewToDoApp.Models;
using System.Net.Http.Json;

namespace NewToDoApp.Client.Services
{
    public class ToDoService : IToDoService
    {
        private readonly HttpClient _http;

        public ToDoService(HttpClient http)
        {
            _http = http;
        }

        public List<TodoItem> ToDos {  get; set; } = new List<TodoItem>();
        public string Message { get; set; } = "Loading todos...";

        public event Action ToDosChanged;

        public async Task<List<TodoItem>> GetAllToDos()
        {
            try
            {
                var result = await _http.GetFromJsonAsync<ServiceResponse<List<TodoItem>>>("api/TodoItem");

                if (result != null)
                {
                    ToDos = result.Data;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (ToDos.Count == 0)
                Message = "No todos found";

            ToDosChanged.Invoke();
            return ToDos;
        }

        public async Task<List<TodoItem>> GetActiveTodos()
        {
            try
            {
                var result = await _http.GetFromJsonAsync<ServiceResponse<List<TodoItem>>>("api/TodoItem");
                if (result != null)
                {
                    ToDos = result.Data.Where(x => x.IsComplete == false).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
            if (ToDos.Count == 0)
            {
                Message = "There are zero active tasks, get to work!";
            }
            return ToDos;
        }
        
        public async Task<List<TodoItem>> GetCompletedTodos()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<TodoItem>>>("api/TodoItem");
            
            if (result != null)
            {
                ToDos = result.Data.Where(x => x.IsComplete == true).ToList();
            }
            if(ToDos.Count == 0)
            {
                Message = "There are zero completed tasks, get to work!";
            }
            return ToDos;
        }
        
        public async Task<List<TodoItem>> GetAllTodos()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<TodoItem>>>("api/TodoItem");
            
            if (result != null)
            {
                ToDos = result.Data.ToList();
            }
            if(ToDos.Count == 0)
            {
                Message = "There are zero tasks, get to work!";
            }
            return ToDos;
        }

        public async Task<ServiceResponse<TodoItem>> GetTodoItemById(int id)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<TodoItem>>($"api/TodoItem/{id}");
            return result;
        }

        public async Task<TodoItem> AddToDo(TodoItem item)
        {
            var newToDo = new TodoItem()
            {
                Name = item.Name,
                IsComplete = item.IsComplete,
                ShortDescription = item.ShortDescription,
            };

            var result = await _http.PostAsJsonAsync<TodoItem>("api/TodoItem", newToDo);
            return newToDo;
        }

        public async Task UpdateTodoItem(TodoItem item)
        {
            var request = new TodoItem
            {
                Id = item.Id,
                Name = item.Name,
                IsComplete = item.IsComplete,
                ShortDescription = item.ShortDescription
            };

            await _http.PutAsJsonAsync($"api/todoitem/{request.Id}", request);
        }

        public async Task DeleteTodo(int id)
        {
            await _http.DeleteAsync($"api/TodoItem/{id}");
        }

        public async Task<List<TodoItem>> DeleteAllCompleted()
        {
            var completedTodosToDelete = new List<TodoItem>();
            foreach (var item in ToDos)
            {
                if (item.IsComplete = true)
                {
                    completedTodosToDelete.Add(item);
                    await _http.DeleteAsync($"api/TodoItem/{item.Id}");
                }
                else
                {
                    completedTodosToDelete = ToDos;
                }
            }
            return completedTodosToDelete;
        }
        }
    }
