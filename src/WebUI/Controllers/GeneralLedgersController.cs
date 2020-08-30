using Accounting.Application.GeneralLedgers.Commands.CreateCommand;
using Accounting.Application.GeneralLedgers.Commands.DeleteCommand;
using Accounting.Application.GeneralLedgers.Commands.UpdateCommand;
using Accounting.Application.GeneralLedgers.Queries.GetGeneralLedgers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Accounting.WebUI.Controllers
{
    public class GeneralLedgersController: ApiController
    {
        [HttpGet]
        public async Task<ActionResult<GeneralLedgerVm>> GeneralLedgers(Guid customerId)
        {
            var result = await Mediator.Send(new GetGeneralLedgersQuery { CustomerId = customerId });
            return result;
        }

        [HttpGet("GlMaxIdByCustomerId{customerId}")]
        public async Task<ActionResult<int>> GlMaxIdByCustomerId(Guid customerId)
        {
            var result = await Mediator.Send(new GetMaxGlIdByCustomerIdQuery { CustomerId = customerId });
            return result;
        }

        [HttpGet("{customerId}")]
        public async Task<ActionResult<GeneralLedgerLovVm>> GeneralLedgersLov(Guid customerId)
        {
            var result = await Mediator.Send(new GetGeneralLedgerLovQuery { CustomerId = customerId });
            return result;
        }

        [HttpGet("GeneralLedgerByGlIdCustomerAndCustomerId/{customerId}/{id}")]
        public async Task<ActionResult<GeneralLedgerDto>> GeneralLedgerByGlIdCustomerAndCustomerId(Guid customerId, int id)
        {
            var result = await Mediator.Send(new GetGLByGlIdCustomerAndCustomerIdQuery { CustomerId = customerId, Id = id });
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateGeneralLedger(CreateGeneralLedgerCommand command)
        {
            var result = await Mediator.Send(command);
            return result;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateGeneralLedger(Guid id, UpdateGeneralLedgerCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGeneralLedger(Guid id)
        {
            await Mediator.Send(new DeleteGeneralLedgerCommand { Id = id });
            return NoContent();
        }
    }
}
