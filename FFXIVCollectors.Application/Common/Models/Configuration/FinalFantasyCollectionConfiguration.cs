namespace FFXIVCollectors.Application.Common.Models.Configuration
{
    public class FinalFantasyCollectionConfiguration
    {
        public FinalFantasyCollectionConfiguration()
        {
            //TODO: REMOVE
            MountUrl = "https://www.ffxivcollect.com/api/mounts";
            MinionUrl = "https://www.ffxivcollect.com/api/minions";
        }

        public string MountUrl { get; set; }
        public string MinionUrl { get; set; }
    }
}
