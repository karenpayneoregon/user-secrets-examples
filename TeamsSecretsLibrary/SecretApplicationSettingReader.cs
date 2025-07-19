#nullable disable
using Microsoft.Extensions.Configuration;
using System.Reflection;
using TeamsSecretsLibrary.Models;

namespace TeamsSecretsLibrary;

/// <summary>
/// Provides functionality to read application settings and secrets from configuration files, 
/// environment variables, and user secrets based on the current environment.
/// </summary>
/// <remarks>
/// This class is a singleton and provides methods to read configuration sections, properties, 
/// and predefined settings such as connection strings, mail settings, and help desk information.
/// It supports multiple environments, including Development and Production, and automatically 
/// determines the working environment.
/// </remarks>
public sealed class SecretApplicationSettingReader
{
    private static readonly Lazy<SecretApplicationSettingReader> _instance = new(() => new());

    public static SecretApplicationSettingReader Instance => _instance.Value;
    private readonly IConfigurationRoot _configuration;
    private readonly EnvironmentType _environment;

    private SecretApplicationSettingReader()
    {
        _environment = GetWorkingEnvironment();

        var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{_environment}.json", optional: true)
            .AddEnvironmentVariables();

        if (_environment == EnvironmentType.Development)
        {
            builder.AddUserSecrets(Assembly.GetExecutingAssembly());
        }

        _configuration = builder.Build();
    }

    public T ReadSection<T>(string sectionName)
            => _configuration.GetSection(sectionName).Get<T>();

    public T ReadProperty<T>(string sectionName, string name)
        => _configuration.GetSection(sectionName).GetValue<T>(name);

    public string ConnectionString
        => ReadProperty<string>(nameof(Connectionstrings), nameof(Connectionstrings.DefaultConnection));

    public MailSettings MailSettings
        => ReadSection<MailSettings>(nameof(MailSettings));

    public HelpDesk HelpDesk
        => ReadSection<HelpDesk>(nameof(HelpDesk));

    public EnvironmentType Environment => _environment;

    public static EnvironmentType GetWorkingEnvironment() =>
        System.Environment.GetEnvironmentVariable("CONSOLE_ENVIRONMENT") switch
        {
            "Development" => EnvironmentType.Development,
            "Production" => EnvironmentType.Production,
            _ => EnvironmentType.Development
        };

}
