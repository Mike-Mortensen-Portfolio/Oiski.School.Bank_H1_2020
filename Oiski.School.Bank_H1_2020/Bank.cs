using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.School.Bank_H1_2020
{
    public class Bank
    {
        private static Bank instance = null;
        public static Bank Instance
        {
            get
            {
                if ( instance == null )
                {
                    instance = new Bank("Oiski's Bank", 1000M);
                }

                return instance;
            }
        }

        private readonly List<BankAccount> accounts;
        public IReadOnlyList<BankAccount> GetAccoutns
        {
            get
            {
                return accounts;
            }
        }
        public int AccountCount { get; private set; }

        public string Name { get; }
        public decimal TotalCredit { get; internal set; } = 0;

        public bool Transaction(int _accountNumber, decimal _amount, bool _deposit = true)
        {
            BankAccount account = accounts.Find(acc => acc.AccountNumber == _accountNumber);

            if ( _deposit )
            {
                return account.Deposit(_amount);
            }

            return account.Withdraw(_amount);
        }

        public BankAccount CreateAccount(string _name)
        {
            BankAccount newAccount = new BankAccount(_name);
            AddAccount(newAccount);
            AccountCount++;
            return newAccount;
        }

        public bool AddAccount(BankAccount _account)
        {
            if ( accounts.Find(acc => acc.AccountNumber == _account.AccountNumber) == null )
            {
                accounts.Add(_account);
                return true;
            }

            return false;
        }

        public bool RemoveAccount(BankAccount _account)
        {
            if ( accounts.Find(acc => acc.AccountNumber == _account.AccountNumber) != null )
            {
                accounts.Remove(_account);
                return true;
            }

            return false;
        }

        public string Status()
        {
            StringBuilder builder = new StringBuilder();

            foreach ( BankAccount acc in accounts )
            {
                builder.AppendLine($"{acc}");
            }

            string header = $"*************Welcome To {Name}*************";
            string totalCredit = $"Total Credit: {string.Format("{0,35}", $"{TotalCredit:C}")}";
            return $"{header}\n{builder}\n{totalCredit}";
        }

        private Bank(string _name, decimal _totalCredit)
        {
            Name = _name;
            TotalCredit = _totalCredit;
            accounts = new List<BankAccount>();
        }
    }
}
