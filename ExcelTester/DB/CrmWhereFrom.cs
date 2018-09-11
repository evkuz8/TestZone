using System;
using System.Collections.Generic;

namespace ExcelTester
{
    public partial class CrmWhereFrom
    {
        public CrmWhereFrom()
        {
            CrmDemands = new HashSet<CrmDemands>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CrmDemands> CrmDemands { get; set; }
    }
}
