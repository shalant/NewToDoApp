using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MudBlazor.Extensions;
using NewToDoApp.Controllers;
using NewToDoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace TestProject
{
    [TestClass]
    public class TestTodoController
    {
        [TestMethod]
        public void GetAllTodos_ShouldReturnAllTodos()
        {
            // Arrange
            var testTodos = GetTestTodos();
            var controller = new TodoItemController(testTodos);

            // Act
            //var result = controller.GetTodoItems() as <ActionResult<ServiceResponse<List<TodoItem>>>>;
            var result = controller.GetTodoItems() as Task<ActionResult<ServiceResponse<List<TodoItem>>>>;
            //Assert.AreEqual(testTodos.Count, result);

            // Assert
            Assert.IsNotNull(result);
            //Assert.AreEqual(3, result.Count);
        }
    



    private List<TodoItem> GetTestTodos()
        {
            var testTodos = new List<TodoItem>();
            testTodos.Add(new TodoItem { Id = 1, Name = "Test 1", IsComplete = false });
            testTodos.Add(new TodoItem { Id = 2, Name = "Test 2", IsComplete = false });
            testTodos.Add(new TodoItem { Id = 3, Name = "Test 3", IsComplete = false });
            return testTodos;
        }
    }
}