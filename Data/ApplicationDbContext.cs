using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using chucherias.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.AspNetCore.Identity;

namespace chucherias.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<PostImage> PostImage { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Post>()
                .Property(b => b.IsActive)
                .HasConversion(new BoolToZeroOneConverter<Int16>());
            builder.Entity<IdentityUser>()
                .Property(b => b.EmailConfirmed)
                .HasConversion(new BoolToZeroOneConverter<Int16>());
            builder.Entity<IdentityUser>()
                .Property(b => b.LockoutEnabled)
                .HasConversion(new BoolToZeroOneConverter<Int16>());
            builder.Entity<IdentityUser>()
                .Property(b => b.PhoneNumberConfirmed)
                .HasConversion(new BoolToZeroOneConverter<Int16>());
            builder.Entity<IdentityUser>()
                .Property(b => b.TwoFactorEnabled)
                .HasConversion(new BoolToZeroOneConverter<Int16>());
        }
    }
}
