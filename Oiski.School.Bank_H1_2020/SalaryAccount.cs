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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_amount"></param>
        /// <returns><see langword="true"/> if a withdrawel was successful; Othwerwise <see langword="false"/> </returns>
        /// <exception cref="OverdraftException"></exception>
        internal override bool Withdraw (decimal _amount)
        {
            bool success = base.Withdraw(_amount);

            if ( Balance < 0 )
            {
                throw new OverdraftException($"Negative Balance on - {this}");
            }

            return success;
        }

        /// <summary>
        /// Creates a new instance of type <see cref="SalaryAccount"/> where the name of the <see cref="BankAccount"/> is set
        /// </summary>
        /// <param name="_name"></param>
        public SalaryAccount (string _name) : base(_name)
        {

        }
    }
}
