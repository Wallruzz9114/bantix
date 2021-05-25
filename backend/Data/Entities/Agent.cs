using Data.Validations;
using Libraries.Abstraction.Models;

namespace Data.Entities
{
    public class Agent : Entity<Agent>
    {
        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public string BusinessId { get; set; }
        public string Password { get; set; }
        public string AgentNumber { get; set; }
        public string PIN { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new AgentFieldValidation(this).Validate(this);
            return ValidationResult.IsValid;
        }
    }
}