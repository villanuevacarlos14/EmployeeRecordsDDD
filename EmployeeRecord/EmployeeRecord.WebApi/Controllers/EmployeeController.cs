using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeRecord.Domain.ValueObjects;
using EmployeeRecord.WebApi.Employee;
using EmployeeRecord.WebApi.Employee.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRecord.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetEmployeesQuery query) => Ok(await _mediator.Send(query));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AddEmployeeCommand command) => Ok(await _mediator.Send(command));

        [HttpPut]
        public async Task<IActionResult> Post([FromBody]UpdateEmployeeCommand command) =>Ok(await _mediator.Send(command));
        
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery]DeleteEmployeeCommand command) =>Ok(await _mediator.Send(command));

    }
}
