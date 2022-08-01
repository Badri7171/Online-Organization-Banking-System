using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransactionMicroservice.Models
{
    public class ResponseMessage
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
     
    }
}
