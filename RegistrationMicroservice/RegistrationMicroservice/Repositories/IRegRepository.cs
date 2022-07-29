using BankingApi.Data;
using RegistrationMicroservice.Database;
using RegistrationMicroservice.Database.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegistrationMicroservice.Repositories
{
    public interface IRegRepository
    {
        Task<List<RegistrationModel>> GetAllRegistrationsAsync();
        Task<RegistrationModel> GetRegistrationByIDAsync(int registrationID);
        Task<int> AddRegistrationAsync(RegistrationModel registrationModel);
        Task UpdateRegistrationAsync(int registrationID, RegistrationModel registrationModel);
        Task DeleteRegistrationAsync(int registrationID, RegistrationModel registrationModel);
    }   
}
