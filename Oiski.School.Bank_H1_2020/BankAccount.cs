namespace Oiski.School.Bank_H1_2020
{
    public class BankAccount
    {
        public string Name { get; set; }
        public decimal Balance { get; private set; }

        internal bool Deposit(decimal _amount)
        {
            if ( _amount >= 0 )
            {
                Balance += _amount;
                return true;
            }

            return false;
        }

        internal bool Withdraw(decimal _amount)
        {
            if ( _amount >= 0 )
            {
                Balance -= _amount;
                return true;
            }

            return false;
        }

        public BankAccount(string _name)
        {
            Name = _name;
            Balance = 0;
        }
    }
}