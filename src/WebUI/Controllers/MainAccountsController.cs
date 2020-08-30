using Accounting.Application.MainAccounts.Commands.CreateCommand;
using Accounting.Application.MainAccounts.Commands.DeleteCommand;
using Accounting.Application.MainAccounts.Commands.UpdateCommand;
using Accounting.Application.MainAccounts.Queries.GetMainAccounts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounting.WebUI.Controllers
{
    public class MainAccountsController: ApiController
    {
        [HttpGet("customerId")]
        public async Task<ActionResult<MainAccountVm>> MainAccounts(Guid customerId)
        {
            var result = await Mediator.Send(new GetMainAccountsQuery { CustomerId = customerId });
            return result;
        }

        [HttpGet("{customerId}/{id}")]
        public async Task<ActionResult<int>> MaxMainAccountIdByCustomer(Guid customerId, int id)
        {
            var result = await Mediator.Send(new GetMaxMainAccountIdByCustomerIdAndGlIdQuery { CustomerId = customerId, GlIdByCustomer = id });
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateMainAccount(CreateMainAccountCommand command)
        {
            var result = await Mediator.Send(command);
            return result;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMainAccount(Guid id, UpdateMainAccountCommand command)
        {
            if(id != command.Id)
            {
                return BadRequest();
            }
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMainAccount(Guid id)
        {
            await Mediator.Send(new DeleteMainAccountCommand { Id = id });
            return NoContent();

        }
    }
}
