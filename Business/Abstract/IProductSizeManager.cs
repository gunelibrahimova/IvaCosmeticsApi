using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductSizeManager
    {
        void Add(ProductSize productSize);
        void Remove(ProductSize productSize, int id);
        void Update(ProductSize productSize, int id);
        List<ProductSize> GetAllProductSize();
    }
}
