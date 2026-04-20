using System.Collections.Generic;

namespace CentavoControl.Domain.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        T GetById(Guid id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Remove(Guid id);
    }
}
