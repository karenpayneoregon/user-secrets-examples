# Copilot Instructions for SecretsLibrary1

## Project Overview
- This is a .NET 9.0 class library for securely reading application secrets and configuration settings.
- Main entry point: `SecretApplicationSettingReader` (singleton pattern).
- Secrets are loaded from multiple sources: `appsettings.json`, environment-specific config, environment variables, and user secrets (in development).
- User secrets are managed via the `UserSecretsId` in the `.csproj` and stored in a local secrets store. See `UserSecrets.md` for example structure.
- The library depends on `SecretsModelsLibrary` for models and uses `Microsoft.Extensions.Configuration` for config management.

## Key Files & Structure
- `SecretApplicationSettingReader.cs`: Core logic for loading and accessing secrets/configuration.
- `SecretsLibrary1.csproj`: Project file, defines dependencies and user secrets ID.
- `UserSecrets.md`: Example user secrets JSON structure.
- `SecretsModelsLibrary`: Referenced project for models.

## Patterns & Conventions
- Always use the singleton `SecretApplicationSettingReader.Instance` to access secrets.
- Use `ReadSection<T>(sectionName)` to bind config sections to strongly-typed models.
- Use `ReadProperty<T>(sectionName, name)` for individual values.
- Connection strings are accessed via the `ConnectionString` property.
- In development, secrets are loaded from the user secrets store (see `.csproj` for `UserSecretsId`).
- Environment-specific config is loaded from `appsettings.{Environment}.json` if present.

## Build & Debug Workflow
- Build with standard .NET commands: `dotnet build`.
- No custom build steps or scripts required.
- To use user secrets locally, ensure the secrets are set via `dotnet user-secrets set` or by editing the secrets JSON file directly.
- Debugging: Attach to library consumers or use unit tests (not present in this repo).

## Integration Points
- External dependencies: `Microsoft.Extensions.Configuration`, `SecretsModelsLibrary`, and optionally `ConfigurationLibrary`.
- No direct database or mail integration; secrets are only read, not used directly in this library.

## Example Usage
```csharp
var reader = SecretApplicationSettingReader.Instance;
var connStr = reader.ConnectionString;
var mailSettings = reader.ReadSection<MailSettings>("MailSettings");
```

## Additional Notes
- This library is intended to be consumed by other projects (e.g., Sample1, Sample2, Sample3).
- User secrets are shared across these projects via the same `UserSecretsId`.
- For more details on user secrets, see [Microsoft Docs](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets).
