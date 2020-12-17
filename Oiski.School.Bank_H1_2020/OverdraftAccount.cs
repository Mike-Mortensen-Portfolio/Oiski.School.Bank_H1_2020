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

        /// <summary>
        /// Creates a new instance of type <see cref="OverdraftAccount"/> where the name of the <see cref="BankAccount"/> is set
        /// </summary>
        /// <param name="_name"></param>
        public OverdraftAccount (string _name) : base(_name)
        {
        }
    }
}
