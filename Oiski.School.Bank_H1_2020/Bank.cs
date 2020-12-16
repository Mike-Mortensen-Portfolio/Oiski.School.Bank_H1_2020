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

        public string Name { get; }
        public decimal TotalCredit { get; private set; } = 0;

        public bool Transaction(BankAccount _account, decimal _amount, bool _deposit = true)
        {
            if ( _deposit )
            {
                return _account.Deposit(_amount);
            }

            return _account.Withdraw(_amount);
        }

        public BankAccount CreateAccount(string _name)
        {
            BankAccount newAccount = new BankAccount(_name);
            return newAccount;
        }

        public string Status()
        {
            string header = $"*************Welcome To {Name}*************";
            string totalCredit = $"Total Credit: {string.Format("{0,35}", $"{TotalCredit:C}")}";
            return $"{header}\n{totalCredit}";
        }

        private Bank(string _name, decimal _totalCredit)
        {
            Name = _name;
            TotalCredit = _totalCredit;
        }
    }
}
