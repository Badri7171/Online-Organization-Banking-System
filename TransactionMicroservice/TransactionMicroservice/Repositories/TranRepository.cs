using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionMicroservice.Database;
using TransactionMicroservice.Models;

namespace TransactionMicroservice.Repositories
{
    public class TranRepository : ITranRepository
    {

           private readonly TransactionContext _context;
        private readonly IMapper _mapper;

        public TranRepository(TransactionContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
        }
          public async Task<List<TransactionHistoryModel>> GetAllTransactionsAsync()
        {
            var records = await _context.Transaction.ToListAsync();
            return _mapper.Map<List<TransactionHistoryModel>>(records);
        }
            public async Task<TransactionHistoryModel> GetTransactionByIDAsync(int transactionID)
            {
            
            var transaction = await _context.Transaction.FindAsync(transactionID);
            return _mapper.Map<TransactionHistoryModel>(transaction);

        }
            public async Task<int> AddTransactionAsync(TransactionHistoryModel transactionHistory)
            {
                var transaction = new Transaction()
                {
                    FromAccount = transactionHistory.FromAccount,
                    ToAccount = transactionHistory.ToAccount,
                    Amount = transactionHistory.Amount,
                    UsedAmount = transactionHistory.UsedAmount,
                    Balance = transactionHistory.Balance,
                    TransactionDate = transactionHistory.TransactionDate

                };
                _context.Transaction.Add(transactionHistory);
                _context.SaveChangesAsync();

                return transaction.ID;
            }
        public async Task UpdateTransactionAsync(int transactionID, TransactionHistoryModel transactionHistory)
        {
            var transaction = await _context.Transaction.FindAsync(transactionID);
            if (transaction != null)
            {
                transaction.FromAccount = transactionHistory.FromAccount;
                transaction.ToAccount = transactionHistory.ToAccount;
                transaction.Amount = transactionHistory.Amount;
                transaction.UsedAmount = transactionHistory.UsedAmount;
                transaction.Balance = transactionHistory.Balance;
                transaction.TransactionDate = transactionHistory.TransactionDate;

                await _context.SaveChangesAsync();
            };
        }
    }
    }



