using FFXIVCollectors.Application.Common.Interfaces;
using MediatR;

namespace FFXIVCollectors.Application.ControllerHandlers.Collectables.Queries
{
    public class GetAllCollectablesQuery : IRequest<List<ICollectable>>
    {
    }
}
