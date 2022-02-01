using FFXIVCollectors.Application.Common.Models.Collectables;

namespace FFXIVCollectors.Application.Common.Interfaces.Persistance
{
    public interface IMinionRepository : IRepository<Minion>
    {
        Task<IEnumerable<Minion>> GetMinions(IEnumerable<int> ids);
    }
}
