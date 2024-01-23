using MusicAPI.InversionOfControl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Allow IHttpClientFactory to be injected to necessary classes.
builder.Services.AddHttpClient();

// Sets up the default IMemoryCache for the application.
builder.Services.AddMemoryCache();

// Configure project level dependencies.
builder.Services.ConfigureManagerDependencies();
builder.Services.ConfigureAccessorDependencies();
builder.Services.ConfigureUtilitiesDependencies(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
