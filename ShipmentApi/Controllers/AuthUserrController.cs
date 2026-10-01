using Applcation.Feature.AuthApplacation.Login.Command;
using Applcation.Feature.AuthApplacation.RegisterUser;
using Applcation.Feature.AuthApplacation.RegisterUser.DTO;
using Applcation.Feature.AuthApplacation.ResetPassword;
using Applcation.Interface.Iservice;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShipmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthUserrController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IEmailService _emailService;

        public AuthUserrController(IMediator mediator,IEmailService emailService)
        {
            _mediator = mediator;
            _emailService = emailService;   
        }

        // POST api/<RegisterUserController>
        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDTO registerUserDTO)
        {
            var command = new RegisterUserCommand { RegisterUser = registerUserDTO };
            var result = await _mediator.Send(command);

            return result.IsSuccess ? Ok(result) : BadRequest(result);


        }
        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] string Email, string Password)
        {
            var command = new ResetPasswordCommand { Email = Email, Password = Password };
            var result = await _mediator.Send(command   );
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("LoginApp")]
        
        public async Task<IActionResult> Login( string Email, string Password)
        {
            var command =  new LoginCommand
            {
                Email = Email,
                Password = Password,

            };
            var Result=await _mediator.Send(command);
            return Ok(Result);
        }
    }
}
