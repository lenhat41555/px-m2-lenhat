using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLS.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Book> Book { set; get; }
        public DbSet<Category> categories { set; get; }
        public object Categories { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(new Category { Id = 1, CategoryName = "lịch sử" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 2, CategoryName = "toán" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 3, CategoryName = "văn" });

            modelBuilder.Entity<Book>().HasData(new Book


            {
                Id = 1,
                NameBook = "lịch sử",
                Author = "le nhat",
                Content = "chien tranh",
                PublishingYear = 2020,
                Amount = 127,
                CategoryId = 1,

            });
            modelBuilder.Entity<Book>().HasData(new Book


            {
                Id = 2,
                NameBook = "toán",
                Author = "long",
                Content = "hàm",
                PublishingYear = 2010,
                Amount = 167,
                CategoryId = 2,

            });
            modelBuilder.Entity<Book>().HasData(new Book


            {
                Id = 3,
                NameBook = "văn",
                Author = "tuan anh",
                Content = "thơ",
                PublishingYear = 2009,
                Amount = 177,
                CategoryId = 3,

            });





        }
    }
}