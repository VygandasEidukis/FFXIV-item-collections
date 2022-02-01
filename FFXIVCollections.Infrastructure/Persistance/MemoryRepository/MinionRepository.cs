using FFXIVCollectors.Application.Common.Extensions;
using FFXIVCollectors.Application.Common.Interfaces;
using FFXIVCollectors.Application.Common.Interfaces.Persistance;
using FFXIVCollectors.Application.Common.Models.Collectables;

namespace FFXIVCollections.Infrastructure.Persistance.MemoryRepository
{
    internal class MinionRepository : IMinionRepository
    {
        private readonly IRepositoryContext _repositoryContext;
        private readonly IFinalFantasyCollectionService _collectionService;

        public MinionRepository(IRepositoryContext repositoryContext, IFinalFantasyCollectionService collectionService)
        {
            _repositoryContext = repositoryContext;
            _collectionService = collectionService;
            SetUp();
        }

        private async void SetUp()
        {
            var minions = await _collectionService.GetMinions();
            _repositoryContext.Minions.AddRange(minions);
        }

        public Task<Minion> Add(Minion minion)
        {
            if (minion.Id == 0)
            {
                minion.Id = _repositoryContext.Minions.Count() + 1;
            }

            if (!_repositoryContext.Minions.Any(m => m.Id == minion.Id))
            {
                _repositoryContext.Minions.Add(minion);
            }

            return Task.FromResult(minion);
        }

        public Task<Minion> Get(int id)
        {
            var result = _repositoryContext
                        .Minions
                        .FirstOrDefault(x => x.Id == id);
            return Task.FromResult(result);
        }

        public Task<IEnumerable<Minion>> GetAll()
        {
            return Task.FromResult<IEnumerable<Minion>>(_repositoryContext.Minions);
        }

        public Task<IEnumerable<Minion>> GetMinions(IEnumerable<int> ids)
        {
            var result = _repositoryContext.Minions.Where(minion => ids.Contains(minion));
            return Task.FromResult(result);
        }
    }
}
