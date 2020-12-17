using System;

namespace Oiski.School.Bank_H1_2020.Application
{
    class Program
    {
        static void Main ()
        {
            #region Setting Console Configuration and Building Test Data
            Console.SetWindowSize(57, 40);
            Bank.Instance.CreateAccount(AccType.SalaryAccount, "Salary Account");
            Bank.Instance.Transaction(0, 1500);

            #region Saving Accounts
            Bank.Instance.CreateAccount(AccType.SavingsAccount, "Savings Account");
            Bank.Instance.Transaction(1, 750);

            Bank.Instance.CreateAccount(AccType.SavingsAccount, "Savings Account2");
            Bank.Instance.Transaction(2, 60000);

            Bank.Instance.CreateAccount(AccType.SavingsAccount, "Savings Account3");
            Bank.Instance.Transaction(3, 100000);
            #endregion 

            Bank.Instance.CreateAccount(AccType.OverdraftAccount, "Overdraft Account");
            Bank.Instance.Transaction(4, 1500);
            Bank.Instance.CreateAccount(AccType.OverdraftAccount, "Overdraft Account2");
            Bank.Instance.Transaction(5, 500, _deposit: false);
            Console.CursorVisible = false;
            #endregion

            int index = 0;
            do
            {
                PrintReferenceMenu();
                switch ( index )
                {
                    case 0:
                        index = MainMenu();
                        break;
                    case 1:
                        CreateAccountMenu();

                        PrintReturnClosure();
                        index = 0;
                        break;
                    case 2:
                        AddOrRemoveCreditMenu();

                        PrintReturnClosure();
                        index = 0;
                        break;
                    case 3:
                        Console.CursorVisible = false;
                        Bank.Instance.CalculateInterest();
                        Console.WriteLine("Interest Calculated");

                        PrintReturnClosure();
                        index = 0;
                        break;
                    case 4:
                        Console.CursorVisible = true;
                        int result;

                        #region Repeat ID collection sequence until the user provides a valid ID
                        do
                        {
                            Console.Clear();
                            PrintReferenceMenu();
                            Console.Write("Account ID: ");
                            Console.ForegroundColor = ConsoleColor.Blue;
                        } while ( !int.TryParse(Console.ReadLine(), out result) );
                        #endregion

                        Console.ResetColor();
                        BankAccount account = Bank.Instance.FindAccount(result);

                        #region Check if Null
                        if ( account != null )
                        {
                            PrintColoredText(account.ToString(), ConsoleColor.Cyan);
                        }
                        else
                        {
                            PrintColoredText("No Account Found...", ConsoleColor.Red);
                        }
                        #endregion 

                        PrintReturnClosure();
                        index = 0;
                        break;
                    case 5:
                        Console.CursorVisible = false;
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Bank.Instance.Status();
                        Console.WriteLine(Bank.Instance.Status());

                        PrintReturnClosure();
                        index = 0;
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        index = 0;
                        continue;
                }
            } while ( true );
        }

        private static void PrintReferenceMenu ()
        {
            Console.Clear();
            Console.WriteLine("#########################################################");
            Console.Write("#                    -");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Oiski's  Bank");
            Console.ResetColor();
            Console.Write("-                    #\n");
            Console.WriteLine("#-------------------------------------------------------#");
            Console.WriteLine("# Choose an option:\t\t\t\t\t#");
            //Console.WriteLine("#\t0 = Menu\t\t\t\t\t#");
            Console.WriteLine("#\t1 = Create New Account\t\t\t\t#");
            Console.WriteLine("#\t2 = Deposit/Withdraw Amount\t\t\t#");
            Console.WriteLine("#\t3 = Attribute Interest\t\t\t\t#");
            Console.WriteLine("#\t4 = Show Account Balance\t\t\t#");
            Console.WriteLine("#\t5 = Show Status\t\t\t\t\t#");
            Console.WriteLine("#\t6 = Exit\t\t\t\t\t#");
            Console.WriteLine("#########################################################");
        }

