using Accounting.Application.DetailAccounts.Commands.CreateCommand;
using Accounting.Application.DetailAccounts.Commands.DeleteCommand;
using Accounting.Application.DetailAccounts.Commands.UpdateCommand;
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


        [HttpGet("{customerId}/{id}")]
        public async Task<ActionResult<int>> MaxDetailAccountIdByCustomer(Guid customerId, int id)
        {
            var result = await Mediator.Send(new GetMaxDetailAccountIdByCustomerIdAndTotalIdQuery { CustomerId = customerId, TotalAccountIdByCustomer = id });
            return result;
        }

        [HttpGet]
        public async Task<ActionResult<DetailAccountDetailsVm>> DetailAccount(Guid customerId, int detailAccountIdByCustomer)
        {
            var result = await Mediator.Send(new GetDetailAccountDetailsQuery { CustomerId = customerId, DetailAccountIdByCustomer = detailAccountIdByCustomer });
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateDetailAccount(CreateDetailAccountCommand command)
        {
            var result = await Mediator.Send(command);
            return result;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDetailAccount(Guid id, UpdateDetailAccountCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDetailAccount(Guid id)
        {
            await Mediator.Send(new DeleteDetailAccountCommand { Id = id });
            return NoContent();

        }
    }
}
