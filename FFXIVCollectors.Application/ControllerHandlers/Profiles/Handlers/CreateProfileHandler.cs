using FFXIVCollectors.Application.Common.Interfaces;
using FFXIVCollectors.Application.Common.Interfaces.Persistance;
using FFXIVCollectors.Application.Common.Models.Entity;
using FFXIVCollectors.Application.ControllerHandlers.Profiles.Commands;
using MediatR;

namespace FFXIVCollectors.Application.ControllerHandlers.Profiles.Handlers
{
    public class CreateProfileHandler : IRequestHandler<CreateProfileCommand, Profile>
    {
        private readonly IMinionRepository _minionRepository;
        private readonly IMountRepository _mountRepository;
        private readonly IProfileRepository _profileRepository;

        public CreateProfileHandler(IMinionRepository minionRepository, IMountRepository mountRepository, IProfileRepository profileRepository)
        {
            _minionRepository = minionRepository;
            _mountRepository = mountRepository;
            _profileRepository = profileRepository;
        }


        public async Task<Profile> Handle(CreateProfileCommand request, CancellationToken cancellationToken)
        {
            var mounts = await _mountRepository.GetMounts(request.Mounts);
            var minions = await _minionRepository.GetMinions(request.Minions);
            var collectables = new List<ICollectable>(mounts).Concat(minions).ToList();

            var profile = new Profile
            {
                Name = request.Name,
                Collectables = collectables
            };

            return await _profileRepository.Add(profile);
        }
    }
}
