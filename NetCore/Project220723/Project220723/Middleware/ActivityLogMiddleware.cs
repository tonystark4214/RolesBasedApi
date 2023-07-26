using Project220723.Models;

namespace Project220723.Middleware
{
    public class ActivityLogMiddleware
    {
        public readonly ILogger<ActivityLogMiddleware> Logger;
        public readonly RequestDelegate next;
        public ActivityLogMiddleware(RequestDelegate next,ILogger<ActivityLogMiddleware> Logger)
        {
            this.next = next;
            this.Logger = Logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            sdirectdbContext sdirectdbContext = new sdirectdbContext();
            PraveenActivity activityLogModel = new PraveenActivity();

            activityLogModel.IpAddress = httpContext.Connection.RemoteIpAddress?.ToString();
           
            activityLogModel.ApiName = httpContext.Request.Path.Value?.Split('/')[1];

            sdirectdbContext.PraveenActivities.Add(activityLogModel);
            sdirectdbContext.SaveChanges();

            await next(httpContext);

        }
    }
}
