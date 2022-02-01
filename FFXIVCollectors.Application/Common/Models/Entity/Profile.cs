using FFXIVCollectors.Application.Common.Interfaces;

namespace FFXIVCollectors.Application.Common.Models.Entity
{
    public class Profile : BaseEntity
    {
        public Profile()
        {
            Collectables = new List<ICollectable>();
            LookingToCollect = new List<ICollectable>();
            Name = string.Empty;
        }

        public string Name { get; set; }
        public List<ICollectable> Collectables { get; set; }
        public List<ICollectable> LookingToCollect { get; set; }
    }
}
