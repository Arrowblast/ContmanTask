using Microsoft.Owin;
using NLog;
using System.Linq;
using System.Threading.Tasks;
namespace ContmanTask.WebApi_Controllers.Base
{
    public class LoggingOwinMiddleware : OwinMiddleware
    {
        private static readonly Logger Logger = LogManager.GetLogger("Access");
        public LoggingOwinMiddleware(OwinMiddleware next) : base(next)
        {
        }
        public override async Task Invoke(IOwinContext context)
        {
            if (context.Authentication.User != null)
            {
                var claims = context.Authentication.User.Claims.ToList();
                string message = $"Method: {context.Request.Path.ToString()}; UserName: {claims.FirstOrDefault(c => c.Type == "userName").Value}";
                Logger.Info(message);
            }
            await Next.Invoke(context);
        }
    }
}
