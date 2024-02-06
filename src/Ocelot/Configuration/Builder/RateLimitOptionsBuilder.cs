using Ocelot.Configuration.File;
using System;
using System.Collections.Generic;

namespace Ocelot.Configuration.Builder
{
    public class RateLimitOptionsBuilder
    {
        private bool _enableRateLimiting;
        private bool _enableGlobalRateLimiting;
        private string _clientIdHeader;
        private Func<List<string>> _getClientWhitelist;
        private bool _disableRateLimitHeaders;
        private string _quotaExceededMessage;
        private string _rateLimitCounterPrefix;
        private RateLimitRule _rateLimitRule;
        private int _httpStatusCode;
        private Func<List<ClientLimit>> _getClientLimitlist;

        public RateLimitOptionsBuilder WithEnableRateLimiting(bool enableRateLimiting)
        {
            _enableRateLimiting = enableRateLimiting;
            return this;
        }

        public RateLimitOptionsBuilder WithEnableGlobalRateLimiting(bool enableGlobalRateLimiting)
        {
            _enableGlobalRateLimiting = enableGlobalRateLimiting;
            return this;
        }

        public RateLimitOptionsBuilder WithClientIdHeader(string clientIdHeader)
        {
            _clientIdHeader = clientIdHeader;
            return this;
        }

        public RateLimitOptionsBuilder WithClientWhiteList(Func<List<string>> getClientWhitelist)
        {
            _getClientWhitelist = getClientWhitelist;
            return this;
        }

        public RateLimitOptionsBuilder WithDisableRateLimitHeaders(bool disableRateLimitHeaders)
        {
            _disableRateLimitHeaders = disableRateLimitHeaders;
            return this;
        }

        public RateLimitOptionsBuilder WithQuotaExceededMessage(string quotaExceededMessage)
        {
            _quotaExceededMessage = quotaExceededMessage;
            return this;
        }

        public RateLimitOptionsBuilder WithRateLimitCounterPrefix(string rateLimitCounterPrefix)
        {
            _rateLimitCounterPrefix = rateLimitCounterPrefix;
            return this;
        }

        public RateLimitOptionsBuilder WithRateLimitRule(RateLimitRule rateLimitRule)
        {
            _rateLimitRule = rateLimitRule;
            return this;
        }

        public RateLimitOptionsBuilder WithHttpStatusCode(int httpStatusCode)
        {
            _httpStatusCode = httpStatusCode;
            return this;
        }

        public RateLimitOptionsBuilder WithClientLimitList(Func<List<ClientLimit>> getClientLimitlist)
        {
            _getClientLimitlist = getClientLimitlist;
            return this;
        }

        public RateLimitOptions Build()
        {
            return new RateLimitOptions(_enableRateLimiting, _clientIdHeader, _getClientWhitelist,
                _disableRateLimitHeaders, _quotaExceededMessage, _rateLimitCounterPrefix,
                _rateLimitRule, _httpStatusCode, _getClientLimitlist, _enableGlobalRateLimiting);
        }
    }
}
