using MusicAPI.InversionOfControl;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    // Serialize enums as strings for incoming requests
    var enumConverter = new JsonStringEnumConverter();
    options.JsonSerializerOptions.Converters.Add(enumConverter);
});

const string AngularShowcase = "AngularShowcase";
var angularShowcaseOrigin = builder.Configuration.GetValue<string>("AngularShowcaseBaseUrl") ?? string.Empty;

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AngularShowcase,
        policy =>
        {
            policy.WithOrigins(angularShowcaseOrigin);
        });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(configuration =>
{
    configuration.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Music API",
        Version = "v1",
        Description = "A .NET 8.0 Web API that integrates with Spotify's Web API to retrieve data"
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    configuration.IncludeXmlComments(xmlPath);
});

// Allow IHttpClientFactory to be injected to necessary classes.
builder.Services.AddHttpClient();

// Sets up the default IMemoryCache for the application.
builder.Services.AddMemoryCache();

// Configure project level dependencies.
builder.Services.ConfigureAccessorDependencies();
builder.Services.ConfigureEngineDependencies();
builder.Services.ConfigureManagerDependencies();
builder.Services.ConfigureUtilitiesDependencies(builder.Configuration);


var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseCors(AngularShowcase);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
