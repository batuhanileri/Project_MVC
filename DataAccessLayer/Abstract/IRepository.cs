using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T>
    {
        List<T> GetAll(Expression<Func<T, bool>> filter);// Şartlı listeleme yapar. İstenilen ifadeye göre değer döndürücek.
        T Get(Expression<Func<T, bool>> filter);
        List<T> GetAll();
        void Add(T t);
        void Update(T t);
        void Delete(T t);

        
    }
}
