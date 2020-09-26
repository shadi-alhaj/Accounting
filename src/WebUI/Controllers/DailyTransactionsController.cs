using Accounting.Application.DailyTransactions.Commands.CreateCommand;
using Accounting.Application.DailyTransactions.Queries.GetDailyTransactions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounting.WebUI.Controllers
{
    public class DailyTransactionsController: ApiController
    {

        [HttpGet]
        public async Task<ActionResult<DailyTransactionVm>> DailyTransactionBySNoAndFinanceYearQuery(Guid customerId, int financeYear, int bondSno)
        {
            var result = await Mediator.Send(new GetDailyTransactionBySNoAndFinanceYearQuery { CustomerId = customerId, FinanceYear = financeYear, BondSNo = bondSno });
            return result;
        }

        [HttpGet("FirstDailyTransactionRecord")]
        public async Task<ActionResult<DailyTransactionVm>> FirstDailyTransactionRecord(Guid customerId, int financeYear)
        {
            var result = await Mediator.Send(new GetFirstDailyTransactionQuery { CustomerId = customerId, FinanceYear = financeYear });
            return result;
        }

        [HttpGet("LastDailyTransactionRecord")]
        public async Task<ActionResult<DailyTransactionVm>> LastDailyTransactionRecord(Guid customerId, int financeYear)
        {
            var result = await Mediator.Send(new GetLastDailyTransactionQuery { CustomerId = customerId, FinanceYear = financeYear });
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateDailyTransaction(CreateDailyTransactionCommand command)
        {
            var result = await Mediator.Send(command);
            return result;
        }
    }
}
