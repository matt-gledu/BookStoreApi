using BookStoreApi.CosmosDb;
using BookStoreApi.CosmosDb.Services;
using BookStoreApi.Interfaces;
using BookStoreApi.Models;
using BookStoreApi.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;

var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.Configure<BookStoreDatabaseSettings>(
    builder.Configuration.GetSection("BookStoreDatabase"));
builder.Services.Configure<ManifestStoreDatabaseSettings>(
    builder.Configuration.GetSection("ManifestStoreDatabase"));

builder.Services.AddSingleton<BooksService>();
builder.Services.AddSingleton<ManifestService>();
//builder.Services.AddSingleton<IPageService, PageService>();
builder.Services.AddSingleton<IPageService, PageService>();


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
