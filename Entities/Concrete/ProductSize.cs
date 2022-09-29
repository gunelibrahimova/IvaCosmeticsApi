using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ProductSize : IEntity
    {
        public int Id { get; set; }
        public string Size { get; set; }
        public int? Count { get; set; }
    }
}
