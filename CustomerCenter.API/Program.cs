using CustomerCenter.Data.DI;
using CustomerCenter.Domain;
using CustomerCenter.Repositories.DI;
using CustomerCenter.Services.DI;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure DI
builder.Services.AddData(builder.Configuration);
builder.Services.ConfigureRepositories();
builder.Services.ConfigureBusinessLogics();

var authenticationOptions = builder.Configuration.Get<AuthenticationOptions>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => {
        options.Authority = authenticationOptions.Authority;
        options.RequireHttpsMetadata = authenticationOptions.RequireHttpsMetadata;
        options.Audience = authenticationOptions.ApiName;
        options.TokenValidationParameters.ValidTypes = new[] { "at+jwt" };
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

// Plug Serilog into the host
builder.Host.UseSerilog();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors("AllowReact");

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

// Add Handlers
app.MapControllers();

// run apps
app.Run();
