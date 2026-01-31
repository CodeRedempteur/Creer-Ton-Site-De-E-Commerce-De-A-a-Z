using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

var DBConnectionString = builder.Configuration.GetConnectionString("mercure_db_card");
builder.Services.AddDbContext<Mercure.CoreServiceApi.Context.CardWebsiteContext>(
   option=>option.UseNpgsql(DBConnectionString)
    );

builder.Services.AddControllers();

builder.Services.AddCors(
   option =>
   {
       option.AddPolicy("AllowWebsite", policy =>
       {
           policy.WithOrigins("https://localhost:7020")
           .AllowAnyHeader()
           .AllowAnyMethod()
           .AllowCredentials();
       });
   }
    );

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(document =>
{
    document.Title = "Mercure API";
    document.Version = "1.0";
    document.Description = "API pour la gestion des cartes";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi(settings =>
    {
        settings.DocumentTitle = "Mercure API Doc";
        //settings.DocExpansion = "list";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
