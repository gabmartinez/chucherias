using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using konoha.Interface;
using konoha.Models;

namespace konoha.Mocks
{
    public class MockCategoryRepository:ICategoryRepository
    {
        public IEnumerable<Category> Categories {
            get
            {
                return new List<Category>
               {
                   new Category {Name="Sports", Acronym="Spt",Desciption="Lo mejor"}
               };
            }
                
            }

    }
}
