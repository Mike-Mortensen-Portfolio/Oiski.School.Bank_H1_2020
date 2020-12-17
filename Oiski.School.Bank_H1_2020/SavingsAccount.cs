using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.School.Bank_H1_2020
{
    public class SavingsAccount : BankAccount
    {
        public override void CalculateInterest ()
        {
            if ( Balance < 50000 )
            {
                Balance = ( Balance * 1M ) + Balance;
            }
            else if ( Balance >= 50000 && Balance < 100000 )
            {
                Balance = ( Balance * 2M ) + Balance;
            }
            else if ( Balance >= 100000 )
            {
                Balance = ( Balance * 3M ) + Balance;
            }
        }

        public SavingsAccount (string _name) : base(_name)
        {
        }
    }
}
