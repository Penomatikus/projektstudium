using DeviceReg.Common.Data.Interfaces;
using DeviceReg.Common.Data.Models.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeviceReg.Repositories
{
    public class RepositoryBase<T> where T : class, IEntity
    {
        protected virtual DbSet<T> DbSet { get; private set; }

        public RepositoryBase(DbSet<T> dbSet)
        {
            this.DbSet = dbSet;
        }


        bool? _IsIEntity;
        protected virtual bool IsIEntity
        {
            get
            {
                if (!this._IsIEntity.HasValue)
                {
                    this._IsIEntity = typeof(IEntity).IsAssignableFrom(typeof(T));
                }
                return this._IsIEntity.Value;
            }
        }


        public virtual T GetById(int id)
        {
            return this.GetAll().Where(a => a.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// deleted records excluded 
        /// </summary>
        /// <param name="includeExpressions"></param>
        /// <returns></returns>
        public virtual IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeExpressions)
        {
            IQueryable<T> result = this.getAll(includeExpressions);


            if (this.IsIEntity)
            {
                result = ((IQueryable<IEntity>)result)
                           .Where(d => !d.Timestamp.Deleted.HasValue)
                           .Cast<T>();
                return result;
            }
            else
            {
                return result;
            }
        }

        private IQueryable<T> getAll(params Expression<Func<T, object>>[] includeExpressions)
        {
            IQueryable<T> result = null;

            if (includeExpressions != null && includeExpressions.Length > 0)
            {
                result = includeExpressions.Aggregate<Expression<Func<T, object>>, IQueryable<T>>(this.DbSet, (current, expression) => current.Include(expression));
            }
            else
            {
                result = this.DbSet;
            }
            return result;
        }

        public virtual void Add(T entity)
        {
            if (this.IsIEntity)
            {
                (entity as IEntity).Timestamp.Created = DateTime.UtcNow;
            }

            this.DbSet.Add(entity);

        }

        public virtual void Add(IEnumerable<T> entities)
        {

            if (this.IsIEntity)
            {
                var createDate = DateTime.UtcNow;
                var entitiesList = entities.ToList();
                entitiesList.ForEach(e => (e as IEntity).Timestamp.Created = createDate);
            }

            this.DbSet.AddRange(entities);
        }

        public virtual void Update(T entity)
        {

            if (this.IsIEntity)
            {
                (entity as IEntity).Timestamp.Modified = DateTime.UtcNow;
            }
        }

        public virtual void Update(IEnumerable<T> entities)
        {
            if (this.IsIEntity)
            {
                var entitiesList = entities.ToList();
                var updateDate = DateTime.UtcNow;
                entitiesList.ForEach(e => (e as IEntity).Timestamp.Modified = updateDate);
            }
        }

        public virtual void Delete(T entity)
        {
            if (IsIEntity)
            {
                (entity as IEntity).Timestamp.Deleted = DateTime.UtcNow;
            }
            else
            {
                this.DbSet.Remove(entity);
            }
        }

        public virtual void Delete(IEnumerable<T> entities)
        {

            var entitiesList = entities.ToList();

            if (this.IsIEntity)
            {
                var deleteDate = DateTime.UtcNow;
                entitiesList.ForEach(e => (e as IEntity).Timestamp.Deleted = deleteDate);
            }
            else
            {
                this.DbSet.RemoveRange(entities);
            }
        }
    }
}
