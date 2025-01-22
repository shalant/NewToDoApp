﻿using Azure;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewToDoApp.Data;
using NewToDoApp.Models;

namespace NewToDoApp.Services
{
    public class ToDoItemService : IToDoItemService
    {
        private readonly ApplicationDbContext _context;

        public ToDoItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<TodoItem>>> GetItemsAsync()
        {
            var response = new ServiceResponse<List<TodoItem>>
            {
                Data = await _context.TodoItems.ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<TodoItem>> GetItemByIdAsync(int id)
        {
            var response = new ServiceResponse<TodoItem>();

            try
            {
                response.Data = await _context.TodoItems.FirstOrDefaultAsync();   
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            //var todoItem = await _context.TodoItems.FirstOrDefaultAsync(x => x.Id == id);
            //var todoItem = await _context.TodoItems.Where(x => x.Id == id).FirstOrDefaultAsync();
            //var todoItem = await _context.TodoItems.FirstOrDefaultAsync();

            var todoItem = response.Data;

            if (todoItem == null)
            {
                response.Success = false;
                response.Message = "Sorry, but this item does not exist";
            }

            return response;
        }

        public async Task<TodoItem> AddItemAsync(TodoItem todoItem)
        {
            await _context.TodoItems.AddAsync(todoItem);
            await _context.SaveChangesAsync();
            return todoItem;
        }

        //public async Task<ActionResult<TodoItem>> UpdateItemAsync(TodoItem todoItem)
        public async Task<ActionResult<TodoItem>> UpdateItemAsync(int id, TodoItem todoItem)
        {
            var itemToBeUpdated = await _context.TodoItems.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (todoItem == null)
            {
                return todoItem;
            }

            itemToBeUpdated.Name = todoItem.Name;
            itemToBeUpdated.IsComplete = todoItem.IsComplete;

            await _context.SaveChangesAsync();
            //var updatedTodoItem = new TodoItem
            //{
            //    Id = todoItem.Id,
            //    IsComplete = todoItem.IsComplete,
            //    Name = todoItem.Name,
            //    Secret = todoItem.Secret
            //};

            //_context.TodoItems.Update(updatedTodoItem);
            //await _context.SaveChangesAsync();

            return itemToBeUpdated;
        }

        //public Task<ServiceResponse<TodoItem>> UpdateItemAsync(int id)
        //public Task<ServiceResponse<TodoItem>> UpdateItemAsync(int id)
        //{
        //    //var updatedTodoItem = new TodoItem();
        //    var request = new <TodoItem>
        //    {
        //            Id = updatedTodoItem.Id,
        //            Name = updatedTodoItem.Name,
        //            IsComplete = updatedTodoItem.IsComplete
        //        };

        //}

        public async Task<ServiceResponse<bool>> DeleteItemAsync(int id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);
            if (todoItem == null) 
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Success = false,
                    Message = "Item does not exist"
                };
            }

            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync() ;

            return new ServiceResponse<bool> {Data = true};
        }

        
    }
}
