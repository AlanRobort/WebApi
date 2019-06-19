using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public ICollection<Material> Materials { get; set; }
        public string Description { get; set; }
    }

    public class Material
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
