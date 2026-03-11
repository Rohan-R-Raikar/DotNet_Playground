using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xUnitExample.Controllers;

namespace xUnitExample.Tests.Controllers
{
    public class HomeControllerTest
    {
        [Fact]
        public void HomeController_Index_ValidResult()
        {
            //
            // AAA
            // Arrage -
            HomeController controller = new HomeController();
            string expectedResult = "I am in Home";

            // Act -
            string result = controller.Index();
            
            // Assert -
            Assert.Equal(expectedResult, result);
        }
    }
}
