using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface INatureManager
    {
        void Add(Nature nature);
        void Remove(Nature nature, int id);
        void Update(Nature nature, int id);
        List<Nature> GetAllNature();
        Nature GetNatureById(int id);
    }
}
