using System.Collections.Generic;

namespace Ocelot.Configuration.File
{
    public class FileRateLimitOptions
    {
        public FileRateLimitOptions()
        {
            ClientLimitlist = new List<ClientLimit>();
            ClientWhitelist = new List<string>();
            ClientBlacklist = new List<string>();
        }

        /// <summary>
        /// Gets or sets the HTTP header that holds the client identifier, by default is X-ClientId.
        /// </summary>
        public string ClientIdHeader { get; set; } = "ClientId";

        /// <summary>
        /// Gets or sets a value that will be used as a formatter for the QuotaExceeded response message.
        /// If none specified the default will be:
        /// API calls quota exceeded! maximum admitted {0} per {1}.
        /// </summary>
        public string QuotaExceededMessage { get; set; }

        /// <summary>
        /// Gets or sets the counter prefix, used to compose the rate limit counter cache key.
        /// </summary>
        public string RateLimitCounterPrefix { get; set; } = "ocelot";

        /// <summary>
        /// Disables X-Rate-Limit and Rety-After headers.
        /// </summary>
        public bool DisableRateLimitHeaders { get; set; }

        /// <summary>
        /// Gets or sets the HTTP Status code returned when rate limiting occurs, by default value is set to 429 (Too Many Requests).
        /// </summary>
        public int HttpStatusCode { get; set; } = 429;

        /// <summary>
        /// Enables endpoint rate limiting based URL path and HTTP verb.
        /// </summary>
        public bool EnableGlobalRateLimiting { get; set; }

        /// <summary>
        /// Rate limit period as in 1s, 1m, 1h.
        /// </summary>
        public string Period { get; set; }

        public double PeriodTimespan { get; set; }

        /// <summary>
        /// Maximum number of requests that a client can make in a defined period.
        /// </summary>
        public long Limit { get; set; }

        /// <summary>
        /// Limit list of ClientIds. 
        /// </summary>
        public List<ClientLimit> ClientLimitlist { get; set; }

        public List<string> ClientWhitelist { get; set; }
        public List<string> ClientBlacklist { get; set; }
    }

    public class ClientLimit
    {
        public ClientLimit()
        {
            AllowIPList = new List<string>();
            BlockIPList = new List<string>();
        }

        public string ClientId { get; set; }
        public long Limit { get; set; }
        public string Period { get; set; }
        public double PeriodTimespan { get; set; }
        public List<string> AllowIPList { get; set; }
        public List<string> BlockIPList { get; set; }
    }
}
