using Applcation;
using Applcation.Feature.Branches;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShipmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BranchController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateBranch([FromBody] BranchDTO branch)
        {
            // Implementation for creating branch
            if(branch is null)
                return BadRequest();
            var Command = new CreateBranchCommand { branchDTO = branch };
            var ResultMediator=await _mediator.Send(Command);

            return ResultMediator is not null ? Ok(ResultMediator) : BadRequest();
        }
    }
}
