namespace BlogEngine.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Data;
    using Entities;
    
    public class BlogsController : BaseApiController
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
