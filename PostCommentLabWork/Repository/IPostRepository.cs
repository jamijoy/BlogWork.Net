using PostCommentLabWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PostCommentLabWork.Repository
{
    interface IPostRepository : IRepository<Post>
    {
        IEnumerable<Post> GetHighestPostComment();
    }
}
