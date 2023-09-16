using System.Text.RegularExpressions;
using UserAPI.Controllers;

namespace UserAPI
{
    public class GetUsers
    {
        [Fact]
        public void Should_GetUsers_Correctly()
        {
            UsersController usersController = new UsersController();
            var result = usersController.Get();
            Assert.True(result.Count() == 10);
        }

        [Fact]
        public void Should_Phone_Number_Users_Formatted_Correctly()
        {
            var phoneNumberPattern = new Regex(@"(\(\d{2}\)\s)(\d{4,5}\-\d{4})");
            UsersController usersController = new UsersController();
            var result = usersController.Get();
            Assert.Matches(phoneNumberPattern, result.ElementAt(2).PhoneNumber);
        }
    }
}