using System;
using System.Collections.Generic;

namespace ExcelTester
{
    public partial class CrmDemandType
    {
        public CrmDemandType()
        {
            CrmDemands = new HashSet<CrmDemands>();
        }

        public int Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<CrmDemands> CrmDemands { get; set; }
    }
}
