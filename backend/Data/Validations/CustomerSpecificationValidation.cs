using System;
using Data.Entities;
using Data.Repositories.Interfaces;
using Data.Specifications;
using FluentValidation;
using Libraries.Abstraction.Extensions;
using Libraries.Abstraction.Validations;

namespace Data.Validations
{
    public class CustomerSpecificationValidation : EntityValidator<Customer>
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerSpecificationValidation(Customer customer, ICustomerRepository customerRepository) : base(customer)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));

            RuleFor(a => a)
                .IsValid(new UniqueCustomerIdentifierSpecification(customer, _customerRepository))
                .WithMessage("This identifier is alrady in use.");

            RuleFor(a => a)
                .IsValid(new UniqueCustomerEmailSpecification(customer, _customerRepository))
                .WithMessage("This email is alrady in use.");
        }
    }
}