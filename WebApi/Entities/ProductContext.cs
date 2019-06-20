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

        }

        public DbSet<Product> Products { get; set; }
    }
}
