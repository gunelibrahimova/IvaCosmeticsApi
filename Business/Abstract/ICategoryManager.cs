﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICategoryManager
    {
        void Add(Category category);
        void Remove(Category category,int id);
        void Update(Category category,int id);
        List<Category> GetAllCategories();
        Category GetCategoryById(int id);
    }
}
