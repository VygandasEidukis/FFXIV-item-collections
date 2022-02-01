using FFXIVCollectors.Application.Common.Interfaces;
using FFXIVCollectors.Application.Common.Interfaces.Persistance;
using FFXIVCollectors.Application.Common.Models.Collectables;
using FFXIVCollectors.Application.Common.Models.Entity;
using FFXIVCollectors.Application.ControllerHandlers.Profiles.Commands;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FFXIVCollectors.Application.ControllerHandlers.Profiles.Handlers
{
    public class CreateTodoItemsHandler : IRequestHandler<CreateTodoItemsCommand, Profile>
    {
        private readonly ILogger<CreateTodoItemsHandler> _logger;
        private readonly IMinionRepository _minionRepository;
        private readonly IMountRepository _mountRepository;
        private readonly IProfileRepository _profileRepository;
        public CreateTodoItemsHandler(ILogger<CreateTodoItemsHandler> logger,
                                      IMountRepository mountRepository,
                                      IMinionRepository minionRepository,
                                      IProfileRepository profileRepository)
        {
            _logger = logger;
            _mountRepository = mountRepository;
            _minionRepository = minionRepository;
            _profileRepository = profileRepository;
        }

        public async Task<Profile> Handle(CreateTodoItemsCommand request, CancellationToken cancellationToken)
        {
            var orderedCollectables = OrderCollectables(request.TodoItems);
            var collectables = await GetCollectables(orderedCollectables);

            return await _profileRepository.AddCollectablesToTodo(request.Profile, collectables);
        }

        private async Task<List<ICollectable>> GetCollectables(Dictionary<CollectableType, List<int>> orderedCollectables)
        {
            var collectables = new List<ICollectable>();
            foreach (var type in orderedCollectables)
            {
                switch (type.Key)
                {
                    case CollectableType.Minion:
                        var minions = await _minionRepository.GetMinions(type.Value);
                        collectables.AddRange(minions);
                        break;
                    case CollectableType.Mount:
                        var mounts = await _mountRepository.GetMounts(type.Value);
                        collectables.AddRange(mounts);
                        break;
                    default:
                        _logger.LogError("Type is not defined {0}", type.Key);
                        break;
                }
            }

            return collectables;
        }

        private Dictionary<CollectableType, List<int>> OrderCollectables(IEnumerable<(int id, int type)> collectables)
        {
            var orderedCollectables = new Dictionary<CollectableType, List<int>>();

            foreach (var collectable in collectables)
            {
                if (!Enum.IsDefined(typeof(CollectableType), collectable.type))
                {
                    _logger.LogError("Collectable type '{0}' is not defined", collectable.type);
                    continue;
                }

                var type = (CollectableType)collectable.type;
                if (!orderedCollectables.ContainsKey(type))
                {
                    orderedCollectables.Add(type, new List<int>());
                }

                orderedCollectables[type].Add(collectable.id);
            }

            return orderedCollectables;
        }
    }
}
