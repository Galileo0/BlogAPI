using Microsoft.AspNetCore.Mvc;
using BlogApi.Services;
using BlogApi.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace BlogApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class SetupController: ControllerBase
    {
        private readonly BlogDBContext _db;
        public SetupController(BlogDBContext db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult api_init()
        {
            Author init_author = new Author{AuthorId = 1, Name="Ahmed Zakaria",Description="Phd of Computer Science"};
            BlogPost init_post = new BlogPost{AuthorID = 1,Author=init_author,Title="Introduction To Algortihms",Body="This Api Created",Summary = "<>",Tags=new string[]{"Computers","Algorithms"}};
            _db.Authors.Add(init_author);
            _db.BlogPosts.Add(init_post);
            _db.SaveChanges();
            return Ok();
        }
    }
}