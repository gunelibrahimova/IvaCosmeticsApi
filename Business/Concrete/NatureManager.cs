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
    public class NatureManager : INatureManager
    {
        private readonly INatureDal _natureDal;

        public NatureManager(INatureDal natureDal)
        {
            _natureDal = natureDal;
        }

        public void Add(Nature nature)
        {
            _natureDal.Add(nature);
        }

        public List<Nature> GetAllNature()
        {
            return _natureDal.GetAll();
        }

        public Nature GetNatureById(int id)
        {
            return _natureDal.Get(x => x.Id == id);
        }

        public void Remove(Nature nature, int id)
        {
            var current = _natureDal.Get(x => x.Id == id);
            current.Title = nature.Title;
            current.PhotoURL = nature.PhotoURL;
            current.SubTitle = nature.SubTitle;
            _natureDal.Delete(current);
        }

        public void Update(Nature nature, int id)
        {
            var current = _natureDal.Get(x => x.Id == id);
            current.Title = nature.Title;
            current.PhotoURL = nature.PhotoURL;
            current.SubTitle = nature.SubTitle;
            _natureDal.Update(current);
        }
    }
}
