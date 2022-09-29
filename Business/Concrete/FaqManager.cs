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
    public class FaqManager : IFaqManager
    {
        private readonly IFaqDal _faqDal;

        public FaqManager(IFaqDal faqDal)
        {
            _faqDal = faqDal;
        }

        public void Add(Faq faq)
        {
            _faqDal.Add(faq);
        }

        public List<Faq> GetAllFaq()
        {
            return _faqDal.GetAll();
        }

        public void Remove(Faq faq, int id)
        {
            var current = _faqDal.Get(x => x.Id == id);
            current.Title = faq.Title;
            current.Description = faq.Description;
            _faqDal.Delete(current);
        }

        public void Update(Faq faq, int id)
        {
            var current = _faqDal.Get(x => x.Id == id);
            current.Title = faq.Title;
            current.Description = faq.Description;
            _faqDal.Update(current);
        }
    }
}
