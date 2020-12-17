using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.School.Bank_H1_2020
{
    /// <summary>
    /// Represents the <see cref="Bank"/> itself
    /// </summary>
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
        /// <summary>
        /// Returns all current <see cref="BankAccount"/>s in the <see cref="Bank"/>s collection as a <see cref="IReadOnlyList{T}"/> where <strong>T</strong> is of type <see cref="BankAccount"/>
        /// </summary>
        public IReadOnlyList<BankAccount> GetAccounts
        {
            get
            {
                return accounts;
            }
        }
        /// <summary>
        /// The current amount of <see cref="BankAccount"/>s created at any point. (<i>This is increments everytime a new <see cref="BankAccount"/> is created</i>)
        /// </summary>
        public int AccountCount { get; private set; }

        public string Name { get; }
        public decimal TotalCredit { get; internal set; } = 0;

        /// <summary>
        /// Perform a transaction on a <see cref="BankAccount"/> based on the <paramref name="_accountNumber"/>
        /// </summary>
        /// <param name="_accountNumber"></param>
        /// <param name="_amount"></param>
        /// <param name="_deposit">Whether or not to depost <paramref name="_amount"/> or withdraw it</param>
        /// <returns><see langword="true"/> if the transaction was successful; Otherwise <see langword="false"/></returns>
        public bool Transaction (int _accountNumber, decimal _amount, bool _deposit = true)
        {
            BankAccount account = accounts.Find(acc => acc.AccountNumber == _accountNumber);

            if ( account == null )
            {
                return false;
            }

            if ( _deposit )
            {
                return account.Deposit(_amount);
            }

            return account.Withdraw(_amount);
        }

        /// <summary>
        /// Create a new <see cref="BankAccount"/> based on <paramref name="_type"/>
        /// </summary>
        /// <param name="_type"></param>
        /// <param name="_name"></param>
        /// <returns>A new instance of <see cref="BankAccount"/> where the name is set</returns>
        public BankAccount CreateAccount (AccType _type, string _name)
        {
            BankAccount newAccount = null;
            switch ( _type )
            {
                case AccType.SalaryAccount:
                    newAccount = new SalaryAccount(_name);
                    break;
                case AccType.SavingsAccount:
                    newAccount = new SavingsAccount(_name);
                    break;
                case AccType.OverdraftAccount:
                    newAccount = new OverdraftAccount(_name);
                    break;
            }

            AddAccount(newAccount);
            AccountCount++;
            return newAccount;
        }

        /// <summary>
        /// Calculates the interest on each <see cref="BankAccount"/> in the <see cref="Bank"/>s collection
        /// </summary>
        public void CalculateInterest ()
        {
            foreach ( BankAccount acc in accounts )
            {
                acc.CalculateInterest();
            }
        }

        /// <summary>
        /// Find a <see cref="BankAccount"/> in the <see cref="Bank"/>s collection
        /// </summary>
        /// <param name="_accountNumber"></param>
        /// <returns>The first occurence where the account number equals <paramref name="_accountNumber"/>. If no instance is found this returns <see langword="null"/></returns>
        public BankAccount FindAccount (int _accountNumber)
        {
            return accounts.Find(acc => acc.AccountNumber == _accountNumber);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_account"></param>
        /// <returns><see langword="true"/> if an account could be added; Otherwise <see langword="false"/></returns>
        public bool AddAccount (BankAccount _account)
        {
            if ( accounts.Find(acc => acc.AccountNumber == _account.AccountNumber) == null )
            {
                accounts.Add(_account);
                return true;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_account"></param>
        /// <returns><see langword="true"/> if an account could be removed; Otherwise <see langword="false"/></returns>
        public bool RemoveAccount (BankAccount _account)
        {
            if ( accounts.Find(acc => acc.AccountNumber == _account.AccountNumber) != null )
            {
                accounts.Remove(_account);
                return true;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>A formated <see langword="string"/> that contains information about the <see cref="Bank"/>s collection of <see cref="BankAccount"/>s and the <see cref="Bank"/>s total credit</returns>
        public string Status ()
        {
            TotalCredit = 0;
            StringBuilder builder = new StringBuilder();

            foreach ( BankAccount acc in accounts )
            {
                builder.AppendLine($"{acc}");
                TotalCredit += acc.Balance;
            }

            string totalCredit = $"Total Credit:\t\t\t\t{TotalCredit:C}";
            return $"{builder}\n{totalCredit}";
        }

        /// <summary>
        /// Creates a new instance of type <see cref="Bank"/> where the name and initial total credit is set
        /// </summary>
        /// <param name="_name"></param>
        /// <param name="_totalCredit"></param>
        private Bank (string _name, decimal _totalCredit)
        {
            Name = _name;
            TotalCredit = _totalCredit;
            accounts = new List<BankAccount>();
        }
    }
}