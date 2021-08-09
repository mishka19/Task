using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task.Models;

namespace Task.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> Get();
        Customer Get(int id);
        Customer Create(Customer customer);
        void Update(Customer customer);
        void Delete(int id);


    }
}
