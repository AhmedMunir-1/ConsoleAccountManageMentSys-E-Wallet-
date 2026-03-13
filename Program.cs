using System;
using System.Collections.Concurrent;
using System.Data;
using EWalletSystem.wallet;
using EWalletSystem.transaction;
using System.Collections.Generic;

namespace AccountManageMentSystem

{

    internal class Program
    {

        static void Main(string[] args)
        {
            // OOP concepts are used in this project to create a simple e-wallet system.
            // Every object is dealing with his own data and not affecting any other object data because of using the encapsulation concept in OOPs
            // Abstraction is used to hide the implementation details and show only the functionality to the user. 
            // In this project, we have hidden the implementation details of the wallet and transactions from the user and only show the functionality of deposit,
            //  withdraw, transfer and change password to the user. The user can use these functionalities without knowing how they are implemented. This is achieved by using classes and methods in C#.
            //  The user can create a wallet object and call the methods to perform the operations without worrying about the internal workings of the wallet and transactions.

            Console.WriteLine("====================== ========================== ===================\n");

            #region creating wallet and doing some operations
            Console.WriteLine("--------- --------");
            //trying to create wallet and do some operations
            Wallet wallet1 = new("012", "1234", "Ahmed", "123");
            wallet1.Deposit(300, "123", "012");
            Console.WriteLine("Deposit 300 to wallet 1");
            wallet1.WithDraw(0, "123", "012");
            Console.WriteLine("Withdraw 200 from wallet 1");
            Console.WriteLine("the balance of wallet 1 Now is 100");
            Wallet wallet2 = new("012", "2345", "Ali", "1234");
            wallet1.Transfer(20, "123", "012", wallet2);
            Console.WriteLine("Transfer 20 from wallet 1 to wallet 2 (fees is 3 so the total amount is 23)");
            Console.WriteLine("--------- --------");
            #endregion

            #region GetBalance
            decimal? balance1 = wallet1.GetBalance("123");
            decimal? balance2 = wallet2.GetBalance("1234");

            if (balance1 is null)
            {
                Console.WriteLine("Wrong password");
            }

            else
            {
                Console.WriteLine($"Balance wallet 1 = {balance1}");
            }
            if (balance2 is null)
            {
                Console.WriteLine("Wrong password");
            }
            else
            {
                Console.WriteLine($"Balance wallet 2 = {balance2}");
            }

            Console.WriteLine("--------- --------");

            #endregion

            #region Transaction History

            Console.WriteLine("--------- --------");

            Console.WriteLine("Transaction history for wallet 1:");
            wallet1.ShowTransactions("1234", "123", "012");

            Console.WriteLine("--------- --------");
            Console.WriteLine("--------- --------");
            
            // history is with the distination too
            Console.WriteLine("Transaction history for wallet 2:");

            wallet2.ShowTransactions("2345", "1234", "012");
            Console.WriteLine("--------- --------");
            #endregion

            #region ChangePassword
            // tring to change password with wrong data
            bool isChanged = wallet1.ChangePassword("12384", "012", "12345");
            Console.WriteLine($"Password change with wrong data: {isChanged}");
            Console.WriteLine("Password change failed");

            wallet1.ChangePassword("1234", "012", "12345");
            isChanged = wallet1.ChangePassword("1234", "012", "12345");
            Console.WriteLine($"Password change with correct data: {isChanged}");
            Console.WriteLine("Password changed successfully");

            #endregion
            // regin for clearing the console and showing the balance of the wallets


            Console.WriteLine("\n====================== ========================== =================== ");

        }
    }
}
