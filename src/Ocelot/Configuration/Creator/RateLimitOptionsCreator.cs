using Ocelot.Configuration.Builder;
using Ocelot.Configuration.File;

namespace Ocelot.Configuration.Creator
{
    public class RateLimitOptionsCreator : IRateLimitOptionsCreator
    {
        public RateLimitOptions Create(FileRateLimitRule fileRateLimitRule, FileGlobalConfiguration globalConfiguration)
        {
            // Bu orijinal hali
            //if (fileRateLimitRule != null && fileRateLimitRule.EnableRateLimiting)
            //{
            //    return new RateLimitOptionsBuilder()
            //        .WithClientIdHeader(globalConfiguration.RateLimitOptions.ClientIdHeader)
            //        .WithClientWhiteList(() => fileRateLimitRule.ClientWhitelist)
            //        .WithDisableRateLimitHeaders(globalConfiguration.RateLimitOptions.DisableRateLimitHeaders)
            //        .WithEnableRateLimiting(fileRateLimitRule.EnableRateLimiting)
            //        .WithHttpStatusCode(globalConfiguration.RateLimitOptions.HttpStatusCode)
            //        .WithQuotaExceededMessage(globalConfiguration.RateLimitOptions.QuotaExceededMessage)
            //        .WithRateLimitCounterPrefix(globalConfiguration.RateLimitOptions.RateLimitCounterPrefix)
            //        .WithRateLimitRule(new RateLimitRule(fileRateLimitRule.Period,
            //            fileRateLimitRule.PeriodTimespan,
            //            fileRateLimitRule.Limit))
            //        .Build();
            //}



            // Bu da düzenlenmiş hali
            // önce endpoint'e bakıyor. varsa bunu baz alacak
            if (fileRateLimitRule != null && fileRateLimitRule.EnableRateLimiting)
            {
                return new RateLimitOptionsBuilder()
                    .WithClientIdHeader(globalConfiguration.RateLimitOptions.ClientIdHeader)
                    .WithClientWhiteList(() => fileRateLimitRule.ClientWhitelist)
                    .WithDisableRateLimitHeaders(globalConfiguration.RateLimitOptions.DisableRateLimitHeaders)
                    .WithEnableRateLimiting(fileRateLimitRule.EnableRateLimiting)
                    .WithEnableGlobalRateLimiting(false)
                    .WithHttpStatusCode(globalConfiguration.RateLimitOptions.HttpStatusCode)
                    .WithQuotaExceededMessage(globalConfiguration.RateLimitOptions.QuotaExceededMessage)
                    .WithRateLimitCounterPrefix(globalConfiguration.RateLimitOptions.RateLimitCounterPrefix)
                    .WithRateLimitRule(new RateLimitRule(fileRateLimitRule.Period,
                        fileRateLimitRule.PeriodTimespan,
                        fileRateLimitRule.Limit))
                    .WithClientLimitList(() => fileRateLimitRule.ClientLimitlist)
                    .Build();
            }

            // sonra global'e bakıyor
            if (globalConfiguration.RateLimitOptions != null && globalConfiguration.RateLimitOptions.EnableGlobalRateLimiting)
            {
                return new RateLimitOptionsBuilder()
                    .WithClientIdHeader(globalConfiguration.RateLimitOptions.ClientIdHeader)
                    .WithClientWhiteList(() => globalConfiguration.RateLimitOptions.ClientWhitelist)
                    .WithDisableRateLimitHeaders(globalConfiguration.RateLimitOptions.DisableRateLimitHeaders)
                    .WithEnableRateLimiting(false)
                    .WithEnableGlobalRateLimiting(globalConfiguration.RateLimitOptions.EnableGlobalRateLimiting)
                    .WithHttpStatusCode(globalConfiguration.RateLimitOptions.HttpStatusCode)
                    .WithQuotaExceededMessage(globalConfiguration.RateLimitOptions.QuotaExceededMessage)
                    .WithRateLimitCounterPrefix(globalConfiguration.RateLimitOptions.RateLimitCounterPrefix)
                    .WithRateLimitRule(new RateLimitRule(globalConfiguration.RateLimitOptions.Period,
                        globalConfiguration.RateLimitOptions.PeriodTimespan,
                        globalConfiguration.RateLimitOptions.Limit))
                    .WithClientLimitList(() => globalConfiguration.RateLimitOptions.ClientLimitlist)
                    .Build();
            }


            return new RateLimitOptionsBuilder()
                .WithEnableRateLimiting(false)
                .WithEnableGlobalRateLimiting(false)
                .Build();
        }
    }
}
