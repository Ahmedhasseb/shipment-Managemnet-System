using Applcation.Feature.ManagerBranch.Command.CreateManager;
using Applcation.Feature.ManagerBranch.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShipmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ManagerController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> RegisterManager([FromBody] RegisterManagerBranchDTO managerBranch)
        {
            // Implementation for registering manager branch
            if(!ModelState.IsValid)
                return BadRequest(ModelState);  

            var CraeteCommand = new RegisterManagerCommand { RegisterManagerBranch=managerBranch };
            var Result = await _mediator.Send(CraeteCommand);
            return Result is not null?Ok(Result):BadRequest();
        }
    }
}
