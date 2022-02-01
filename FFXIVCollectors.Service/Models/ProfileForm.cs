namespace FFXIVCollectors.Service.Models
{
    public class ProfileForm
    {
        public ProfileForm()
        {
            Name = string.Empty;
            MountIds = new List<int>();
            MinionIds = new List<int>();
        }

        public string Name { get; set; }
        public IEnumerable<int> MountIds { get; set; }
        public IEnumerable<int> MinionIds { get; set; }
    }
}
