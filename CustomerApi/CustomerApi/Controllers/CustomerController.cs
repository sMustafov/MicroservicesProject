namespace CustomerApi.Controllers
{
    using System;
    using System.Threading.Tasks;
    using AutoMapper;
    using CustomerApi.Domain.Entities;
    using CustomerApi.Models;
    using CustomerApi.Service.Command;
    using CustomerApi.Service.Query;
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IMediator mediator;
        public CustomerController(IMapper mapper, IMediator mediator)
        {
            this.mapper = mapper;
            this.mediator = mediator;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [HttpPost]
        public async Task<ActionResult<Customer>> Customer([FromBody] CreateCustomerModel createCustomerModel)
        {
            try
            {
                return await this.mediator.Send(new CreateCustomerCommand
                {
                    Customer = this.mapper.Map<Customer>(createCustomerModel)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [HttpPut]
        public async Task<ActionResult<Customer>> Customer([FromBody] UpdateCustomerModel updateCustomerModel)
        {
            try
            {
                var customer = await this.mediator.Send(new GetCustomerByIdQuery
                {
                    Id = updateCustomerModel.Id
                });

                if (customer == null)
                {
                    return BadRequest($"No customer found with the id {updateCustomerModel.Id}");
                }

                return await this.mediator.Send(new UpdateCustomerCommand
                {
                    Customer = this.mapper.Map(updateCustomerModel, customer)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
