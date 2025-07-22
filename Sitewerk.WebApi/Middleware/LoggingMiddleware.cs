namespace Sitewerk.WebApi.Middleware;

public class LoggingMiddleware
{
    private readonly RequestDelegate _next;
    private static List<string> logs = new List<string>();

    public LoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var startTime = DateTime.Now;

        try
        {
            logs.Add($"{DateTime.Now}: {context.Request.Method} {context.Request.Path}");

            await _next(context);

            var endTime = DateTime.Now;
            var duration = endTime - startTime;

            File.AppendAllText("logs.txt", $"Request completed in {duration.TotalMilliseconds}ms\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Something went wrong");

            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("Internal Server Error");
        }
    }

    public static void ClearLogs()
    {
        logs.Clear();
    }

    public static int GetLogCount()
    {
        return logs.Count;
    }
}