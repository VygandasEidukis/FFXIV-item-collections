using FFXIVCollectors.Application.Common.Models.Collectables;

namespace FFXIVCollectors.Application.Common.Interfaces.Persistance
{
    public interface IMountRepository : IRepository<Mount>
    {
        Task<IEnumerable<Mount>> GetMounts(IEnumerable<int> ids);
    }
}
