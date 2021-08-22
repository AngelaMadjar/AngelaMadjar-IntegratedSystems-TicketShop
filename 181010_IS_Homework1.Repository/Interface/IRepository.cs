using _181010_IS_Homework1.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace _181010_IS_Homework1.Repository.Interface
{
   public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T Get(Guid? id);
        public void Insert(T entity);
        public void Update(T entity);
        public void Delete(T entity);
        public void Remove(T entity);
        public void SaveChanges();
    }
}
