using System.Threading.Tasks;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SportApp.Application.CommandHandlers;

namespace SportApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeightController : ControllerBase
    {
        private readonly ISender sender;

        public WeightController(ISender sender)
        {
            this.sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddWeightCommand command)
        {
            var result = await sender.Send(command);

            return result.Match<IActionResult>(
                success: () => Ok(),
                error: exception => BadRequest(exception.Message));
        }
    }
}
