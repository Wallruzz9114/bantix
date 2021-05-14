using Data.Validations;
using Libraries.Abstraction.Models;

namespace Data.Entities
{
    public class Agency : Entity<Agency>
    {
        private Agency() { }

        public string FullName { get; private set; }
        public string DisplayName { get; private set; }
        public string BusinessId { get; private set; }
        public string Password { get; private set; }
        public int AgencyNumber { get; private set; }
        public int PIN { get; private set; }

        public override bool IsConsistent()
        {
            ValidationResult = new AgencyFieldValidation(this).Validate(this);
            return ValidationResult.IsValid;
        }
    }
}