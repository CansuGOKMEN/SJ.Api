using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SJ.Api.Core.Context;
using SJ.Api.Core.Model;
using SJ.Api.Core.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SJ.Api.Core.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, IEntityBase, new()
    {
        private SJApiContext context;

        public BaseRepository(SJApiContext context)
        {
            this.context = context;
        }

        public int Add(T entity)
        {
            EntityEntry dbEntityEntry = context.Entry<T>(entity);
            context.Set<T>().Add(entity);

            context.SaveChanges();

            return context.Set<T>().FirstOrDefault(x => x.Id == entity.Id).Id;
        }

        public bool Update(T entity)
        {
            EntityEntry dbEntityEntry = context.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Modified;
            context.SaveChanges();
            return true;
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> expression)
        {
            return context.Set<T>().Where(expression);
        }

        public T Get(int id)
        {
            return context.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            return context.Set<T>().FirstOrDefault(expression);
        }

        public List<T> GetAll()
        {
            return context.Set<T>().ToList();
        }
    }
}
