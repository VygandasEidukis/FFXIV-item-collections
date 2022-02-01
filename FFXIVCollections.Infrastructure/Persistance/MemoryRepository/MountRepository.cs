using FFXIVCollectors.Application.Common.Extensions;
using FFXIVCollectors.Application.Common.Interfaces;
using FFXIVCollectors.Application.Common.Interfaces.Persistance;
using FFXIVCollectors.Application.Common.Models.Collectables;

namespace FFXIVCollections.Infrastructure.Persistance.MemoryRepository
{
    internal class MountRepository : IMountRepository
    {
        private readonly IRepositoryContext _repositoryContext;
        private readonly IFinalFantasyCollectionService _collectionService;

        public MountRepository(IRepositoryContext repositoryContext, IFinalFantasyCollectionService collectionService)
        {
            _repositoryContext = repositoryContext;
            _collectionService = collectionService;

            SetUp();
        }

        private async void SetUp()
        {
            var mounts = await _collectionService.GetMounts();
            _repositoryContext.Mounts.AddRange(mounts);
        }

        public Task<Mount> Add(Mount mount)
        {
            if (mount.Id == 0)
            {
                mount.Id = _repositoryContext.Mounts.Count() + 1;
            }

            if (!_repositoryContext.Mounts.Any(m => m.Id == mount.Id))
            {
                _repositoryContext.Mounts.Add(mount);
            }

            return Task.FromResult(mount);
        }

        public Task<Mount> Get(int id)
        {
            var result = _repositoryContext
                .Mounts
                .FirstOrDefault(x => x.Id == id);

            return Task.FromResult(result);
        }

        public Task<IEnumerable<Mount>> GetAll()
        {
            return Task.FromResult<IEnumerable<Mount>>(_repositoryContext.Mounts);
        }

        public Task<IEnumerable<Mount>> GetMounts(IEnumerable<int> ids)
        {
            var result = _repositoryContext.Mounts.Where(mount => ids.Contains(mount));
            return Task.FromResult(result);
        }
    }
}
