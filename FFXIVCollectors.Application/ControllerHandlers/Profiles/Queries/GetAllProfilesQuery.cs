using FFXIVCollectors.Application.Common.Models.Entity;
using MediatR;

namespace FFXIVCollectors.Application.ControllerHandlers.Profiles.Queries
{
    public class GetAllProfilesQuery : IRequest<List<Profile>>
    {
    }
}
