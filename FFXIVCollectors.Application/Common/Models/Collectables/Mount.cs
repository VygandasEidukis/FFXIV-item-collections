using FFXIVCollectors.Application.Common.Interfaces;
using FFXIVCollectors.Application.Common.Models.Entity;

namespace FFXIVCollectors.Application.Common.Models.Collectables
{
    public class Mount : BaseEntity, ICollectable
    {
        public Mount(int id, string name, List<string> sources)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException($"'{nameof(name)}' cannot be null or empty.", nameof(name));
            }

            if (sources is null)
            {
                sources = new List<string>();
            }

            Id = id;
            Name = name;
            Sources = sources.ToList();
        }

        public Mount()
        {
            Name = string.Empty;
            Sources = new List<string>();
        }

        public string Name { get; set; }
        public CollectableType Type { get; set; } = CollectableType.Mount;
        public List<string> Sources { get; set; }
    }
}
