using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zjs.Module.Entitys;

namespace zjs.Module.DataContext
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }

        #region member

        public DbSet<User> Users { get; set; }

        #endregion
    }
}
