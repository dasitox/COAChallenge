using COAChallenge.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace COAChallenge.UnitOfWork
{
    public interface IGenericRepository<T> where T : class
    {
        IList<T> GetAll();
        void Insert(T entity);
        T GetById(int id);
        void Update(T entity);
        void Delete(T entity);
    }
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly COAContext context;
        public GenericRepository(COAContext context)
        {
            this.context = context;
        }
        
        public void Insert(T entity)
        {
            try
            {
                context.Set<T>().Add(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IList<T> GetAll()
        {
            var collectionResult = context.Set<T>().ToList();
            return collectionResult;
        }
        public virtual T GetById(int id)
        {
            var entity = context.Set<T>().Find(id);
            return entity;
        }
        public virtual void Update(T entity)
        {
                context.Attach(entity);
                context.Entry(entity).State = EntityState.Modified;            
        }
        public void Delete(T entity)
        {
            context.Remove(entity);
        }
    }
}
