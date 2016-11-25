using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DeviceReg.Common.Data.Models;
using System.Data.Entity;

namespace DeviceReg.Repositories
{
    public class UserRepository: RepositoryBase<User>
    {
        public UserRepository(DbSet<User> dbSet) : base(dbSet)
        {

        }
    }
}
