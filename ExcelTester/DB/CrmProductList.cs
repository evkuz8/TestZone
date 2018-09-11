using System;
using System.Collections.Generic;

namespace ExcelTester
{
    public partial class CrmProductList
    {
        public int Id { get; set; }
        public int Product { get; set; }
        public int? Type { get; set; }
        public decimal? Kilograms { get; set; }
        public int Count { get; set; }
        public double? Cost { get; set; }
        public int Demand { get; set; }

        public virtual CrmDemands DemandNavigation { get; set; }
        public virtual CrmProduct ProductNavigation { get; set; }
        public virtual CrmProductType TypeNavigation { get; set; }
    }
}
