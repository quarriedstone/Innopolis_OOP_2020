using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    class DebitAccount : Account
    {
        // Debit account has the same functionality as Account.
        public DebitAccount(BankClient client, Guid accountId) : base(client, accountId) { }

        public override string ToString()
        {
            return base.ToString() + $"Account type: {AccountType.Debit}\n";
        }

    }
}
