using TeamsSecretsLibrary;
using TeamsSecretsLibrary.Models;

namespace UsesLocalPackageApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        var connectionString = SecretApplicationSettingReader
            .Instance.ReadProperty<string>(nameof(Connectionstrings), nameof(Connectionstrings.DefaultConnection));

        var mailSettings = SecretApplicationSettingReader
            .Instance.ReadSection<MailSettings>(nameof(MailSettings));

        var helpDesk = SecretApplicationSettingReader.Instance.HelpDesk;

        var layout = SecretApplicationSettingReader
            .Instance.ReadSection<Models.Layout>(nameof(Models.Layout));


        AnsiConsole.MarkupLine($"[bold yellow]   Connection String:[/] {connectionString}");

        AnsiConsole.MarkupLine($"[bold green1]  Mail Settings From:[/] {mailSettings.FromAddress}");
        AnsiConsole.MarkupLine($"[bold green1]  Mail Settings Port:[/] {mailSettings.Port}");
        AnsiConsole.MarkupLine($"[bold green1]Mail Settings Pickup:[/] {mailSettings.PickupFolder}");

        AnsiConsole.MarkupLine($"[bold hotpink2]     Help Desk Phone:[/] {helpDesk.Phone}");
        AnsiConsole.MarkupLine($"[bold hotpink2]     Help Desk Email:[/] {helpDesk.Email}");

        // not in secrets
        AnsiConsole.MarkupLine($"[bold blue]              Header:[/] {layout.Header}");
        AnsiConsole.MarkupLine($"[bold blue]               Title:[/] {layout.Title}");
        AnsiConsole.MarkupLine($"[bold blue]              Footer:[/] {layout.Footer}");

        Console.ReadLine();
    }
}