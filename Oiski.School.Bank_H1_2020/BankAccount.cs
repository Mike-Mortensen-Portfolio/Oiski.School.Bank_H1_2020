namespace Oiski.School.Bank_H1_2020
{
    public abstract class BankAccount
    {
        public string Name { get; set; }
        public decimal Balance { get; protected set; }
        public int AccountNumber { get; private set; }

        internal bool Deposit (decimal _amount)
        {
            if ( _amount >= 0 )
            {
                Bank.Instance.TotalCredit += _amount;
                Balance += _amount;
                return true;
            }

            return false;
        }

        internal bool Withdraw (decimal _amount)
        {
            if ( _amount >= 0 )
            {
                Bank.Instance.TotalCredit -= _amount;
                Balance -= _amount;
                return true;
            }

            return false;
        }

        public abstract void CalculateInterest ();

        public override string ToString ()
        {
            return $"{Name}: {string.Format("{0,35}", $"{Balance:C}")}";
        }

        public BankAccount (string _name)
        {
            Name = _name;
            Balance = 0;
            AccountNumber = Bank.Instance.AccountCount;
        }
    }
}