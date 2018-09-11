using System;
using System.Collections.Generic;

namespace ExcelTester
{
    public partial class CrmPhones
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public int ClientId { get; set; }

        public virtual CrmClients Client { get; set; }
    }
}
