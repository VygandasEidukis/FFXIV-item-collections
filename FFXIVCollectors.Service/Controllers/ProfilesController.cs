using FFXIVCollectors.Application.ControllerHandlers.Profiles.Commands;
using FFXIVCollectors.Application.ControllerHandlers.Profiles.Queries;
using FFXIVCollectors.Service.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FFXIVCollectors.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProfilesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var request = new GetAllProfilesQuery();
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var request = new GetProfileByIdQuery(id);
            var response = await _mediator.Send(request);
            return response is null ? NotFound() : Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProfileAsync([FromBody] ProfileForm profile)
        {
            var request = new CreateProfileCommand(profile.Name, profile.MinionIds, profile.MountIds);
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpPost("{id}/Todo")]
        public async Task<IActionResult> AddTodoItem([FromBody] List<TodoItemForm> todoItemForm, int id)
        {
            var todoItems = todoItemForm.Select(x => (x.Id, x.Type));
            var request = new CreateTodoItemsCommand(todoItems, id);
            var result = await _mediator.Send(request);
            return result is null ? NotFound() : Ok(result);
        }
    }
}
