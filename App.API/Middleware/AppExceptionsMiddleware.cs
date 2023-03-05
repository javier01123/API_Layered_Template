namespace App.API.Middleware
{
    public class AppExceptionsMiddleware
    {
        private readonly RequestDelegate _next;

        public AppExceptionsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

          

    }
}
