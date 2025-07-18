using SecretsLibrary1;
using SecretsModelsLibrary.Models;

namespace SampleApp1;

internal partial class Program
{
    static void Main(string[] args)
    {

        var connectionString = SecretApplicationSettingReader
            .Instance.ReadProperty<string>(nameof(Connectionstrings), nameof(Connectionstrings.DefaultConnection));

        var mailSettings = SecretApplicationSettingReader
            .Instance.ReadSection<MailSettings>(nameof(MailSettings));
        
        AnsiConsole.MarkupLine($"[bold yellow]   Connection String:[/] {connectionString}");
        AnsiConsole.MarkupLine($"[bold yellow]  Mail Settings From:[/] {mailSettings.FromAddress}");
        AnsiConsole.MarkupLine($"[bold yellow]  Mail Settings Port:[/] {mailSettings.Port}");
        AnsiConsole.MarkupLine($"[bold yellow]Mail Settings Pickup:[/] {mailSettings.PickupFolder}");

        Console.WriteLine();

        AnsiConsole.MarkupLine("[yellow]Exit[/]");
        Console.ReadLine();
    }
}