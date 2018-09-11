using System;
using System.Collections.Generic;

namespace ExcelTester
{
    public partial class BonusInMoney
    {
        public int Id { get; set; }
        public decimal Bonus { get; set; }
        public decimal InMoney { get; set; }
        public decimal MinSum { get; set; }
        public decimal Percent { get; set; }
    }
}
