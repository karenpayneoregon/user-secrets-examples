using SampleApp0.Classes;
using SampleApp0.Models;

namespace SampleApp0;

internal partial class Program
{
    static void Main(string[] args)
    {
        var connectionString = SecretApplicationSettingReader
            .Instance.ReadProperty<string>(nameof(Connectionstrings), nameof(Connectionstrings.DefaultConnection));

        var mailSettings = SecretApplicationSettingReader
            .Instance.ReadSection<MailSettings>(nameof(MailSettings));

        var helpDesk = SecretApplicationSettingReader.Instance.HelpDesk;


        AnsiConsole.MarkupLine($"[bold yellow]   Connection String:[/] {connectionString}");

        AnsiConsole.MarkupLine($"[bold green1]  Mail Settings From:[/] {mailSettings.FromAddress}");
        AnsiConsole.MarkupLine($"[bold green1]  Mail Settings Port:[/] {mailSettings.Port}");
        AnsiConsole.MarkupLine($"[bold green1]Mail Settings Pickup:[/] {mailSettings.PickupFolder}");

        AnsiConsole.MarkupLine($"[bold hotpink2]     Help Desk Phone:[/] {helpDesk.Phone}");
        AnsiConsole.MarkupLine($"[bold hotpink2]     Help Desk Email:[/] {helpDesk.Email}");

        Console.WriteLine();

        AnsiConsole.MarkupLine("[yellow]Exit[/]");
        Console.ReadLine();
    }
}