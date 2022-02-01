using FFXIVCollectors.Application.Common.Models.Entity;
using MediatR;

namespace FFXIVCollectors.Application.ControllerHandlers.Profiles.Queries
{
    public class GetProfileByIdQuery : IRequest<Profile>
    {
        public int ProfileId { get; set; }

        public GetProfileByIdQuery(int profileId)
        {
            ProfileId = profileId;
        }
    }
}
