using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Application.Bonds.Queries.GetBonds
{
    public class BondDailyTransactionDto
    {
        public Guid BondId { get; set; }
        public string BondNameAr { get; set; }
        public string BondNameEn { get; set; }
        public int BondMaxSNo { get; set; }
    }
}
