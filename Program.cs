var builder = WebApplication.CreateBuilder(args);
var dee = builder.Build();

dee.MapGet("/", () => "Hello World!");

dee.Run();
