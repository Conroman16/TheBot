using Noobot.Core.MessagingPipeline.Middleware;
using Noobot.Core.MessagingPipeline.Middleware.ValidHandles;
using Noobot.Core.MessagingPipeline.Request;
using Noobot.Core.MessagingPipeline.Response;
using System.Collections.Generic;

namespace TheBot.Middleware
{
    public class EasterEggMiddleware : MiddlewareBase
    {
        public EasterEggMiddleware(IMiddleware next) : base(next)
        {
            HandlerMappings = new[]
            {
                new HandlerMapping
                {
                    ValidHandles = RegexHandle.For("open (.*) door"),
                    EvaluatorFunc = PodBayDoorHandler,
                    Description = "Opens the pod bay doors",
                    VisibleInHelp = false
                }
            };
        }

        private IEnumerable<ResponseMessage> PodBayDoorHandler(IncomingMessage message, IValidHandle matchedHandle)
        {
            yield return message.ReplyToChannel($"I'm afraid I can't let you do that {message.Username}");
        }
    }
}
