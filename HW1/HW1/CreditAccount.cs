using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    class CreditAccount : Account
    {
        public CreditAccount(BankClient client, Guid accountId) : base(client, accountId) { }

        // Change behaviour of Credit account withdrawal - the balance could be negative.
        public override Flags Withdraw(double moneyAmount)
        {
            MoneyAmount -= moneyAmount;
            Client.MoneyAmount -= moneyAmount;
            // Log operation
            Operations.Add($"Withdrawal succeeded: {moneyAmount}");
            return Flags.Success;
        }

        public override string ToString()
        {
            return base.ToString() + $"Account type: {AccountType.Credit}\n";
        }

    }
}
