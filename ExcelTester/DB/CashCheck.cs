using System;
using System.Collections.Generic;

namespace ExcelTester
{
    public partial class CashCheck
    {
        public int IdChek { get; set; }
        public int IdDemands { get; set; }
        public decimal? BonusPlus { get; set; }
        public decimal? BonusMinus { get; set; }
        public decimal CostInPrice { get; set; }
        public decimal? Delivery { get; set; }
        public decimal Sum { get; set; }

        public virtual CrmDemands IdDemandsNavigation { get; set; }
    }
}
