using _181010_IS_Homework1.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace _181010_IS_Homework1.Repository.Interface
{
    public interface IUserRepository
    {
        IEnumerable<ShopApplicationUser> GetAll();
        ShopApplicationUser Get(string id);
        public void Insert(ShopApplicationUser entity);
        public void Update(ShopApplicationUser entity);
        public void Delete(ShopApplicationUser entity);
        public void Remove(ShopApplicationUser entity);
        public void SaveChanges();
    }
}
