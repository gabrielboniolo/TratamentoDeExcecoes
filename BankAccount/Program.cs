using Principal.Entities;
using Pricipal.Entities.Exceptions;
using System.Globalization;

namespace Principal
{
    class Program
    {
        static void Main(string[] args)
        {
            try 
            {
                Console.WriteLine("Enter the account data: ");
                Console.Write("Number: ");
                int accountNumber = int.Parse(Console.ReadLine());
                Console.Write("Holder: ");
                string accountHolder = Console.ReadLine();
                Console.Write("Initial Balance: ");
                double accountInitialBalance = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Withdraw limit: ");
                double accountWithdrawLimit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Account account = new Account(accountNumber, accountHolder, accountInitialBalance, accountWithdrawLimit);
                
                Console.WriteLine();

                Console.Write("Enter the amount for withdraw: ");
                double amount = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                account.Withdraw(amount);
                Console.WriteLine($"New balance: {account.Balance.ToString("F2", CultureInfo.InvariantCulture)}");
            }
            catch(WithdrawException e) 
            {
                Console.WriteLine($"Withdraw error: {e.Message}");
            }

            catch (Exception e) 
            {
                Console.WriteLine($"Unexpected Error: {e.Message}");
            }
        }
    }
}