using FFXIVCollectors.Application.Common.Models.Collectables;

namespace FFXIVCollectors.Application.Common.Interfaces
{
    public interface IFinalFantasyCollectionService
    {
        Task<IList<Mount>> GetMounts();
        Task<IList<Minion>> GetMinions();
    }
}
