using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SecretManager1.Models;
using Serilog;

#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8618

namespace SecretManager1.Pages;
public class IndexModel(IConfiguration configuration) : PageModel
{
    [BindProperty]
    public string ConnectionString { get; set; }

    [BindProperty]
    public MailSettings MailSettings { get; set; }

    public void OnGet()
    {
        // Cache the section lookup to avoid repeated dictionary lookups
        var mailSection = configuration.GetSection(nameof(MailSettings));
        MailSettings = mailSection.Get<MailSettings>();
        Log.Information("MailSettings: {@MailSettings}", MailSettings);
        var connSection = configuration.GetSection(nameof(ConnectionStrings));
        ConnectionString = connSection.GetValue<string>(nameof(ConnectionStrings.DefaultConnection))!;
    }
}
