using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using TransactionMicroservice.Models;

namespace TransactionMicroservice.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Transaction, TransactionHistoryModel>().ReverseMap();
        }
    }
}
