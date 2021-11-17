using System.Configuration;
using Azure.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using Taskills.WebApi;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAdB2C"));
builder.Services.AddAuthorization();

var scopes = new[] { "data.read" };
var clientSecretCredential = new ClientSecretCredential(
    builder.Configuration.GetSection("AzureAdB2C")["Domain"],
    builder.Configuration.GetSection("AzureAdB2C")["ClientId"],
    builder.Configuration.GetSection("AzureAdB2C")["ClientSecret"]);
AppConfig.GraphClient = new(clientSecretCredential, scopes);

AppConfig.Configuration = builder.Configuration;

builder.Services.AddCors(options => {
    options.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors("CorsPolicy");

app.UseSwagger();
app.UseSwaggerUI();




app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
