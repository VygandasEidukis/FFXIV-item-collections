using FFXIVCollectors.Application.ControllerHandlers.Collectables.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FFXIVCollectors.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectablesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CollectablesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var query = new GetAllCollectablesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
