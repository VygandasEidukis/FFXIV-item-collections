namespace FFXIVCollectors.Application.Common.Models
{
    public class Mount
    {
        public Mount(int id, string name, string source)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException($"'{nameof(name)}' cannot be null or empty.", nameof(name));
            }

            if (string.IsNullOrEmpty(source))
            {
                throw new ArgumentException($"'{nameof(source)}' cannot be null or empty.", nameof(source));
            }

            Id = id;
            Name = name;
            Source = source;
        }

        public Mount()
        {
            Name = string.Empty;
            Source = string.Empty;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Source { get; set; }
    }
}
