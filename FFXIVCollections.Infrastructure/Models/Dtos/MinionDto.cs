namespace FFXIVCollections.Infrastructure.Models.Dtos
{
    internal class MinionDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Owned { get; set; }
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
