using Microsoft.EntityFrameworkCore;
using WatchAppApi.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("WatchAppDb")
    ?? throw new InvalidOperationException("Connection string 'WatchAppDb' was not found.");

// Controllers
builder.Services.AddControllers()
	.AddJsonOptions(options =>
	{
		options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
	});

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IWatchRepository, WatchRepository>();

builder.Services.AddDbContext<WatchAppDbContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

// Swagger middleware
app.UseSwagger();
app.UseSwaggerUI();

// Pipeline
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapGet("/", () => Results.Redirect("/swagger"));
app.MapControllers();

await app.RunAsync();