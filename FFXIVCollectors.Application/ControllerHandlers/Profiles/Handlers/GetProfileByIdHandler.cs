using FFXIVCollectors.Application.Common.Interfaces.Persistance;
using FFXIVCollectors.Application.Common.Models.Entity;
using FFXIVCollectors.Application.ControllerHandlers.Profiles.Queries;
using MediatR;

namespace FFXIVCollectors.Application.ControllerHandlers.Profiles.Handlers
{
    public class GetProfileByIdHandler : IRequestHandler<GetProfileByIdQuery, Profile>
    {
        private readonly IProfileRepository _profileRepository;

        public GetProfileByIdHandler(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public async Task<Profile> Handle(GetProfileByIdQuery request, CancellationToken cancellationToken)
        {
            return await _profileRepository.Get(request.ProfileId);
        }
    }
}
