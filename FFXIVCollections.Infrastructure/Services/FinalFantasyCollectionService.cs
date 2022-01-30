﻿using FFXIVCollections.Infrastructure.Models;
using FFXIVCollections.Infrastructure.Models.Dtos;
using FFXIVCollectors.Application.Common.Interfaces;
using FFXIVCollectors.Application.Common.Models;
using FFXIVCollectors.Application.Common.Models.Configuration;
using Microsoft.Extensions.Logging;

namespace FFXIVCollections.Infrastructure.Services
{
    public class FinalFantasyCollectionService : IFinalFantasyCollectionService
    {
        private readonly ILogger<FinalFantasyCollectionService> _logger;
        private readonly FinalFantasyCollectionConfiguration _configuration;
        private readonly GenericRestService _service;

        public FinalFantasyCollectionService(IHttpClientFactory clientFactory, ILogger<FinalFantasyCollectionService> logger, FinalFantasyCollectionConfiguration configuration)
        {
            if (clientFactory is null)
            {
                throw new ArgumentNullException(nameof(clientFactory));
            }

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _service = new GenericRestService(clientFactory, logger);
        }

        public async Task<IList<Mount>> GetMounts()
        {
            var response = await _service.Get<ServiceResponse<MountDto>>(_configuration.MountUrl);

            var mounts = new List<Mount>();
            if (response.Count == 0)
            {
                _logger.LogDebug("Received no mounts from service.");
                return mounts;
            }

            foreach (var mountDto in response.Results)
            {
                if (!mountDto.Validate())
                {
                    _logger.LogWarning("Validation failed for '{0}' mount.", mountDto.Id);
                    continue;
                }

                var mount = new Mount(mountDto.Id, mountDto.Name, mountDto.Sources.ToString());

                mounts.Add(mount);
            }

            return mounts;
        }
    }
}
