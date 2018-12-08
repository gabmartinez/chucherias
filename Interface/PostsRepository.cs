using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using konoha.Models;

namespace konoha.Interface
{
    public interface PostsRepository
    {
        IEnumerable<Post> Post { get; set; }

        IEnumerable<Post> IsPreferredPost { get; set; }

        Post GetPostById (int PostID);
    }
}
