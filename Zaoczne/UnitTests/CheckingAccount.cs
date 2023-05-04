using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public class CheckingAccount : IAccount
    {
     

        public double Balance { get; private set; }
        public string Owner { get; private set; }

        public CheckingAccount(string v, double currentBalance)
        {
            Owner = v;
            Balance = currentBalance;
        }

        public void Withdraw(double amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
            }
            else
            {
                throw new ArgumentException(nameof(amount), "Withdrawal exceeds balance!");
            }
        }
    }
}
