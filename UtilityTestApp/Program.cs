using SecretsUtilities;

namespace UtilityTestApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        CheckProjectUserSecrets();
        
        Console.WriteLine();
        AnsiConsole.MarkupLine("[yellow]Exit[/]");
        Console.ReadLine();
    }

    private static void CheckProjectUserSecrets()
    {
        var reader = new ProjectSecretsReader(@"..\..\..\..\TeamsSecretsLibrary\TeamsSecretsLibrary.csproj");
        if (!reader.Continue)
        {
            AnsiConsole.MarkupLine("[red]Project file not found[/]");
            return;
        }

        if (reader.Exists())
        {
            AnsiConsole.MarkupLine($"[cyan]UserSecretsId found:[/] {reader.GetValue()}");
        }
        else
        {
            AnsiConsole.MarkupLine("[red]UserSecretsId not found.[/]");
        }


        if (Utilities.SecretsFolderExists)
        {
            AnsiConsole.MarkupLine($"[cyan]UserSecrets folder found:[/] {Utilities.SecretsFolder}");

            if (reader.ProjectFolderExists())
            {
                AnsiConsole.MarkupLine(
                    $"[cyan]UserSecrets project folder found:[/] {Path.Combine(Utilities.SecretsFolder, reader.GetValue()!)}");
            }
            else
            {
                AnsiConsole.MarkupLine("[red]UserSecrets project folder not found.[/]");
            }
        }
    }
}