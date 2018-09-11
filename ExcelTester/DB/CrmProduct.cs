using System;
using System.Collections.Generic;

namespace ExcelTester
{
    public partial class CrmProduct
    {
        public CrmProduct()
        {
            CrmProductList = new HashSet<CrmProductList>();
            CrmProductPrice = new HashSet<CrmProductPrice>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }

        public virtual ICollection<CrmProductList> CrmProductList { get; set; }
        public virtual ICollection<CrmProductPrice> CrmProductPrice { get; set; }
    }
}
