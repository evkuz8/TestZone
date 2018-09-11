using System;
using System.Collections.Generic;

namespace ExcelTester
{
    public partial class CrmPieceTypes
    {
        public CrmPieceTypes()
        {
            CrmProductPrice = new HashSet<CrmProductPrice>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CrmProductPrice> CrmProductPrice { get; set; }
    }
}
