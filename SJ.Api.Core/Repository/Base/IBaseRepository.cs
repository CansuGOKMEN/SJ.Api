using SJ.Api.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SJ.Api.Core.Repository.Base
{
    public interface IBaseRepository<T> where T : class, IEntityBase, new()
    {
        int Add(T entity);
        bool Update(T entity);
        List<T> GetAll();
        T Get(int id);
        T Get(Expression<Func<T, bool>> expression);
        IEnumerable<T> FindBy(Expression<Func<T, bool>> expression);
    }
}
