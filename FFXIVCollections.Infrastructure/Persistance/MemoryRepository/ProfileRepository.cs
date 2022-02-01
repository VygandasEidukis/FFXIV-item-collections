using FFXIVCollectors.Application.Common.Interfaces;
using FFXIVCollectors.Application.Common.Interfaces.Persistance;
using FFXIVCollectors.Application.Common.Models.Entity;

namespace FFXIVCollections.Infrastructure.Persistance.MemoryRepository
{
    internal class ProfileRepository : IProfileRepository
    {
        private readonly IRepositoryContext _repositoryContext;

        public ProfileRepository(IRepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public Task<Profile> Add(Profile profile)
        {
            if (profile.Id == 0)
            {
                var id = _repositoryContext.Profiles.Count() + 1;
                profile.Id = id;
                _repositoryContext.Profiles.Add(profile);
            }

            if (!_repositoryContext.Profiles.Any(p => p.Id == profile.Id))
            {
                _repositoryContext.Profiles.Add(profile);
            }

            return Task.FromResult(profile);
        }

        public Task<Profile?> AddCollectablesToTodo(int profileId, IEnumerable<ICollectable> collectables)
        {
            var profile = _repositoryContext.Profiles.FirstOrDefault(p => p.Id == profileId);
            if (profile == null)
            {
                return Task.FromResult<Profile?>(null);
            }

            profile.LookingToCollect.AddRange(collectables);
            return Task.FromResult(profile);
        }

        public Task<Profile> Get(int id)
        {
            return Task.FromResult(_repositoryContext.Profiles.FirstOrDefault(p => p.Id == id));
        }

        public Task<IEnumerable<Profile>> GetAll()
        {
            return Task.FromResult<IEnumerable<Profile>>(_repositoryContext.Profiles);
        }
    }
}
