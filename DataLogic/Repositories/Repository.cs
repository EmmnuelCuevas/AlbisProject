using DataLayer.Context;
using DataLogic.Helpers;
using DataLogic.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataLogic.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public readonly AppDbContext db;

        public Repository(AppDbContext _db)
        {
            db = _db;
        }

        public Result AddRange(List<T> entities)
        {
            try
            {
                db.Set<T>().AddRange(entities);
                var res = db.SaveChanges();
                if (res >= 1)
                {
                    return new Result
                    {
                        Message = "Entity Added Successfully ",
                        Success = true,
                    };

                }
                return new Result
                {
                    Message = "Entity add operation Failed ",
                    Success = false,
                };
            }
            catch (Exception err)
            {
                //Logror(err.ToString());
                return new Result
                {
                    Message = err.ToString(),
                    Success = false,
                };
            }
        }
        public Result Create(T entity)
        {
            try
            {
                db.Set<T>().Add(entity);
                var res = db.SaveChanges();
                if (res >= 1)
                {
                    return new Result
                    {
                        Message = "Entity Added Successfully ",
                        Success = true,
                    };
                }
                return new Result
                {
                    Message = "Entity add operation Failed ",
                    Success = false,
                };
            }
            catch (Exception err)
            {
                //Logror(err.ToString());
                return new Result
                {
                    Message = err.ToString(),
                    Success = false,
                };
            }

        }
        public List<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            List<T> TEntitys = new List<T>();
            try
            {
                TEntitys = db.Set<T>().Where(expression).ToList();
                return TEntitys;
            }
            catch (Exception err)
            {
                //Logror(err.ToString());
                return TEntitys;
            }
        }

        public T Get(string id)
        {
            try
            {
                var temp = db.Set<T>().Find(id);
                return temp;
            }
            catch (Exception err)
            {
                //Logror(err.ToString());
                return null;
            }
        }

        public List<T> GetAll()
        {
            List<T> TEntitys = new List<T>();
            try
            {
                TEntitys = db.Set<T>().ToList();
                return TEntitys;
            }
            catch (Exception err)
            {
                //Logror(err.ToString());
                return TEntitys;
            }
        }

        public Result Remove(T entity)
        {
            try
            {
                db.Set<T>().Remove(entity);
                var res = db.SaveChanges();
                if (res >= 1)
                {
                    return new Result
                    {
                        Message = "Entity Added Successfully ",
                        Success = true
                    };
                }
                return new Result
                {
                    Message = "Entity Remove operation Failed ",
                    Success = false,
                };
            }
            catch (Exception err)
            {
                //Logror(err.ToString());
                return new Result
                {
                    Message = err.ToString(),
                    Success = false,
                };

            }
        }

        public Result RemoveRange(List<T> entities)
        {
            try
            {
                db.Set<T>().RemoveRange(entities);
                var res = db.SaveChanges();
                if (res >= 1)
                {
                    return new Result
                    {
                        Message = "Entity Added Successfully ",
                        Success = true
                    };
                }

                return new Result
                {
                    Message = "Entity Remove operation Failed ",
                    Success = false,
                };
            }
            catch (Exception err)
            {
                //Logror(err.ToString());
                return new Result
                {
                    Message = err.ToString(),
                    Success = false,
                };
            }
        }


        public Result Update(T entity)
        {
            try
            {
                db.Entry(entity).State = EntityState.Modified;
                var res = db.SaveChanges();
                if (res >= 1)
                {
                    return new Result
                    {
                        Message = "Entity Edit Successfully ",
                        Success = true,
                    };
                }
                return new Result
                {
                    Message = "Entity Edit operation Failed ",
                    Success = false
                };
            }
            catch (Exception err)
            {
                //Logror(err.ToString());
                return new Result
                {
                    Message = err.ToString(),
                    Success = false,
                };

            }
        }

    }
}
