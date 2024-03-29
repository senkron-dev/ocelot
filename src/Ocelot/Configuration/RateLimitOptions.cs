﻿using Ocelot.Configuration.File;
using System;
using System.Collections.Generic;

namespace Ocelot.Configuration
{
    /// <summary>
    /// RateLimit Options
    /// </summary>
    public class RateLimitOptions
    {
        private readonly Func<List<string>> _getClientWhitelist;
        private readonly Func<List<string>> _getClientBlacklist;
        private readonly Func<List<ClientLimit>> _getClientLimitlist;

        public RateLimitOptions(bool enableRateLimiting, string clientIdHeader, Func<List<string>> getClientWhitelist, bool disableRateLimitHeaders,
            string quotaExceededMessage, string rateLimitCounterPrefix, RateLimitRule rateLimitRule, int httpStatusCode, Func<List<ClientLimit>> getClientLimitlist, bool enableGlobalRateLimiting, Func<List<string>> getClientBlacklist)
        {
            EnableRateLimiting = enableRateLimiting;
            ClientIdHeader = clientIdHeader;
            _getClientWhitelist = getClientWhitelist;
            _getClientBlacklist = getClientBlacklist;
            DisableRateLimitHeaders = disableRateLimitHeaders;
            QuotaExceededMessage = quotaExceededMessage;
            RateLimitCounterPrefix = rateLimitCounterPrefix;
            RateLimitRule = rateLimitRule;
            HttpStatusCode = httpStatusCode;
            _getClientLimitlist = getClientLimitlist;
            EnableGlobalRateLimiting = enableGlobalRateLimiting;
        }

        public RateLimitRule RateLimitRule { get; set; }

        /// <summary>
        /// Gets the list of white listed clients
        /// </summary>
        public List<string> ClientWhitelist { get => _getClientWhitelist(); }

        /// <summary>
        /// Gets the list of balck listed clients
        /// </summary>
        public List<string> ClientBlacklist { get => _getClientBlacklist(); }

        /// <summary>
        /// Gets or sets the HTTP header that holds the client identifier, by default is X-ClientId
        /// </summary>
        public string ClientIdHeader { get; private set; }

        /// <summary>
        /// Gets or sets the HTTP Status code returned when rate limiting occurs, by default value is set to 429 (Too Many Requests)
        /// </summary>
        public int HttpStatusCode { get; private set; }

        /// <summary>
        /// Gets or sets a value that will be used as a formatter for the QuotaExceeded response message.
        /// If none specified the default will be:
        /// API calls quota exceeded! maximum admitted {0} per {1}
        /// </summary>
        public string QuotaExceededMessage { get; private set; }

        /// <summary>
        /// Gets or sets the counter prefix, used to compose the rate limit counter cache key
        /// </summary>
        public string RateLimitCounterPrefix { get; private set; }

        /// <summary>
        /// Enables endpoint rate limiting based URL path and HTTP verb
        /// </summary>
        public bool EnableRateLimiting { get; private set; }

        /// <summary>
        /// Enables global rate limiting based URL path and HTTP verb
        /// </summary>
        public bool EnableGlobalRateLimiting { get; private set; }

        /// <summary>
        /// Disables X-Rate-Limit and Rety-After headers
        /// </summary>
        public bool DisableRateLimitHeaders { get; private set; }

        /// <summary>
        /// Gets the list of limit listed clients
        /// </summary>
        public List<ClientLimit> ClientLimitlist { get => _getClientLimitlist(); }
    }
}
