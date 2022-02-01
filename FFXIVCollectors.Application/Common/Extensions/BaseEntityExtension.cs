using FFXIVCollectors.Application.Common.Models.Entity;

namespace FFXIVCollectors.Application.Common.Extensions
{
    public static class BaseEntityExtension
    {
        public static bool Contains(this IEnumerable<int> ids, BaseEntity baseEntity)
        {
            if (baseEntity is null || ids is null)
            {
                return false;
            }

            return ids.Any(id => baseEntity.Id == id);
        }
    }
}
