# Copilot Instructions for TeamsSecretsLibrary

## Project Overview
- This is a .NET library for reading application secrets and settings, designed to be used as a NuGet package or project reference.
- Combines functionality from `SecretsLibrary1` and `SecretsModalLibrary1`.
- Main class: `SecretApplicationSettingReader` (singleton pattern).
- Supports multiple environments (Development, Production) and loads configuration from JSON files, environment variables, and user secrets.

## Key Components
- `SecretApplicationSettingReader.cs`: Core logic for reading configuration and secrets.
- `Models/`: Contains POCOs for configuration sections:
  - `Connectionstrings.cs`: Holds connection string(s).
  - `MailSettings.cs`: SMTP/mail configuration.
  - `HelpDesk.cs`: Help desk contact info.
  - `EnvironmentType.cs`: Enum for environment selection.
- `TeamsSecretsLibrary.csproj`: Project file, includes NuGet dependencies for configuration and secrets management.

## Configuration Loading Pattern
- Loads `appsettings.json` and `appsettings.{Environment}.json` (where environment is Development or Production).
- Uses environment variable `CONSOLE_ENVIRONMENT` to select environment; defaults to Development.
- In Development, also loads user secrets via `AddUserSecrets`.
- Access configuration sections via strongly-typed models (see `ReadSection<T>` and `ReadProperty<T>` methods).

## Build & Packaging
- Build with standard .NET commands (`dotnet build`).
- Generates NuGet package on build (`GeneratePackageOnBuild=True`).
- Local NuGet package output: `bin/Debug/TeamsSecretsLibrary.1.0.0.nupkg`.

## Usage Example
```csharp
var reader = SecretApplicationSettingReader.Instance;
var connStr = reader.ConnectionString;
var mail = reader.MailSettings;
var helpDesk = reader.HelpDesk;
```

## Conventions & Patterns
- Singleton access for configuration reader.
- All configuration models are in `Models/` and use auto-properties.
- Environment selection is explicit and defaults to Development if not set.
- No test files or custom build scripts detected; standard .NET workflows apply.

## External Dependencies
- Microsoft.Extensions.Configuration (and related packages)
- ConfigurationLibrary (custom or external, version 1.0.6)

## Integration Points
- Designed for integration into .NET applications via NuGet or project reference.
- No direct cross-component communication; all data flows through configuration models.

---
If any section is unclear or missing, please specify what needs improvement or additional detail.
