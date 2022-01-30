using FFXIVCollectors.Application.Common.Models;

namespace FFXIVCollectors.Application.Common.Interfaces
{
    public interface IFinalFantasyCollectionService
    {
        Task<IList<Mount>> GetMounts();
    }
}
