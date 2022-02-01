using FFXIVCollectors.Application.Common.Interfaces;
using FFXIVCollectors.Application.Common.Models.Entity;

namespace FFXIVCollectors.Application.Common.Models.Collectables
{
    public class Minion : BaseEntity, ICollectable
    {
        public Minion(int id, string name, List<string> sources)
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

        public Minion()
        {
            Name = string.Empty;
            Sources = new List<string>();
        }

        public string Name { get; set; }
        public CollectableType Type { get; set; } = CollectableType.Minion;
        public List<string> Sources { get; set; }
    }
}
