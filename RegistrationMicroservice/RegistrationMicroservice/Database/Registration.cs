﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingApi.Data
{
    public class Registration
    {
        public int ID { get; set; }
        public Nullable<long> AadharNo { get; set; }
        public string PanCard { get; set; }
        public Nullable<int> EmpID { get; set; }
        public string EmpName { get; set; }
        public string Gender { get; set; }
        public string DOB { get; set; }
        public string AccountType { get; set; }
        public string PhoneNo { get; set; }
        public string EmailID { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public Nullable<decimal> InitialAmount { get; set; }
        public int? IsActive { get; set; }
    }
}
