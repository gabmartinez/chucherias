using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using konoha.Models;

namespace konoha.Interface
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
    }
}
