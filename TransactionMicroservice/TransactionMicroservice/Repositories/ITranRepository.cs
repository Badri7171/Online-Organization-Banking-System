using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionMicroservice.Models;

namespace TransactionMicroservice.Repositories
{
    public interface ITranRepository
    {
        Task<List<TransactionHistoryModel>> GetAllTransactionsAsync();
        Task<int> AddTransactionAsync(TransactionHistoryModel transactionHistory);
        Task<TransactionHistoryModel> GetTransactionByIDAsync(int transactionID);
        Task UpdateTransactionAsync(int transactionID, TransactionHistoryModel transactionHistory);

    }
}
