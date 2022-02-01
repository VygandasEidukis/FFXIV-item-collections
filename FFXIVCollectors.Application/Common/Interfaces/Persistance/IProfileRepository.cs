using FFXIVCollectors.Application.Common.Models.Entity;

namespace FFXIVCollectors.Application.Common.Interfaces.Persistance
{
    public interface IProfileRepository : IRepository<Profile>
    {
        Task<Profile?> AddCollectablesToTodo(int profileId, IEnumerable<ICollectable> collectables);
    }
}
