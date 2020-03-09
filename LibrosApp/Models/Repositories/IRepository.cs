using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrosApp.Models.Repositories
{
    public interface IRepository<T> : IDisposable where T : class
    {
        T FindById(int Id);

        List<T> GetAll();

        void Create(T t);

        void Delete(T t);

        void Update(T t);
    }
}
