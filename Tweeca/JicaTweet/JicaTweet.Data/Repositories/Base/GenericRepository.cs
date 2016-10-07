namespace JicaTweet.Data.Repositories.Base
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Linq.Expressions;
    using EntityFramework.BulkInsert.Extensions;
    using EntityFramework.Extensions;
    using JicaTweet.Contracts;

    public class GenericRepository<T> : IRepository<T> where T : class
    {
        public GenericRepository()
            : this(new JicaTweetDbContext())
        {

        }

        public GenericRepository(JicaTweetDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", nameof(context));
            }

            this.Context = context;
            this.DbSet = this.Context.Set<T>();
        }

        

        protected IDbSet<T> DbSet { get; set; }

        protected JicaTweetDbContext Context { get; set; }

        public IQueryable<T> All()
        {
            return this.DbSet.AsQueryable();
        }

        public T GetById(int id)
        {
            return this.DbSet.Find(id);
        }

        public virtual void Add(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);
            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                this.DbSet.Add(entity);
            }
        }

        public void Add(IEnumerable<T> entities)
        {
            this.Context.BulkInsert(entities);
        }

        public virtual void Update(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;
        }

        public virtual int Update(Expression<Func<T, bool>> filterExpression, Expression<Func<T, T>> updateExpression)
        {
            return this.DbSet.Where(filterExpression).Update(updateExpression);
        }

        public virtual void Delete(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);
            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                this.DbSet.Attach(entity);
                this.DbSet.Remove(entity);
            }
        }

        public virtual void Delete(int id)
        {
            var entity = this.GetById(id);

            if (entity != null)
            {
                this.Delete(entity);
            }
        }

        public int Delete(Expression<Func<T, bool>> filterExpression)
        {
            return this.DbSet.Where(filterExpression).Delete();
        }

        public virtual void Detach(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);

            entry.State = EntityState.Detached;
        }

        
    }
}
