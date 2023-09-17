using Bogus;
using Microsoft.AspNetCore.Mvc;
using User = UserAPI.Entities.User;

namespace UserAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController
    {
        [HttpGet(Name = "GetUsers")]
        public IEnumerable<User> Get()
        {
            return new Faker<User>("pt_BR")
                .RuleFor(x => x.Id, f => f.Random.Int(1, 100))
                .RuleFor(x => x.Name, f => f.Name.FullName())
                .RuleFor(x => x.Email, (f, u) => f.Internet.Email(u.Name))
                .RuleFor(x => x.BornDate, f => f.Date.Between(Convert.ToDateTime("01/01/1990"), Convert.ToDateTime("01/01/2000")))
                .RuleFor(x => x.PhoneNumber, f => f.Phone.PhoneNumberFormat())
                .Generate(10);
        }
    }
}
