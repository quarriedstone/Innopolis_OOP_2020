using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    class BusinessAccount : Account
    {
        public BusinessAccount(BankClient client, Guid accountId) : base(client, accountId) { }

        public override Flags Transfer(double moneyAmount, Account account, double coeff = 0)
        {
            switch (Client.Type)
            {
                case ClientType.Regular:
                    coeff = 0.02;
                    break;
                case ClientType.GoldenCardHolder:
                    coeff = 0.01;
                    break;
                case ClientType.VIP:
                    coeff = 0;
                    break;
            }
            return base.Transfer(moneyAmount, account, coeff);
        }

        public override string ToString()
        {
            return base.ToString() + $"Account type: {AccountType.Business}\n";
        }

    }
}
