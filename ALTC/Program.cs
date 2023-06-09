using ALTC.Application.Interfaces.Infrastructures;
using ALTC.Application.Interfaces.Services;
using ALTC.Application.Services;
using ALTC.Extensions;
using ALTC.Infra.Db.Memory.Cache.Repositories;
using ALTC.Infra.Json.API.Proxys;
using ALTC.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureHttpClients();
builder.Services.AddMemoryCache();
builder.Services.AddAutoMapper(AssemblyUtil.GetAssemblies());
builder.Services.AddSingleton<ICacheRepository, MemoryCacheRepository>();
builder.Services.AddScoped<IJsonPlaceHolderService, JsonPlaceHolderService>();
builder.Services.AddScoped<IJsonPlaceHolderProxy, JsonPlaceHolderProxy>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
