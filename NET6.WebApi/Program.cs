using NET6.WebApi.Extensions;
using NET6.WebApi.MappingProfiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(RepositoryMappingProfiles));

// Add Repositories
builder.Services.AddRepositories(options =>
    options.UseSql(builder.Configuration.GetConnectionString("BrownBagDbConnectionString"))
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
