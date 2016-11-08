using DeviceReg.Common.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceReg.Repositories
{
    public class RepositoryBase<T> where T : class, IEntity
    {
        protected DbContext db { get; private set; }

        protected virtual DbSet<T> DbSet { get; private set; }

        public RepositoryBase(DbContext database)
        {
            if (database == null)
            {
                throw new ArgumentException("database");
            }

            this.db = database;
        }

        public virtual void Add(T entity)
        {
            this.DbSet.Add(entity);

        }

        public void Update(T entity)
        {

        }

        public void Delete(T entity)
        {

        }
    }
}
