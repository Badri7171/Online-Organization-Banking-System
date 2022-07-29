using AutoMapper;
using BankingApi.Data;
using Microsoft.EntityFrameworkCore;
using RegistrationMicroservice.Database;
using RegistrationMicroservice.Database.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegistrationMicroservice.Repositories
{
    public class RegRepository : IRegRepository
    {
        private readonly RegistrationContext _context;
        private readonly IMapper _mapper;

        public RegRepository(RegistrationContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<RegistrationModel>> GetAllRegistrationsAsync()
        {
            var records = await _context.Registration.ToListAsync();
            return _mapper.Map<List<RegistrationModel>>(records);
        }
        public async Task<RegistrationModel> GetRegistrationByIDAsync(int registrationID)
        {           
            var registartion = await _context.Registration.FindAsync(registrationID);
            return _mapper.Map<RegistrationModel>(registartion);
        }
        public async Task<int> AddRegistrationAsync(RegistrationModel registrationModel)
        {
            var registration = new Registration()
            {
                AadharNo = registrationModel.AadharNo,
                PanCard = registrationModel.PanCard,
                EmpID = registrationModel.EmpID,
                EmpName = registrationModel.EmpName,
                Gender = registrationModel.Gender,
                DOB = registrationModel.DOB,
                AccountType = registrationModel.AccountType,
                PhoneNo = registrationModel.PhoneNo,
                EmailID = registrationModel.EmailID,
                Address = registrationModel.Address,
                Password = registrationModel.Password,
                InitialAmount = registrationModel.InitialAmount,
                IsActive = registrationModel.IsActive
            };
            _context.Registration.Add(registrationModel);
            _context.SaveChangesAsync();

            return registration.ID;

        }
        public async Task UpdateRegistrationAsync(int registrationID, RegistrationModel registrationModel)
        {
            var registration = await _context.Registration.FindAsync(registrationID);
            if (registration != null)
            {
                registration.AadharNo = registrationModel.AadharNo;
                registration.PanCard = registrationModel.PanCard;
                registration.EmpID = registrationModel.EmpID;
                registration.EmpName = registrationModel.EmpName;
                registration.Gender = registrationModel.Gender;
                registration.DOB = registrationModel.DOB;
                registration.AccountType = registrationModel.AccountType;
                registration.PhoneNo = registrationModel.PhoneNo;
                registration.EmailID = registrationModel.EmailID;
                registration.Address = registrationModel.Address;
                registration.Password = registrationModel.Password;
                registration.InitialAmount = registrationModel.InitialAmount;
                registration.IsActive = registrationModel.IsActive;

                await _context.SaveChangesAsync();
            };
        }
        public async Task DeleteRegistrationAsync(int registrationID,RegistrationModel registrationModel)
         {
            var registration = new Registration() { ID = registrationID };
            _context.Registration.Remove(registrationModel);
            await _context.SaveChangesAsync();


        }
        
        
    } 
}
