using AutoMapper;
using BankingApi.Data;
using RegistrationMicroservice.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationMicroservice.Helpers
{
    public class ApplicationMapper : Profile
    {

        public ApplicationMapper()
        {
            CreateMap<Registration, RegistrationModel>().ReverseMap();
        }
      
    }
}
