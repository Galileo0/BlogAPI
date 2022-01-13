using BlogApi.Models;
using BlogApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{   
    [Route("api/[Controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly BlogDBContext _db;
        public PostsController(BlogDBContext db)
        {
            _db = db;
        }

        
    }
}