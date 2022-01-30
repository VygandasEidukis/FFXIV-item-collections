namespace FFXIVCollections.Infrastructure.Models.Dtos
{
    internal class MountDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Enhanced_Description { get; set; }
        public string? Tooltip { get; set; }
        public string? Patch { get; set; }
        public string? Owned { get; set; }
        public string? Image { get; set; }
        public ItemSourceDto[]? Sources { get; set; }

        public bool Validate()
        {
            if (Id == 0)
            {
                return false;
            }

            if (string.IsNullOrEmpty(Name))
            {
                return false;
            }

            if (Sources == null)
            {
                return false;
            }

            if (Sources.Length == 0)
            {
                return false;
            }

            foreach (var source in Sources)
            {
                if (!source.Validate())
                {
                    return false;
                }
            }

            return true;
        }
    }
}
