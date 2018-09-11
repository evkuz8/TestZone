using System;
using System.Collections.Generic;

namespace ExcelTester
{
    public partial class BonusCard
    {
        public int IdBonusCard { get; set; }
        public string NumberCard { get; set; }
        public decimal BonusCount { get; set; }
        public int IdClients { get; set; }

        public virtual CrmClients IdClientsNavigation { get; set; }
    }
}
