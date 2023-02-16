using Autofac;
using Autofac.Extensions.DependencyInjection;
using Boss.Auth.Application.Helper;
using Boss.Auth.Common.Configuration;
using Boss.Auth.WebApi.Configurations;
using Boss.Auth.WebApi.Middlewares;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Newtonsoft.Json;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);
var corsPolicyName = "cors";

builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();

builder.Services.AddSingleton<AppSettingsHelper>(new AppSettingsHelper(builder.Configuration));

// Setting DBContexts
builder.Services.AddDatabaseConfiguration(builder.Configuration);


// HttpClient Config
builder.Services.AddHttpClientConfiguration(builder.Configuration);

//Cors Conig
builder.Services.AddCors(c =>
{
    //允许任意跨域请求
    c.AddPolicy(corsPolicyName, policy =>
    {
        policy.SetIsOriginAllowed((host) => true)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
});

builder.Services.Configure<KestrelServerOptions>(x => x.AllowSynchronousIO = true)
          .Configure<IISServerOptions>(x => x.AllowSynchronousIO = true);


// WebAPI Config
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.NullValueHandling =NullValueHandling.Ignore;
});

// Swagger Config
builder.Services.AddSwaggerConfiguration();

// Jwt Config
builder.Services.AddJwtConfiguration();

// AutoMapper
builder.Services.AddAutoMapperConfiguration();

//关闭参数自动校验,我们需要返回自定义的格式
builder.Services.Configure<ApiBehaviorOptions>((o) =>
{
    o.SuppressModelStateInvalidFilter = true;
});

// NLog: Setup NLog for Dependency injection
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Host.UseNLog();


builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule<AutofacModule>();
});

var app = builder.Build();

app.UseMiddleware<ExceptionLogMiddleware>();
app.UseMiddleware<RequestResponseLogMiddleware>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerSetup();
}

app.UseHttpsRedirection();

//配置HttpContext
app.UseStaticHttpContext();

app.UseCors(corsPolicyName);

app.UseRouting();

app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();

app.Run();