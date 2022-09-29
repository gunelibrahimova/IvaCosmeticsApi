using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFaqManager
    {
        void Add(Faq faq);
        void Remove(Faq faq, int id);
        void Update(Faq faq, int id);
        List<Faq> GetAllFaq();
    }
}
