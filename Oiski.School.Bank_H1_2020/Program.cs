using System;

namespace Oiski.School.Bank_H1_2020
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank.Instance.CreateAccount("MyAccount");
            Bank.Instance.Transaction(0, 500);
            Console.WriteLine(Bank.Instance.Status());
        }
    }
}
