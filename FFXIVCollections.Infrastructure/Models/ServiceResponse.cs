namespace FFXIVCollections.Infrastructure.Models
{
    internal class ServiceResponse<Result> where Result : new()
    {
        public ServiceResponse()
        {
            Results = Array.Empty<Result>();
        }

        public int Count { get; set; }
        public Result[] Results { get; set; }
    }
}
