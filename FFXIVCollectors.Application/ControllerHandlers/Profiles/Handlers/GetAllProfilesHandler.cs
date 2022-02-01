using FFXIVCollectors.Application.Common.Interfaces.Persistance;
using FFXIVCollectors.Application.Common.Models.Entity;
using FFXIVCollectors.Application.ControllerHandlers.Profiles.Queries;
using MediatR;

namespace FFXIVCollectors.Application.ControllerHandlers.Profiles.Handlers
{
    public class GetAllProfilesHandler : IRequestHandler<GetAllProfilesQuery, List<Profile>>
    {
        private readonly IProfileRepository _profileRepository;

        public GetAllProfilesHandler(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public async Task<List<Profile>> Handle(GetAllProfilesQuery request, CancellationToken cancellationToken)
        {
            var result = await _profileRepository.GetAll();
            return result.ToList();
        }
    }
}
