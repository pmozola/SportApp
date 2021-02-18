using System.Threading.Tasks;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SportApp.Application.QueryHandlers.Exercise;

namespace SportApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExerciseController : ControllerBase
    {
        private readonly ISender sender;

        public ExerciseController(ISender sender)
        {
            this.sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await sender.Send(new GetExerciseListQuery());

            return result.Match<IActionResult>(
                success: data => Ok(data),
                error: exception => BadRequest(exception.Message));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await sender.Send(new GetExerciseQuery(id));

            return result.Match<IActionResult>(
                success: data => Ok(data),
                error: exception => BadRequest(exception.Message));
        }
    }
}
