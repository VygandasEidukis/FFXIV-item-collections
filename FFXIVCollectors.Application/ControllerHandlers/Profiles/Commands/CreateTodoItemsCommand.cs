using FFXIVCollectors.Application.Common.Models.Entity;
using MediatR;

namespace FFXIVCollectors.Application.ControllerHandlers.Profiles.Commands
{
    public class CreateTodoItemsCommand : IRequest<Profile>
    {
        public IEnumerable<(int id, int type)> TodoItems;
        public int Profile { get; }

        public CreateTodoItemsCommand(IEnumerable<(int id, int type)> todoItems, int profile)
        {
            TodoItems = todoItems;
            Profile = profile;
        }
    }
}
