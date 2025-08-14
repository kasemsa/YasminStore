using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using YasminStore.Domain;
using YasminStore.Infrastructure;
using YasminStore.Application;
using YasminStore.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();


builder.Services.AddPersistenceServices(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Yasmin Store",
        Version = "v1"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please insert JWT with Bearer into field",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
           {
               new OpenApiSecurityScheme
               {
                   Reference = new OpenApiReference
                   {
                         Type = ReferenceType.SecurityScheme,
                         Id = "Bearer"
                   }
               },
              new string[] { }
           }
        });
});

builder.Services.AddHttpContextAccessor();

// ✅ إضافة CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("Open", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});

var app = builder.Build();

// Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
           Path.Combine(builder.Environment.ContentRootPath, "wwwroot/UploadedFiles")),
    RequestPath = "/UploadedFiles"
});

app.UseHttpsRedirection();

app.UseCors("Open"); // ✅ قبل Authorization
app.UseAuthorization();

app.MapControllers();
app.Run();
