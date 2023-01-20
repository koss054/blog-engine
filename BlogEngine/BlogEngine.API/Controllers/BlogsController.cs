namespace BlogEngine.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Data;
    using Entities;

    [ApiController]
    [Route("api/[controller]")]
    public class BlogsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BlogsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<string> Test()
        {
            return "testtttttt successful g";
        } 
    }
}
