using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using konoha.Models;

namespace konoha.PostList
{
    public class PostListViewModel
    {
        public IEnumerable<Post> Post { get; set; }

        public string CurrentCategory { get; set; }
    }
}
