using Microsoft.EntityFrameworkCore;
using SndAPI.Clients;
using SndAPI.Data;
using SndAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddTransient<IArshaService, ArshaService>();
builder.Services.AddTransient<IBdoApiClient, BdoApiClient>();
builder.Services.AddTransient<IOutfitScrapper, OutfitScrapper>();
builder.Services.AddTransient<IOutfitRepository, OutfitRepository>();
builder.Services.AddHostedService<OutfitIdUpdateService>();
builder.Services.AddHostedService<SoldOutfitsUpdateService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SndDbContext>(options =>
 options.UseSqlServer(builder.Configuration.GetConnectionString("SNDConnectionString")), ServiceLifetime.Singleton);
builder.Services.AddHttpClient();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();
app.Run();
