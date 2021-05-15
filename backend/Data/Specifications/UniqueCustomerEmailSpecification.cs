using System;
using Data.Entities;
using Data.Repositories.Interfaces;
using Libraries.Abstraction.Validations;

namespace Data.Specifications
{
    public class UniqueCustomerEmailSpecification : EntitySpecification<Customer>
    {
        private readonly ICustomerRepository _customerRepository;

        public UniqueCustomerEmailSpecification(Customer customer, ICustomerRepository customerRepository) : base(customer)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        public override bool IsValid()
        {
            var customerFromDB = _customerRepository.GetByEmail(_entity.Email);
            if (customerFromDB is null) return true;

            return customerFromDB.Id == _entity.Id;
        }
    }
}