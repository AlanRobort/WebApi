using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;

namespace WebApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _productContext;

        public ProductRepository(ProductContext productContext)
        {
            _productContext = productContext;
        }



        public Material GetMaterialForProduct(int ProductId, int MaterialId)
        {
            return _productContext.Materials.FirstOrDefault(x => x.ProductId == ProductId && x.Id == MaterialId);
        }

        public IEnumerable<Material> GetMaterialsForProduct(int ProductId)
        {
            return _productContext.Materials.Where(x => x.ProductId == ProductId).ToList();
        }

        public Product GetProduct(int ProductId, bool IncludeMaterial)
        {
            if (IncludeMaterial)
            {
                return _productContext.Products.Include(x => x.Materials).FirstOrDefault(x => x.Id == ProductId);
            }
            return _productContext.Products.Find(ProductId);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _productContext.Products.OrderBy(x => x.Name).ToList();
        }
    }
}
