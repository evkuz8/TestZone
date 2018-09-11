using System;
using System.Collections.Generic;

namespace ExcelTester
{
    public partial class CrmProductPrice
    {
        public int Id { get; set; }
        public int Product { get; set; }
        public int? Type { get; set; }
        public double Cost { get; set; }
        public int Category { get; set; }
        public int PieceType { get; set; }
        public bool IsAweightedProduct { get; set; }
        public double? PieceWeight { get; set; }
        public int WeightType { get; set; }

        public virtual CrmProductCategory CategoryNavigation { get; set; }
        public virtual CrmPieceTypes PieceTypeNavigation { get; set; }
        public virtual CrmProduct ProductNavigation { get; set; }
        public virtual CrmProductType TypeNavigation { get; set; }
    }
}
