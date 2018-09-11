using System;
using System.Collections.Generic;

namespace ExcelTester
{
    public partial class CrmClients
    {
        public CrmClients()
        {
            BonusCardNavigation = new HashSet<BonusCard>();
            CrmContactClients = new HashSet<CrmContactClients>();
            CrmDemands = new HashSet<CrmDemands>();
            CrmPhones = new HashSet<CrmPhones>();
        }

        public int Id { get; set; }
        public string LastName { get; set; }
        public string MidName { get; set; }
        public string FirstName { get; set; }
        public DateTime? DateBirdth { get; set; }
        public bool BonusCard { get; set; }
        public string Comment { get; set; }
        public bool? AllowSendMessages { get; set; }

        public virtual ICollection<BonusCard> BonusCardNavigation { get; set; }
        public virtual ICollection<CrmContactClients> CrmContactClients { get; set; }
        public virtual ICollection<CrmDemands> CrmDemands { get; set; }
        public virtual ICollection<CrmPhones> CrmPhones { get; set; }
    }
}
