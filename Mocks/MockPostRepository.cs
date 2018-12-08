using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using konoha.Interface;
using konoha.Models;

namespace konoha.Mocks
{
    public class MockPostRepository : PostsRepository
    {

        private readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();
        public IEnumerable<Post> Post {
            get
            {
                return new List<Post>
                {
                    
                };
            }
        }


        public IEnumerable<Post> IsPreferredPost { get; set; }
        IEnumerable<Post> PostsRepository.Post { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Post GetPostById(int PostID)
        {
            throw new NotImplementedException();
        }
    }
}
