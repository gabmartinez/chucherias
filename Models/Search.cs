using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace konoha.Models
{
    public class Search
    {

        public IQueryable<Post> Posts { get; set; }
        public String text { get; set; }
    }
}
