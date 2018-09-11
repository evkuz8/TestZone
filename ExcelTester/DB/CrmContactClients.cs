using System;
using System.Collections.Generic;

namespace ExcelTester
{
    public partial class CrmContactClients
    {
        public int Id { get; set; }
        public int IdClients { get; set; }
        public string Fio { get; set; }
        public string Phone { get; set; }

        public virtual CrmClients IdClientsNavigation { get; set; }
    }
}
