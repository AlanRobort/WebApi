﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entities
{
    public class Product
    {
        public Product()
        {
            Materials = new List<Material>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        //public Material Materials { get; set; }
        public ICollection<Material> Materials { get; set; }

        public int MaterialCount => Materials.Count;
    }
}
