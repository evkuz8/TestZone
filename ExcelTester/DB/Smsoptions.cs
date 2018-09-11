using System;
using System.Collections.Generic;

namespace ExcelTester
{
    public partial class Smsoptions
    {
        public int Id { get; set; }
        public int InHoursOfServer { get; set; }
        public int BeforeEventInDays { get; set; }
        public string TextTemplate { get; set; }
    }
}
