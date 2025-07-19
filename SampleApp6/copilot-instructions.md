# Copilot Instructions for SampleApp6

## Project Overview
- **SampleApp6** is a .NET console application targeting `net9.0`.
- Main logic is in `Program.cs` and `Classes/Program.cs` (partial class).
- Uses custom libraries: `TeamsSecretsLibrary`, `ConfigurationLibrary`, `ConsoleHelperLibrary`, and `Spectre.Console` for enhanced console output and configuration management.

## Architecture & Data Flow
- **Configuration**: Reads secrets and settings from `appsettings.json` via `TeamsSecretsLibrary`.
- **Mail & HelpDesk**: Loads mail settings and help desk info using strongly-typed models from secrets/config.
- **Console UI**: Uses `Spectre.Console` for colored output and `WindowUtility` (from `ConsoleHelperLibrary`) for window positioning.
- **Partial Class Pattern**: Main entry (`Program.cs`) and initialization logic (`Classes/Program.cs`) are split using C# partial classes.

## Developer Workflows
- **Build**: Use standard .NET CLI or Visual Studio build commands. No custom build scripts detected.
- **Run**: Execute via `dotnet run` or run `SampleApp6.exe` from `bin/Debug/net9.0/`.
- **Configuration**: Update `appsettings.json` for connection strings and mail settings. Secrets are accessed via `TeamsSecretsLibrary`.
- **Debugging**: Console title and window position are set for clarity; use Visual Studio or CLI debuggers as normal.

## Project-Specific Conventions
- **Global Usings**: See `GlobalUsings.cs` for commonly used namespaces.
- **Partial Classes**: Initialization logic is separated into `Classes/Program.cs` using `[ModuleInitializer]`.
- **Secrets Access**: Always use `SecretApplicationSettingReader.Instance` for reading config/secrets.
- **Console Output**: Prefer `AnsiConsole.MarkupLine` for colored output.

## Integration Points & Dependencies
- **External Libraries**:
  - `TeamsSecretsLibrary`: Handles secret/config access.
  - `ConfigurationLibrary`, `ConsoleHelperLibrary`: Utility and configuration helpers.
  - `Spectre.Console`: Rich console UI.
- **Project References**: See `.csproj` for package and project references.

## Key Files & Directories
- `Program.cs`: Main entry point.
- `Classes/Program.cs`: Initialization logic.
- `GlobalUsings.cs`: Global using directives.
- `appsettings.json`: Configuration and secrets.
- `.csproj`: Project structure and dependencies.
- `assets/`: Icons and images for the app.

## Example Patterns
- **Read a secret property**:
  ```csharp
  SecretApplicationSettingReader.Instance.ReadProperty<string>(nameof(Connectionstrings), nameof(Connectionstrings.DefaultConnection));
  ```
- **Read a config section**:
  ```csharp
  SecretApplicationSettingReader.Instance.ReadSection<MailSettings>(nameof(MailSettings));
  ```
- **Set console window position**:
  ```csharp
  WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
  ```

---
_If any section is unclear or missing, please provide feedback to improve these instructions._
