using BlogApi.Models;
using BlogApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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

        //api/
        [HttpGet]
        public ActionResult <IEnumerable<BlogPost>> Get()
        {
            var posts = _db.BlogPosts;
            if(posts != null)
            {
                return posts;
            }
            return NotFound();
        }

        [HttpGet("{BlogID}")]
        public ActionResult<BlogPost> Get(int BlogID)
        {
            var post =  _db.BlogPosts.FirstOrDefault(post => post.BlogPostId == BlogID);
            if(post != null)
            {
                return post;
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult Post([FromBody] BlogPost values)
        {
            _db.BlogPosts.Add(values);
            _db.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int Id,[FromBody] BlogPost Values)
        {
            var post = _db.BlogPosts.FirstOrDefault(p => p.BlogPostId == Id);
            if (post != null)
            {
                post.Title = Values.Title;
                post.Summary = Values.Summary;
                post.Tags = Values.Tags;
                post.Author = Values.Author;
                post.AuthorID = Values.AuthorID;
                _db.BlogPosts.Update(post);
                _db.SaveChanges();
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var post = _db.BlogPosts.FirstOrDefault(p => p.BlogPostId == id);
            if(post != null)
            {
                _db.BlogPosts.Remove(post);
                _db.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}