using eCommerceApp.Application.DependencyInjection;
using eCommerceApp.Infrastructure.DependencyInjection;
using Serilog;
using System.Text.Json.Serialization;
var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("log/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();
Log.Logger.Information("Application is building.......");

builder.Services.AddControllers().AddJsonOptions(options =>
     options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddInfrastructureService(builder.Configuration);
builder.Services.AddApplicationService();

// تكوين CORS بشكل صريح
builder.Services.AddCors(options =>
{
    options.AddPolicy("BlazorClientPolicy", policy =>
    {
        policy.WithOrigins("https://ecommerce-api.onrender.com") // أصل تطبيق Blazor    policy.WithOrigins("https://localhost:7165")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials(); // السماح بإرسال الـ Cookies
    });
});

try
{
    var app = builder.Build();

    app.UseSerilogRequestLogging();

    app.UseCors("BlazorClientPolicy"); 

   
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseInfrastructureService();
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();

    Log.Logger.Information("Application is running.......");
    app.Run();
}
catch (Exception ex)
{
    Log.Logger.Error(ex, "Application failed to start....");
}
finally
{
    Log.CloseAndFlush();
}
