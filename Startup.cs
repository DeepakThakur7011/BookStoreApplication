namespace WebApplication7
{
    public class Startup
    {
        public void ConfigurationServices(IServiceCollection services)
        {

        }
        public void Configure(IApplicationBuilder app , IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                  await  context.Response.WriteAsync("Hello");
                });
            });
        }
    }
}
