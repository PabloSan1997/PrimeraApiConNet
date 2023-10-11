public class TimeMiddleWare
{
    readonly RequestDelegate next;
    public TimeMiddleWare(RequestDelegate nextRequest)
    {
        next=nextRequest;
    }
    public async Task Invoke(HttpContext context)
    {
        if(context.Request.Query.Any(p=>p.Key=="time")){
            await context.Response.WriteAsJsonAsync(DateTime.Now.ToShortDateString());
        }else{
             await next(context);
        }
    }
   
}

 public static class TimeMiddleWareExtension
    {
        public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TimeMiddleWare>();
        }
    }