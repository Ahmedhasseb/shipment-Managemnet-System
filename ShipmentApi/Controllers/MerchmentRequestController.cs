using Applcation.Feature.MerchantRequest.DTO;

using Applcation.Feature.MerchantRequests.Command.CreateRequestMerchmant;
using Applcation.Feature.MerchantRequests.Command.UpdatemarchmentRequest;
using Applcation.Feature.MerchantRequests.Query.GetAllMarchmentApproved;
using Applcation.Feature.MerchantRequests.Query.GettAllMerchament;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShipmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchmentRequestController : ControllerBase

    {
        private readonly IMediator _mediator;

        public MerchmentRequestController(IMediator mediator) => _mediator = mediator;

        // GET: api/<MerchmentRequestController>
        [HttpGet("GetAllMarchmentApproved")]
        public async Task<IActionResult> GetAllMerchamentApproved()
        {
            var Result = await _mediator.Send(new GetAllMerchantRequsetQuery());

            return Ok(Result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMarchment()
        {
            var Result = await _mediator.Send(new GetAllMarchmentQuery());

            return Ok(Result);
        }

        // POST api/<MerchmentRequestController>
        [HttpPost]
        public async Task<IActionResult> CreateMerchmantRequest([FromBody] RegisterMerchantRequest registerMerchant)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var CreateCommand = new MerchmantRequestCommand { registerMerchantRequest = registerMerchant };
            var Result = await _mediator.Send(CreateCommand);
            return Result is not null ? Ok(Result) : BadRequest();
        }

        [HttpPatch("id:{id}")]
        public async Task<IActionResult> AccpectMerchament(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var Command = new UpdateMerchmentrequestCommand { Id = id };
            var result = await _mediator.Send(Command);
            return result is not null ? Ok(result) : BadRequest();
        }


    }
}
