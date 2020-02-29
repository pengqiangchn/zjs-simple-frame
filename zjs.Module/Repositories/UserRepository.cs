using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zjs.Module.DataContext;
using zjs.Module.Entitys;
using zjs.Module.Repositorys.Interfaces;

namespace zjs.Module.Repositorys
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly MyContext _context;

        public UserRepository(MyContext context)
            : base(context)
        {
            _context = context;
        }
    }
}
