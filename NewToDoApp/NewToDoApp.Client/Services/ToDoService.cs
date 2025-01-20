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
                var result = await _http.GetFromJsonAsync<ServiceResponse<List<TodoItem>>>("api/GetTodoItems");

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
    }
}
