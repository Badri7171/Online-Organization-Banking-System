using RegistrationMicroservice.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationMicroservice.Database
{
    public class responseMessage
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public List<RegistrationModel> listRegistration { get; set; }
    }
}
