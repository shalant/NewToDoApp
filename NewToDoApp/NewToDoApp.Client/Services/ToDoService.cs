﻿using NewToDoApp.Models;
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

        public event Action ToDosChanged;

        public async Task GetAllToDos()
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
        }

        public async Task GetActiveTodos()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<TodoItem>>>("api/TodoItem");
            if (result != null)
            {
                ToDos = result.Data.Where(x => x.IsComplete == false).ToList();
            }
        }
        
        public async Task GetCompletedTodos()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<TodoItem>>>("api/TodoItem");
            if (result != null)
            {
                ToDos = result.Data.Where(x => x.IsComplete == true).ToList();
            }
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
                Secret = item.Secret,
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
                Secret = item.Secret
            };

            await _http.PutAsJsonAsync($"api/todoitem/{request.Id}", request);
        }

        public async Task DeleteTodo(int id)
        {
            await _http.DeleteAsync($"api/TodoItem/{id}");
        }

        
    }
}
