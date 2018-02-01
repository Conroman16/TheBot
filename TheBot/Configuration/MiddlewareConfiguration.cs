using Noobot.Core.Configuration;
using Noobot.Toolbox.Middleware;
using TheBot.Middleware;

namespace TheBot.Configuration
{
    public class MiddlewareConfiguration : ConfigurationBase
    {
        public MiddlewareConfiguration()
        {
            //UseMiddleware<AdminMiddleware>();
            UseMiddleware<JokeMiddleware>();
            UseMiddleware<PingMiddleware>();
            UseMiddleware<TestMiddleware>();
            UseMiddleware<EasterEggMiddleware>();
        }
    }
}
