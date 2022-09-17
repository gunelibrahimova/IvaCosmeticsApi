﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entity;

namespace Entities.Concrete
{
    public class Product : IEntity
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public decimal? SalePrice { get; set; }
        public bool IsStock { get; set; }
        public bool IsSale { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
        public string SKU { get; set; }
        public string CoverPhoto { get; set; }
        public int CategoryId   { get; set; }
        public Category Category { get; set; }
        public List<ProductPicture> ProductPicture { get; set;}
    }
}
