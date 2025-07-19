using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SecretsLibrary1;
using SecretsModelsLibrary.Models;

namespace SampleApp5.Pages;
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
        var connectionString = SecretApplicationSettingReader
            .Instance.ReadProperty<string>(nameof(Connectionstrings), nameof(Connectionstrings.DefaultConnection));

        var mailSettings = SecretApplicationSettingReader
            .Instance.ReadSection<MailSettings>(nameof(MailSettings));

        Debugger.Break();

    }

    public void OnGet()
    {

    }
}
