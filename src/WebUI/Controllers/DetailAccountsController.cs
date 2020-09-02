using Accounting.Application.DetailAccounts.Queries.GetDetailAccounts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounting.WebUI.Controllers
{
    public class DetailAccountsController: ApiController
    {
        [HttpGet("customerId")]
        public async Task<ActionResult<DetailAccountVm>> DetailAccounts(Guid customerId)
        {
            var result = await Mediator.Send(new GetDetailAccountsQuery { CustomerId = customerId });
            return result;
        }
    }
}
