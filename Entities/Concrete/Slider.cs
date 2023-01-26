﻿using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Slider : IEntity
    {
        public int Id { get; set; }
        public string PhotoURL { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
    }
}
