using Microsoft.AspNetCore.Authentication.JwtBearer;
using NET6.WebApi.Extensions;
using NET6.WebApi.MappingProfiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add Auth0
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(options =>
    {
        options.Authority = "https://dev-ygero1dp.us.auth0.com/";
        options.Audience = "brownbagsapi";
    });


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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
