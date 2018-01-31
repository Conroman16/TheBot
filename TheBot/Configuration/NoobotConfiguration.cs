using Noobot.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Noobot.Toolbox.Middleware;
using TheBot.Middleware;

namespace TheBot.Configuration
{
    public class NoobotConfiguration : ConfigurationBase
    {
        public NoobotConfiguration()
        {
            //UseMiddleware<AdminMiddleware>();
            UseMiddleware<JokeMiddleware>();
            UseMiddleware<PingMiddleware>();
            UseMiddleware<TestMiddleware>();
        }
    }
}
