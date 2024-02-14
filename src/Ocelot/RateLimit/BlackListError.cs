using Ocelot.Errors;

namespace Ocelot.RateLimit
{
    public class BlackListError : Error
    {
        public BlackListError(string message, int httpStatusCode)
            : base(message, OcelotErrorCode.BlackListError, httpStatusCode)
        {
        }
    }
}
