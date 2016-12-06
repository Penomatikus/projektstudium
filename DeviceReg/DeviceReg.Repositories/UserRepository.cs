using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DeviceReg.Common.Data.Models;
using System.Data.Entity;

namespace DeviceReg.Repositories
{
    public class UserRepository : IdentityRepositoryBase<AspNetUser>
    {
        public UserRepository(DbSet<AspNetUser> dbSet) : base(dbSet)
        {

        }
        public AspNetUser GetUserByEmail(string email)
        {
            return DbSet.FirstOrDefault(u => u.Email == email);
        }

        public AspNetUser GetUserById(string id)
        {
            return DbSet.FirstOrDefault(u => u.Id == id);
        }


        public IEnumerable<AspNetUser> GetActiveUsers()
        {
            return DbSet.Where(u => !u.LockoutEnabled);
        }

    }
}

