using PostCommentLabWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace PostCommentLabWork.Repository
{
    public class PostRepository : Repository<Post>, IPostRepository
    {


        public IEnumerable<Post> GetHighestPostComment()
        {
            throw new NotImplementedException();
        }
    }
}