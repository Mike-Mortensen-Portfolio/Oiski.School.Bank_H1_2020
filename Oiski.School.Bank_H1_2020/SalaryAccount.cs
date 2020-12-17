using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.School.Bank_H1_2020
{
    public class SalaryAccount : BankAccount
    {
        public override void CalculateInterest ()
        {
            Balance = ( Balance * .5M ) + Balance;
        }

        public SalaryAccount (string _name) : base(_name)
        {
        }
    }
}
