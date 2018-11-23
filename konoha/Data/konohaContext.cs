using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace konoha.Models
{
    public class konohaContext : DbContext
    {
        public konohaContext (DbContextOptions<konohaContext> options)
            : base(options)
        {
        }

        public DbSet<konoha.Models.Category> Category { get; set; }
    }
}
