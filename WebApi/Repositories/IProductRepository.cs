using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;

namespace WebApi.Repositories
{
   public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();

        Product GetProduct(int ProductId, bool IncludeMaterial);

        IEnumerable<Material> GetMaterialsForProduct(int productId);

        Material GetMaterialForProduct(int ProductId, int MaterialId);

    }
}
