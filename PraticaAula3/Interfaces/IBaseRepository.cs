using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraticaAula3.Interfaces
{
    public interface IBaseRepository<T>
    {
        void Create(T obj);
        void Update(T obj);
        void Delete(T obj);
        List<T> GetAll();
    }
}
