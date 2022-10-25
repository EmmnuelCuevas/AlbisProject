using DataLayer.Context;
using DataLogic.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataLogic.Interfaces
{
    public interface IRepository<TEntity>
    {
        TEntity Get(string id);
        List<TEntity> GetAll();
        List<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression);
        Result Create(TEntity entity);
        Result Remove(TEntity entity);
        Result Update(TEntity entity);
        Result RemoveRange(List<TEntity> entities);
        Result AddRange(List<TEntity> entities);
    }
}
