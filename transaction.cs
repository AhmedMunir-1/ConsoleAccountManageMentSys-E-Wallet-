using System;
using System.Collections.Generic;
using EWalletSystem.wallet;

namespace EWalletSystem.transaction
{
    public enum TransactionType
    {
        Deposit,
        Withdraw,
        Transfer
    }

    public enum TransactionStatus
    {
        Pending,
        Completed,
        Cancled
    }

    public class Transaction
    {
        public int Id { get; }
        public string SenderName { get; set; }
        public string ReseverName { get; set; }
        public DateTime Date { get; set; }
        public TransactionStatus Status { get; set; }
        public TransactionType Type { get; set; }
        public decimal Amount { get; set; }

        public Transaction(int id, string senderName, string reseverName, DateTime date, TransactionStatus status, TransactionType type, decimal amount)
        {
            Id = id;
            SenderName = senderName;
            ReseverName = reseverName;
            Date = date;
            Status = status;
            Type = type;
            Amount = amount;
        }

    }
}
