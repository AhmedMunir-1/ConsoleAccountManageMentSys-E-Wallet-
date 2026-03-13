using System;
using System.Collections.Generic;
using EWalletSystem.transaction;

//this is primary constractor started from c# 11  
namespace EWalletSystem.wallet
{
    public class Wallet(string phoneNumber, string nationalId, string name, string password, decimal balance = 0)
    {
        string PhoneNumber = phoneNumber;
        string NationalId = nationalId;
        string Name = name;
        string Password = password;
        decimal Balance = balance; //using in finance
        List<Transaction> transactions = new();


        public bool ChangePassword(string NationalId, string phoneNumber, string newPassword)
        {

            if (NationalId != this.NationalId || phoneNumber != this.PhoneNumber)
                return false;

            this.Password = newPassword;
            return true;

        }


        public bool VlidationData(string phoneNumber, string password)
        {
            if (phoneNumber != this.PhoneNumber || password != this.Password)
                return false;

            return true;
        }


        public bool Deposit(decimal amount, string password, string phoneNumber)
        {
            // False Value First Added
            if (!this.VlidationData(phoneNumber, password))
                return false;

            this.Balance += amount;
            Transaction transaction = new(transactions.Count + 1, "None", "None", DateTime.UtcNow, TransactionStatus.Completed, TransactionType.Deposit, amount);
            this.transactions.Add(transaction);
            return true;
        }

        public bool WithDraw(decimal amount, string password, string phoneNumber)
        {
            if (!this.VlidationData(phoneNumber, password))
                return false;

            if (amount > this.Balance)
                return false;

            this.Balance -= amount;
            Transaction transaction = new(transactions.Count + 1, "None", "None", DateTime.UtcNow, TransactionStatus.Completed, TransactionType.Withdraw, amount);
            this.transactions.Add(transaction);
            return true;
        }

        public bool Transfer(decimal amount, string password, string phoneNumber, Wallet des)
        {
            if (!this.VlidationData(phoneNumber, password))
                return false;

            if (amount > this.Balance)
                return false;

            if (des == null)
                return false;

            const decimal fees = 0.1m;  // m referes to decimal 
            const decimal threShold = 300m; // حد bounder means

            if (amount >= threShold)
            {
                this.Balance -= (amount + (amount * fees)); //هخصمم من الي بيبعت مش الbalance نفسه مع ان في الحالة دي الاتنين واحد
            }
            else if (amount < threShold)
            {
                this.Balance -= (amount + 3m);
            }

            Transaction transaction = new(transactions.Count + 1, this.Name, des.Name, DateTime.UtcNow, TransactionStatus.Completed, TransactionType.Transfer, amount);
            this.transactions.Add(transaction);
            des.transactions.Add(transaction); //Imp
            des.Balance += amount;

            return true;

        }

        public void ShowTransactions(string nationalID, string password, string phoneNumber)
        {
            if (!this.VlidationData(phoneNumber, password) || nationalID != this.NationalId)
                return;

            this.transactions.ForEach(transactions =>
            {
                Console.WriteLine($"Transaction ID: {transactions.Id}");
                Console.WriteLine($"Sender Name: {transactions.SenderName}");
                Console.WriteLine($"Receiver Name: {transactions.ReseverName}");
                Console.WriteLine($"Date: {transactions.Date}");
                Console.WriteLine($"Status: {transactions.Status}");
                Console.WriteLine($"Type: {transactions.Type}");
                Console.WriteLine($"Amount: {transactions.Amount}");
                Console.WriteLine();
            });
        }

        public decimal? GetBalance(string password) // ? for Null possabilty
        {
            if (this.Password != password)
                return null;

            return this.Balance;
        }

    }

}
