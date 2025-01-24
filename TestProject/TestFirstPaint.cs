using Bunit;
using NewToDoApp.Client.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    
    public class TestFirstPaint : TestContext
    {
        [Fact]
        public void DataShouldLoad()
        {
            var cut = Render<ToDoList>();
            cut.Find("p").MarkupMatches("<p>Loading products...</p>");
        }

    }
}
