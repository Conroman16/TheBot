using Newtonsoft.Json;
using Noobot.Core.MessagingPipeline.Middleware;
using Noobot.Core.MessagingPipeline.Middleware.ValidHandles;
using Noobot.Core.MessagingPipeline.Request;
using Noobot.Core.MessagingPipeline.Response;
using System.Collections.Generic;

namespace TheBot.Middleware
{
    public class TestMiddleware : MiddlewareBase
    {
        public TestMiddleware(IMiddleware next) : base(next)
        {
            HandlerMappings = new[]
            {
                new HandlerMapping
                {
                    ValidHandles = ExactMatchHandle.For("tttt"),
                    EvaluatorFunc = TestHandler,
                    Description = "This is the description for the test handler",
                    VisibleInHelp = true
                }
            };
        }

        private IEnumerable<ResponseMessage> TestHandler(IncomingMessage message, IValidHandle matchedHandle)
        {
            yield return message.ReplyToChannel($"Message received!\n\n{JsonConvert.SerializeObject(message, Formatting.Indented)}");
            yield return message.ReplyDirectlyToUser($"Message received!\n\n{JsonConvert.SerializeObject(message, Formatting.Indented)}");
        }
    }
}
