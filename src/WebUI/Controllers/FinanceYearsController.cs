using Accounting.Application.FinanceYears.Commands.CreateCommand;
using Accounting.Application.FinanceYears.Commands.DeleteCommand;
using Accounting.Application.FinanceYears.Commands.UpdateCommand;
using Accounting.Application.FinanceYears.Queries.GetFinanceYears;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounting.WebUI.Controllers
{
    public class FinanceYearsController: ApiController
    {

        [HttpGet]
        public async Task<ActionResult<FinanceYearVm>> FinanceYears()
        {
            var result = await Mediator.Send(new GetFinanceYearsQuery());
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateFinanceYear(CreateFinanceYearCommand command)
        {
            var result = await Mediator.Send(command);
            return result;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateFinanceYear(Guid id, UpdateFinanceYearCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFinanceYear(Guid id)
        {
            await Mediator.Send(new DeleteFinanceYearCommand { Id = id });
            return NoContent();
        }
    }
}
