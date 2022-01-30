namespace FFXIVCollections.Infrastructure.Models.Dtos
{
    internal class ItemSourceDto
    {
        public string? Type { get; set; }
        public string? Text { get; set; }

        public override string ToString()
        {
            return string.Join(", ", Type, Text);
        }

        public bool Validate()
        {
            if (string.IsNullOrWhiteSpace(Text))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(Type))
            {
                return false;
            }

            return true;
        }
    }
}
