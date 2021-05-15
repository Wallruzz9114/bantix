using System;
using Data.Entities;
using Data.Repositories.Interfaces;
using Libraries.Abstraction.Validations;

namespace Data.Specifications
{
    public class UniqueCustomerIdentifierSpecification : EntitySpecification<Customer>
    {
        private readonly ICustomerRepository _customerRepository;

        public UniqueCustomerIdentifierSpecification(Customer customer, ICustomerRepository customerRepository) : base(customer)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        public override bool IsValid()
        {
            var customerFromDB = _customerRepository.GetByIdentifier(_entity.Identifier);
            if (customerFromDB is null) return true;

            return customerFromDB.Id == _entity.Id;
        }
    }
}