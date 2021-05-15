using System.Collections.Generic;
using Data.Entities;
using Data.Enums;
using Libraries.Abstraction.Interfaces;

namespace Data.Repositories.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetByEmail(string email);
        Customer GetByIdentifier(string identifier);
        List<Customer> GetCustomersByStatus(CustomerStatus status);
    }
}