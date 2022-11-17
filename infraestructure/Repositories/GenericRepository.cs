using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infraestructure.Repositories
{
    public class GenericRepository<T> : ILocalRepository<T> where T : class
    {
        private LocalDbContext _dbContext;
        public GenericRepository(LocalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public T Add(T entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public bool Delete(T entity)
        {
            bool success = false;
            try
            {
                var result = _dbContext.Remove(entity);
                success = true;
            }
            catch (Exception) { }
            return success;
        }

        public T? Get(int id)
        {
            return (T?)_dbContext.Find(typeof(T), id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public bool Update(T entity)
        {
            bool success = false;
            try
            {
                var result = _dbContext.Update(entity);
                success = true;
            }
            catch (Exception) { }
            return success;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
