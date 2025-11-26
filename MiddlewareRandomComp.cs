namespace ASPnetlab1
{
    public class MiddlewareRandomComp
    {
        private readonly RequestDelegate next;
        private readonly int randomNumber;

        public MiddlewareRandomComp(RequestDelegate next, int randomNumber)
        {
            this.next = next;
            this.randomNumber = randomNumber;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (this.randomNumber >= 50)
            {
                await this.next(context);
            }
            else
            {
                await context.Response.WriteAsync($"<p>Number: {this.randomNumber}</p>");
                await context.Response.WriteAsync($"<p>Less 50</p>");
            }
        }
    }
}
