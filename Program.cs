//var builder = WebApplication.CreateBuilder(args);
//var aee = builder.Build();

//aee.MapGet("/", () => "Hello World!");

//aee.Run();
namespace WebApplication7
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
        
            Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
        
    }
}