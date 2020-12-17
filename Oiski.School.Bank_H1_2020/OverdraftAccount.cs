using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.School.Bank_H1_2020
{
    public class OverdraftAccount : BankAccount
    {
        public override void CalculateInterest ()
        {
            if ( Balance >= 0 )
            {
                Balance = ( Balance * .5M ) + Balance;
            }
            else
            {
                Balance = ( Balance * 5M ) - Balance;
            }
        }

        public OverdraftAccount (string _name) : base(_name)
        {
        }
    }
}
