using System;
using System.Collections.Generic;

namespace ExcelTester
{
    public partial class PaymentMethod
    {
        public PaymentMethod()
        {
            CrmDemands = new HashSet<CrmDemands>();
        }

        public int IdPayMethod { get; set; }
        public string PayMethod { get; set; }

        public virtual ICollection<CrmDemands> CrmDemands { get; set; }
    }
}
