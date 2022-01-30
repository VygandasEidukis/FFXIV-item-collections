using Microsoft.Extensions.Logging;
using System.Net.Http.Json;

namespace FFXIVCollections.Infrastructure.Services
{
    internal class GenericRestService
    {
        private readonly HttpClient _client;
        private readonly ILogger _logger;

        public GenericRestService(IHttpClientFactory clientFactory, ILogger logger)
        {
            if (clientFactory is null)
            {
                throw new ArgumentNullException(nameof(clientFactory));
            }

            _client = clientFactory.CreateClient();
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Result> Get<Result>(string uri) where Result : new()
        {
            var request = GetRequest(uri);
            var response = await _client.SendAsync(request);

            if (response is null)
            {
                _logger.LogError("No response received from {0}", uri);
                return new();
            }

            if (response.IsSuccessStatusCode)
            {
                _logger.LogDebug("Request '{0}' was complete successfully, with status code {1}", uri, response.StatusCode);
                return await response.Content.ReadFromJsonAsync<Result>() ?? new();
            }

            _logger.LogWarning("Failed to complete the request '{0}', received status code '{1}'", uri, response.StatusCode);
            return new();
        }

        private static HttpRequestMessage GetRequest(string uri)
        {
            return string.IsNullOrEmpty(uri) ? throw new ArgumentNullException(nameof(uri)) : new HttpRequestMessage(HttpMethod.Get, uri);
        }
    }
}
