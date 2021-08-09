using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task.Models;

namespace Task.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext _context;

        public CustomerRepository(CustomerContext context)
        {
            _context = context;
        }

        public Customer Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        public void Delete(int id)
        {
            var customerToDelete = _context.Customers.Find(id);
            _context.Customers.Remove(customerToDelete);
            _context.SaveChanges();
        }

        public IEnumerable<Customer> Get()
        {
            return _context.Customers.ToList();
        }

        public Customer Get(int id)
        {
            return _context.Customers.Find(id);
        }

        public void Update(Customer customer)
        {
            _context.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
