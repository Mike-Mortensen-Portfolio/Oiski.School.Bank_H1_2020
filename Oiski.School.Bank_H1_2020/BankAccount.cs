namespace Oiski.School.Bank_H1_2020
{
    /// <summary>
    /// Represents the <see langword="base"/> for all types of bank accounts
    /// </summary>
    public abstract class BankAccount
    {
        public string Name { get; set; }
        public decimal Balance { get; protected set; }
        /// <summary>
        /// A unique ID for the <see cref="BankAccount"/>
        /// </summary>
        public int AccountNumber { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_amount"></param>
        /// <returns><see langword="true"/> if a deposit was successful; Othwerwise <see langword="false"/> </returns>
        internal virtual bool Deposit (decimal _amount)
        {
            if ( _amount >= 0 )
            {
                Balance += _amount;
                return true;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_amount"></param>
        /// <returns><see langword="true"/> if a withdrawel was successful; Othwerwise <see langword="false"/> </returns>
        internal virtual bool Withdraw (decimal _amount)
        {
            if ( _amount >= 0 )
            {
                Balance -= _amount;

                return true;
            }

            return false;
        }

        public abstract void CalculateInterest ();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>A formated <see langword="string"/> that represents the <see cref="BankAccount"/></returns>
        public override string ToString ()
        {
            return $"{Name} ({AccountNumber}):\t\t\t {Balance:C}";
        }

        /// <summary>
        /// Creates a new instance of type <see cref="BankAccount"/> where the name of the account is set
        /// </summary>
        /// <param name="_name"></param>
        public BankAccount (string _name)
        {
            Name = _name;
            Balance = 0;
            AccountNumber = Bank.Instance.AccountCount;
        }
    }
}