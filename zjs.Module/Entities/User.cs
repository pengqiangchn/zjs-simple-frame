using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zjs.SeedWork;

namespace zjs.Module.Entitys
{
    public class User : Entity
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public string Infomation { get; set; }

    }
}
