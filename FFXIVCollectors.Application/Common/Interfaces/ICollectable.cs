using FFXIVCollectors.Application.Common.Models.Collectables;

namespace FFXIVCollectors.Application.Common.Interfaces
{
    public interface ICollectable
    {
        int Id { get; }
        string Name { get; set; }
        List<string> Sources { get; set; }
        CollectableType Type { get; set; }
    }
}
