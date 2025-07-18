using Serilog;
using Serilog.Events;
using System.Net.Mail;

namespace SecretManager1;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            .MinimumLevel.Override("System", LogEventLevel.Warning)
            .MinimumLevel.Information()
            .WriteTo.File(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogFiles",
                    $"{DateTime.Now.Year}-{DateTime.Now.Month:d2}-{DateTime.Now.Day:d2}", "Log.txt"),
                rollingInterval: RollingInterval.Infinite,
                outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level}] {Message}{NewLine}{Exception}")
            .CreateLogger();



        builder.Host.UseSerilog();
        // Add services to the container.
        builder.Services.AddRazorPages();


        builder.Services.Configure<MailAddress>(
            builder.Configuration.GetSection(nameof(MailAddress)));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();
    }
}