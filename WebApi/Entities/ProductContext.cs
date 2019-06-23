using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entities
{
    public class ProductContext:DbContext
    {
        //它可以在我们注册MyContext的时候就提供options
        public ProductContext(DbContextOptions<ProductContext> options):base(options)
        {
            //EnsureCreated()的作用是，如果有数据库存在，那么什么也不会发生。但是如果没有，那么就会创建一个数据库
            //Database.EnsureCreated()确实可以保证创建数据库，但是随着代码不断被编写，我们的Model不断再改变，
            //数据库应该也随之改变，而EnsureCreated()就不够了，这就需要迁移（Migration）。
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }

        public DbSet<Product> Products { get; set; }


        //其中的参数optionsBuilder提供了一个UseSqlServer()这个方法，
        //它告诉Dbcontext将会被用来连接Sql Server数据库，
        //在这里就可以提供连接字符串，这就是第一种方法
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("xxxx connection string");
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
