using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationMicroservice.Database.Entities
{
    public class RegistrationModel
    {

        public int ID { get; set; }


        public long AadharNo { get; set; }

        public string PanCard { get; set; }

        public int EmpID { get; set; }

        public string EmpName { get; set; }

        public string Gender { get; set; }

        public string DOB { get; set; }
        
        public string AccountType { get; set; }

        public string PhoneNo { get; set; }

        public string EmailID { get; set; }

        public string Address { get; set; }

        public string Password { get; set; }

        public decimal InitialAmount { get; set; }

        public int IsActive { get; set; }
        public string Type { get; set; }
    }
   }