        private static int MainMenu ()
        {
            int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out int index);

            return index;
        }

        private static void CreateAccountMenu ()
        {
            Console.WriteLine("Create New Account:");
            Console.CursorVisible = false;

            #region Getting Acount Type
            int type = -1;
            do
            {
                Console.Clear();
                PrintReferenceMenu();
                Console.Write("Choose a type: \n");
                Console.Write("0 = ");
                PrintColoredText($"{AccType.SalaryAccount}\n", ConsoleColor.Blue);
                //Console.Write(" | ");
                Console.Write("1 = ");
                PrintColoredText($"{AccType.SavingsAccount}\n", ConsoleColor.Blue);
                //Console.Write(" | ");
                Console.Write("2 = ");
                PrintColoredText($"{AccType.OverdraftAccount}", ConsoleColor.Blue);
            } while ( !int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out type) && ( type < 0 || type > 2 ) );
            #endregion

            Console.WriteLine();

            #region Getting Name of Acccount and creating Account
            Console.CursorVisible = true;
            Console.Write("\nType: ");
            PrintColoredText(( ( AccType ) type ).ToString(), ConsoleColor.Blue);
            Console.Write("\nAccount Name: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            string name = Console.ReadLine();
            Console.ResetColor();
            PrintColoredText($"{Bank.Instance.CreateAccount(( AccType ) type, name)}\n", ConsoleColor.Cyan);
            #endregion
        }

        private static void AddOrRemoveCreditMenu ()
        {
            Console.CursorVisible = false;
            #region Defining whether to deposit or withdraw
            int deposit = -1;
            string mode = string.Empty;
            do
            {
                Console.Clear();
                PrintReferenceMenu();
                Console.Write("0 = ");
                PrintColoredText("Withdraw", ConsoleColor.Blue);
                Console.Write(" | ");
                Console.Write("1 = ");
                PrintColoredText("Deposit", ConsoleColor.Blue);
            } while ( !int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out deposit) || ( deposit < 0 || deposit > 1 ) );
            mode = ( ( deposit == 1 ) ? ( "Deposit" ) : ( "Withdraw" ) );

            #endregion 

            Console.CursorVisible = true;

            #region Getting Account to perform actions on
            int id;
            do
            {
                Console.Clear();
                Console.ResetColor();
                PrintReferenceMenu();
                Console.Write("\nMode: ");
                PrintColoredText(mode, ConsoleColor.Blue);
                Console.Write("\nAccount ID: ");
                Console.ForegroundColor = ConsoleColor.Blue;
            } while ( !int.TryParse(Console.ReadLine(), out id) );

            BankAccount account = Bank.Instance.FindAccount(id);

            if ( account == null )
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"No Account with ID: {id} found...");
                Console.ResetColor();
                return;
            }
            #endregion

            #region Getting amount to deposit/withdraw
            decimal amount;
            do
            {
                Console.Clear();
                Console.ResetColor();
                PrintReferenceMenu();
                Console.Write("\nMode: ");
                PrintColoredText(mode, ConsoleColor.Blue);
                PrintColoredText($"\n{account}", ConsoleColor.Cyan);
                Console.Write("\nAmount: ");
                Console.ForegroundColor = ConsoleColor.Blue;

            } while ( !decimal.TryParse(Console.ReadLine(), out amount) );
            #endregion

            Console.ResetColor();

            #region Performing Transaction
            try
            {
                Bank.Instance.Transaction(id, amount, Convert.ToBoolean(deposit));
            }
            catch ( OverdraftException e )
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }
            catch ( Exception e )
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }
            #endregion 
        }

        private static void PrintReturnClosure ()
        {
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine();
            Console.WriteLine("Press Any Key To Return...");
            Console.ReadKey(true);
            Console.ResetColor();
        }

        private static void PrintColoredText (string _text, ConsoleColor _color)
        {
            Console.ForegroundColor = _color;
            Console.Write(_text);
            Console.ResetColor();
        }
    }
}
