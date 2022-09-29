using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductSizeManager : IProductSizeManager
    {
        private readonly IProductSizeDal _productSizeDal;

        public ProductSizeManager(IProductSizeDal productSizeDal)
        {
            _productSizeDal = productSizeDal;
        }

        public void Add(ProductSize productSize)
        {
            _productSizeDal.Add(productSize);
        }

        public List<ProductSize> GetAllProductSize()
        {
            return _productSizeDal.GetAll();
        }

        public void Remove(ProductSize productSize, int id)
        {
            var current = _productSizeDal.Get(x => x.Id == id);
            current.Size = productSize.Size;
            current.Count = productSize.Count;
            _productSizeDal.Delete(current);
        }

        public void Update(ProductSize productSize, int id)
        {
            var current = _productSizeDal.Get(x => x.Id == id);
            current.Size = productSize.Size;
            current.Count = productSize.Count;
            _productSizeDal.Update(current);
        }
    }
}
