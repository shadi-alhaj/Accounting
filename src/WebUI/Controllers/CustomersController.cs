using Accounting.Application.Customers.Commands.CreateCommand;
using Accounting.Application.Customers.Commands.DeleteCommand;
using Accounting.Application.Customers.Commands.UpdateCommand;
using Accounting.Application.Customers.Queries;
using Accounting.Application.Customers.Queries.GetCustomers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounting.WebUI.Controllers
{
    public class CustomersController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<CustomerVm>> Customers()
        {
            var result = await Mediator.Send(new GetCustomersQuery());
            return result;
        }

        [HttpGet("CustomersLov")]
        public async Task<ActionResult<CustomerLovVm>> CustomersLov()
        {
            var result = await Mediator.Send(new GetCustomerLovQuery());
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateCustomer(CreateCustomerCommand command)
        {
            var result = await Mediator.Send(command);
            return result;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCustomer(Guid id)
        {
            await Mediator.Send(new DeleteCustomerCommand { Id = id });
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCustomer(Guid id, UpdateCustomerCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
