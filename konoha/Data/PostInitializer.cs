using konoha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace konoha.Data
{
    public class PostInitializer
    {

       public static void PostInit(PostContext context)
        {
            context.Database.EnsureCreated();

            if (context.Post.Any())
            {
                return;
            }

            var ps = new Post[]
            {
               
            };

            foreach(Post p in ps)
            {
                context.Post.Add(p);
            }

            context.SaveChanges();
        }
    }
}
