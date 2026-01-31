var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Mercure_WebApp>("Mercure-WebApp");
builder.AddProject<Projects.Mercure_CoreServiceApi>("Mercure-CoreServiceApi");


builder.Build().Run();
