using FFXIVCollectors.Application.Common.Interfaces.Persistance;
using FFXIVCollectors.Application.Common.Models.Collectables;
using FFXIVCollectors.Application.Common.Models.Entity;

namespace FFXIVCollections.Infrastructure.Persistance.MemoryRepository
{
    public class MemoryRepositoryContext : IRepositoryContext
    {
        public MemoryRepositoryContext()
        {
            Profiles = new List<Profile>();
            Minions = new List<Minion>();
            Mounts = new List<Mount>();
        }

        public List<Profile> Profiles { get; set; }
        public List<Minion> Minions { get; set; }
        public List<Mount> Mounts { get; set; }
    }
}
