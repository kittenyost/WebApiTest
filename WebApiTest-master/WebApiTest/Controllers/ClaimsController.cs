using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApiTest.Areas.Identity.Data;
using WebApiTest.Data;

namespace WebApiTest.Controllers
{
    public class Taco
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class ClaimsController : ControllerBase
    {
        private readonly WebApiTestContext _context;
        private readonly UserManager<BlogUser> _userManager;
        private List<Taco> _tacoList;

        public ClaimsController(WebApiTestContext ctx, UserManager<BlogUser> usr)
        {
            // here we bind context/services for use in the controller
            _context = ctx;
            _userManager = usr;

            _tacoList = new List<Taco>();

            _tacoList.Add(new Taco { Id = 1, Name = "Soft Taco", Price = 0.99f });
            _tacoList.Add(new Taco { Id = 2, Name = "Hard Taco", Price = 0.99f });
            _tacoList.Add(new Taco { Id = 3, Name = "5-Layer Cheesy Burrito", Price = 3.99f });
        }

        // our endpoint functions
        [HttpGet]
        public async Task<ActionResult<ClaimsPrincipal>> Get()
        {
            return User;
        }
    }
}
