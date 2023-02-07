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
        public ActionResult<List<string>> Test()
        {
            var list = new List<string>();
            
            list.Add("lol bruh");
            list.Add("bruh lol");

            return list;
        } 
    }
}
