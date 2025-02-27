var builder = WebApplication.CreateBuilder(args);
var aee = builder.Build();

aee.MapGet("/", () => "Hello World!");

aee.Run();
