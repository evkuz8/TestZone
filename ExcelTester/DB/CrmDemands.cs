using System;
using System.Collections.Generic;

namespace ExcelTester
{
    public partial class CrmDemands
    {
        public CrmDemands()
        {
            CashCheck = new HashSet<CashCheck>();
            CrmProductList = new HashSet<CrmProductList>();
        }

        public int Id { get; set; }
        public int? ClientId { get; set; }
        public int? Type { get; set; }
        public string Fio { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Street { get; set; }
        public string Comment { get; set; }
        public DateTime? Date { get; set; }
        public int? Wherefrom { get; set; }
        public string UserId { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? IdPayMet { get; set; }

        public virtual CrmClients Client { get; set; }
        public virtual PaymentMethod IdPayMetNavigation { get; set; }
        public virtual CrmDemandType TypeNavigation { get; set; }
        public virtual AspNetUsers User { get; set; }
        public virtual CrmWhereFrom WherefromNavigation { get; set; }
        public virtual ICollection<CashCheck> CashCheck { get; set; }
        public virtual ICollection<CrmProductList> CrmProductList { get; set; }
    }
}
