using Accounting.Application.Bonds.Commands.CreateCommand;
using Accounting.Application.Bonds.Commands.DeleteCommand;
using Accounting.Application.Bonds.Commands.UpdateCommand;
using Accounting.Application.Bonds.Queries.GetBonds;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounting.WebUI.Controllers
{
    public class BondsController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<BondVm>> Bonds(Guid customerId)
        {
            var result = await Mediator.Send(new GetBondsQuery { CustomerId = customerId });
            return result;
        }

        [HttpGet("BondMaxIdByCustomerId")]
        public async Task<ActionResult<int>> BondMaxIdByCustomerId(Guid customerId)
        {
            var result = await Mediator.Send(new GetBondMaxIdByCustomerIdQuery { CustomerId = customerId });
            return result;
        }

        [HttpGet("BondByCustomerIdAndBondCustomerIdQuery/{customerId}/{bondUserId}/{finYear}")]
        public async Task<ActionResult<BondDailyTransactionDto>> BondByCustomerIdAndBondCustomerIdQuery(Guid customerId, int bondUserId, int finYear)
        {
            var result = await Mediator.Send(new GetBondByCustomerIdAndBondCustomerIdQuery { CustomerId = customerId, BondUserId = bondUserId, FinYear = finYear });
            return result;
        }

        [HttpPost]
        public async Task <ActionResult<Guid>> CreateBond(CreateBondCommand command)
        {
            var result = await Mediator.Send(command);
            return result;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBond(Guid id, UpdateBondCommand command)
        {
            if(id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBond(Guid id) {
            await Mediator.Send(new DeleteBondCommand { Id = id });
            return NoContent();
        }
    }
}
