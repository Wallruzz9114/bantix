using Data.Validations;
using Libraries.Abstraction.Models;

namespace Data.Entities
{
    public class Agent : Entity<Agent>
    {
        private Agent() { }

        public string FullName { get; private set; }
        public string DisplayName { get; private set; }
        public string BusinessId { get; private set; }
        public string Password { get; private set; }
        public int AgentNumber { get; private set; }
        public int PIN { get; private set; }

        public override bool IsConsistent()
        {
            ValidationResult = new AgentFieldValidation(this).Validate(this);
            return ValidationResult.IsValid;
        }
    }
}