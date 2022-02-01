using FFXIVCollectors.Application.Common.Models.Collectables;
using FFXIVCollectors.Application.Common.Models.Entity;

namespace FFXIVCollectors.Application.Common.Interfaces.Persistance
{
    public interface IRepositoryContext
    {
        List<Profile> Profiles { get; }
        List<Minion> Minions { get; }
        List<Mount> Mounts { get; }
    }
}
