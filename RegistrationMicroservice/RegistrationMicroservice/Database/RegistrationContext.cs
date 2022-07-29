using BankingApi.Data;
using Microsoft.EntityFrameworkCore;
using RegistrationMicroservice.Database.Entities;
using System;
using System.Threading.Tasks;

namespace RegistrationMicroservice.Database
{
    public class RegistrationContext : DbContext
    {
        public RegistrationContext(DbContextOptions<RegistrationContext> options)
            : base(options)
        {

        }
        public DbSet<RegistrationModel> Registration { get; set; }

        internal Task SavechangesAsync(Registration registration, string password)
        {
            throw new NotImplementedException();
        }
    }
}
