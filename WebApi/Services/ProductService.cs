using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model;

namespace WebApi.Services
{
    public class ProductService
    {
        //使用ProductService时无需在实例
        public static ProductService Current { get; } = new ProductService();

        public List<Products> products;

        public ProductService()
        {
            products = new List<Products>
            {
                new Products
                {
                    Id =1,
                    Name="牛奶",
                    Price=new decimal(2.5),
                    Materials = new List<Material>
                    {
                        new Material
                        {
                            Id = 1,
                            Name = "水"
                        },
                        new Material
                        {
                            Id = 2,
                            Name = "奶粉"
                        }
                    }
                },
                new Products
                {
                    Id=2,
                    Name="咖啡",
                    Price=new decimal(15.5),
                    Materials = new List<Material>
                    {
                        new Material
                        {
                            Id = 3,
                            Name = "水"
                        },
                        new Material
                        {
                            Id = 4,
                            Name = "咖啡豆"
                        }
                    }
                },
                new Products
                {
                    Id=3,
                    Name="面包",
                    Price=new decimal(4.5),
                    Materials = new List<Material>
                    {
                        new Material
                        {
                            Id = 5,
                            Name = "面粉"
                        },
                        new Material
                        {
                            Id = 6,
                            Name = "糖"
                        }
                    }
                }
            };
        }
    }
}
