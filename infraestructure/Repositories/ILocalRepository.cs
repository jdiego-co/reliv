using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infraestructure.Repositories
{
    public interface ILocalRepository<T>: IDisposable where T : class 
    {
        IEnumerable<T> GetAll();
        T? Get(int id);
        bool Update(T entity);
        T Add(T entity);
        bool Delete(T entity);
    }
}
