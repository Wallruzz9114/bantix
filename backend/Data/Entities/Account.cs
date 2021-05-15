using System;
using Libraries.Abstraction.Models;

namespace Data.Entities
{
    public class Account : Entity<Account>
    {
        public string AccountNumber { get; set; }
        public string Numero { get; private set; }
        public string DigitoVerificador { get; private set; }
        public decimal CurrentBalance { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public void DepositAmount(decimal amount) => CurrentBalance += amount;

        public void Withdraw(decimal amount)
        {
            if (CurrentBalance < amount)
            {
                throw new InvalidOperationException("The amount exceeds the current balance");
            }

            CurrentBalance -= amount;
        }

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}