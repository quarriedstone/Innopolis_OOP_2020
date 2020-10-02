using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    class SavingAccount : Account
    {
        // Date before which it is not possible to withdraw money
        public DateTime SavingDate { set; get; }

        // Constructors for Saving account. The first one will call base constructor first and then set the date. 
        // Second one will use default constructor and set the date after.
        public SavingAccount(BankClient client, DateTime savingDate, double moneyAmount, Guid accountId) : base(client, moneyAmount, accountId)
        {
            SavingDate = savingDate;
        }
        public SavingAccount(BankClient client, DateTime savingDate, Guid accountId) : base(client, accountId)
        {
            SavingDate = savingDate;
        }

        // Override method for withdrawal money. If current date is less than saving date, the widrawal could not be done.
        public override Flags Withdraw(double moneyAmount)
        {
            if (DateTime.Now >= SavingDate) 
            {
                return base.Withdraw(moneyAmount);
            }
            return Flags.TooEarlyDate;
        }

        public override string ToString()
        {
            return base.ToString() + $"Account type: {AccountType.Saving}\n";
        }

    }
}
