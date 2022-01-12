using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVin_Code_Challenge.Shared.DTO.Response
{
    public class TransactionResponse
    {
        public string Bank { get; set; }
        public string FirstName { get; set; }
        public string OtherName { get; set; }
        public string Surname { get; set; }
        public string CustomerName => $"{FirstName} {OtherName} {Surname}";
        public string AccountType { get; set; }
        public string AccountNumber { get; set; }
        public string TransactionType { get; set; }
        public double Amount { get; set; }
    }
}
