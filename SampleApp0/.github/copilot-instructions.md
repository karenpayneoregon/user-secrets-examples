# Copilot Instructions for SampleApp0

## Project Overview
- **Type:** .NET Console Application (net9.0)
- **Purpose:** Secure configuration management using user secrets, environment variables, and JSON config files.
- **Key Libraries:**
  - Microsoft.Extensions.Configuration (JSON, EnvironmentVariables, UserSecrets)
  - Spectre.Console (console UI)
  - Custom: ConfigurationLibrary, ConsoleHelperLibrary

## Architecture & Data Flow
- **Configuration Loading:**
  - Centralized in `Classes/SecretApplicationSettingReader.cs` (singleton).
  - Loads settings from:
    - `appsettings.json` (base config)
    - `appsettings.{Environment}.json` (optional, based on `CONSOLE_ENVIRONMENT`)
    - Environment variables
    - User secrets (only in Development)
- **Environment Detection:**
  - Uses `CONSOLE_ENVIRONMENT` env var; defaults to Development if unset.
- **Models:**
  - `Models/Connectionstrings.cs`, `MailSettings.cs`, `HelpDesk.cs`, `EnvironmentType.cs` define config schema.
- **Access Pattern:**
  - Use `SecretApplicationSettingReader.Instance` to read config sections/properties.
  - Example: `Instance.ReadSection<MailSettings>(nameof(MailSettings))`

## Developer Workflows
- **Build:**
  - Standard .NET build: `dotnet build` (from project root)
- **Run:**
  - `dotnet run` (from project root)
  - Can set `CONSOLE_ENVIRONMENT` to switch config: `CONSOLE_ENVIRONMENT=Production dotnet run`
- **User Secrets:**
  - Managed via `dotnet user-secrets` CLI (see `UserSecrets.md` for sample values)
  - UserSecretsId is set in `.csproj` and AssemblyInfo
- **Debugging:**
  - Console output uses Spectre.Console for markup
  - Window position set via `WindowUtility` (from ConsoleHelperLibrary)

## Project-Specific Conventions
- **Global Usings:**
  - See `GlobalUsings.cs` for project-wide imports
- **Partial Program Class:**
  - `Program.cs` and `Classes/Program.cs` both define `internal partial class Program` for separation of concerns
- **Nullable Disabled:**
  - Nullable reference types are disabled in `.csproj`
- **No Tests Present:**
  - No test projects or test files detected

## Integration Points & External Dependencies
- **Custom Libraries:**
  - `ConfigurationLibrary` and `ConsoleHelperLibrary` are referenced; their APIs are used for config and console utilities
- **Spectre.Console:**
  - Used for rich console output
- **User Secrets:**
  - See `UserSecrets.md` for expected secret structure

## Key Files & Directories
- `Program.cs` (main entry, config usage examples)
- `Classes/SecretApplicationSettingReader.cs` (core config logic)
- `Models/` (config schema)
- `UserSecrets.md` (sample secrets)
- `GlobalUsings.cs` (project-wide usings)

## Example: Reading a Config Value
```csharp
var mailSettings = SecretApplicationSettingReader.Instance.ReadSection<MailSettings>(nameof(MailSettings));
Console.WriteLine(mailSettings.FromAddress);
```

---

**Feedback Requested:**
- Are any workflows, conventions, or integration points unclear or missing?
- Is there project-specific logic that should be documented for future agents?
