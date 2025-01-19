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

        public async Task GetAllToDos()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<TodoItem>>>("api/todoitem");
            if (result != null) 
            {
                ToDos = result.Data;
            }
        }
    }
}
