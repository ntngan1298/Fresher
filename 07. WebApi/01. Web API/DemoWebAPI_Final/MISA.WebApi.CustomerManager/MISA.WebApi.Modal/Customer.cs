using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebApi.Modal
{
    public class Customer: Entity<Guid>
    {
        public Guid CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string CompanyName { get; set; }
        public string CompanyCodeTax { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string MemberCardCode { get; set; }
        public int? RankCard { get; set; }
        public decimal? DebitAmount { get; set; }
        public string Note { get; set; }


    }
}
