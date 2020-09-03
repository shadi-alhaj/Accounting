using Accounting.Application.TotalAccounts.Commands.CreateCommand;
using Accounting.Application.TotalAccounts.Commands.DeleteCommand;
using Accounting.Application.TotalAccounts.Commands.UpdateCommand;
using Accounting.Application.TotalAccounts.Queries.GetTotalAccounts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounting.WebUI.Controllers
{
    public class TotalAccountsController: ApiController
    {

        [HttpGet("{customerId}")]
        public async Task<ActionResult<TotalAccountVm>> TotalAccounts(Guid customerId)
        {
            var result = await Mediator.Send(new GetTotalAccountsQuery { CustomerId = customerId });
            return result;
        }

        [HttpGet]
        public async Task<ActionResult<TotalAccountDto>> TotalAccount(int mainAccountIdByCustomer, Guid customerId)
        {
            var result = await Mediator.Send(new GetTotalAccountByTotalAccountIdByCustomerAndCustomerIdQuery { TotalAccountIdByCustomer = mainAccountIdByCustomer, CustomerId = customerId });
            return result;
        }

        [HttpGet("{customerId}/{id}")]
        public async Task<ActionResult<int>> MaxTotalAccountIdByCustomer(Guid customerId, int id)
        {
            var result = await Mediator.Send(new GetMaxTotalAccountIdByCustomerIdAndGlIdQuery { CustomerId = customerId, MainAccountIdByCustomer = id });
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateTotalAccount(CreateTotalAccountCommand command)
        {
            var result = await Mediator.Send(command);
            return result;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTotalAccount(Guid id, UpdateTotalAccountCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTotalAccount(Guid id)
        {
            await Mediator.Send(new DeleteTotalAccountCommand { Id = id });
            return NoContent();

        }
    }
}
