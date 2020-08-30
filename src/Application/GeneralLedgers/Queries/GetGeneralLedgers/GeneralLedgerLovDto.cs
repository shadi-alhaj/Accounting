using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Application.GeneralLedgers.Queries.GetGeneralLedgers
{
    public class GeneralLedgerLovDto
    {
        public Guid Id { get; set; }       
        public string GLNameAr { get; set; }
        public string GlNameEn { get; set; }
    }
}
