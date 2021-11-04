using System;
using Xunit;
using WebAPI.Controllers;

namespace TestAPI
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            User user = new User();
            var us=user.IDCounter();
            var n = true;
            
        }
    }
}
