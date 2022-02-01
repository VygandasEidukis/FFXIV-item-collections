using FFXIVCollectors.Application.Common.Interfaces;
using FFXIVCollectors.Application.ControllerHandlers.Collectables.Queries;
using MediatR;

namespace FFXIVCollectors.Application.ControllerHandlers.Collectables.Handlers
{
    public class GetAllCollectablesHandler : IRequestHandler<GetAllCollectablesQuery, List<ICollectable>>
    {
        private readonly IFinalFantasyCollectionService _ffColectionService;

        public GetAllCollectablesHandler(IFinalFantasyCollectionService ffColectionService)
        {
            _ffColectionService = ffColectionService;
        }

        public async Task<List<ICollectable>> Handle(GetAllCollectablesQuery request, CancellationToken cancellationToken)
        {
            var mounts = await _ffColectionService.GetMounts();
            var minions = await _ffColectionService.GetMinions();
            return new List<ICollectable>()
                .Concat(mounts)
                .Concat(minions)
                .OrderBy(x => x.Id)
                .ToList();
        }
    }
}
