using System;
using Data.Enums;
using Data.Validations;
using Libraries.Abstraction.Models;

namespace Data.Entities
{
    public class Customer : Entity<Customer>
    {
        public string FullName { get; set; }
        public string Identifier { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public CustomerStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new CustomerFieldValidation(this).Validate(this);
            return ValidationResult.IsValid;
        }
    }
}