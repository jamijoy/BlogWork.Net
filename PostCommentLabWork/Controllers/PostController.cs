using PostCommentLabWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PostCommentLabWork.Repository;

namespace PostCommentLabWork.Controllers
{
    [RoutePrefix("api/posts")]
    public class PostController : ApiController
    {
        IRepository<Post> repo = new PostRepository();
        public PostController()
        {
            this.repo = new PostRepository();
        }

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(repo.GetAll().ToList());
        }

        [Route("{id}", Name = "GetPostById")]
        public IHttpActionResult Get(int id)
        {
            Post post = repo.Get(id);
            post.Links.Add(new Links() { HRef = "http://localhost:4468/api/posts", Method = "GET", Rel = "Get all the Post list" });
            post.Links.Add(new Links() { HRef = "http://localhost:4468/api/posts", Method = "POST", Rel = "Create a new Posts resource" });
            post.Links.Add(new Links() { HRef = "http://localhost:4468/api/posts/" + post.postId, Method = "PUT", Rel = "Modify an existing Post resource" });
            post.Links.Add(new Links() { HRef = "http://localhost:4468/api/posts/" + post.postId, Method = "DELETE", Rel = "Delete an existing Post resource" });
            return Ok(post);
        }
        [Route("")]
        public IHttpActionResult Post([FromBody]Post post)
        {
            repo.Insert(post);
            string url = Url.Link("GetPostById", new { id = post.postId });
            return Created(url, post);
        }
        [Route("{id}")]
        public IHttpActionResult Put([FromBody]Post post, [FromUri]int id)
        {
            post.postId = id;
            repo.Update(post);
            return Ok(post);
        }

        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            repo.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
