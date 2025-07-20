# Copilot Instructions for UtilityTestApp

## Project Overview
- **Type:** .NET Console Application (`net9.0`)
- **Purpose:** Utility for inspecting and reporting .NET UserSecrets and related configuration.
- **Key Libraries:**
  - `Spectre.Console` for rich console output
  - `SecretsUtilities` (local project reference) for secrets management
  - `ConsoleHelperLibrary` and `ConfigurationLibrary` (NuGet packages)

## Architecture & Patterns
- **Entry Point:**
  - `Program.cs` in root: Main logic for secrets inspection.
  - `Classes/Program.cs`: Partial class for console window setup using `WindowUtility`.
- **Global Usings:**
  - Defined in `GlobalUsings.cs` for common libraries.
- **Configuration:**
  - `appsettings.json` contains environment-specific connection strings.
  - Secrets are read from a referenced project (`TeamsSecretsLibrary.csproj`).

## Developer Workflows
- **Build:**
  - Standard .NET build: `dotnet build` or use Visual Studio.
- **Run:**
  - Run with: `dotnet run` or launch `UtilityTestApp.exe` from `bin/Debug/net9.0/`.
- **Debug:**
  - Use Visual Studio or `dotnet run` with breakpoints.
- **Dependencies:**
  - NuGet restore is automatic; ensure referenced DLLs are present in `bin/Debug/net9.0/`.

## Conventions & Practices
- **Partial Classes:**
  - Main logic and initialization split between root and `Classes/Program.cs`.
- **Console Output:**
  - Use `AnsiConsole.MarkupLine` for colored output.
- **Secrets Handling:**
  - All secrets logic is encapsulated in `SecretsUtilities` and `ProjectSecretsReader`.
- **Window Management:**
  - Console window positioning via `WindowUtility` in module initializer.

## Integration Points
- **External Projects:**
  - References `SecretsUtilities` and expects `TeamsSecretsLibrary.csproj` to exist at a relative path.
- **Configuration:**
  - Reads from `appsettings.json` and user secrets folders.

## Examples
- To check secrets, see `CheckProjectUserSecrets()` in `Program.cs`.
- To set up the console window, see `Init()` in `Classes/Program.cs`.

## Key Files
- `Program.cs` (root): Main logic
- `Classes/Program.cs`: Initialization
- `GlobalUsings.cs`: Common usings
- `appsettings.json`: Configuration
- `UtilityTestApp.csproj`: Project setup
