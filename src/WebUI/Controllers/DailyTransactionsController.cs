using Accounting.Application.DailyTransactions.Commands.CreateCommand;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounting.WebUI.Controllers
{
    public class DailyTransactionsController: ApiController
    {

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateDailyTransaction(CreateDailyTransactionCommand command)
        {
            var result = await Mediator.Send(command);
            return result;
        }
    }
}
