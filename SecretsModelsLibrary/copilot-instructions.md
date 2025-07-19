# Copilot Instructions for SecretsModelsLibrary

## Project Overview
- This is a .NET class library targeting `net9.0`.
- The main purpose is to provide strongly-typed models for secrets/configuration, such as connection strings, mail settings, help desk info, and environment type.
- All models are located in the `Models/` directory and use the namespace `SecretsModelsLibrary.Models`.

## Key Components
- `Connectionstrings`: Holds a single property `DefaultConnection` for connection string management.
- `EnvironmentType`: Enum for `Development` and `Production` environments.
- `HelpDesk`: Contains `Phone` and `Email` properties for support contact info.
- `MailSettings`: Contains mail configuration properties. Has a default value for `PickupFolder` and a custom `ToString()` override for easy logging/debugging.

## Patterns & Conventions
- All model classes use auto-properties and are simple POCOs.
- Nullable reference types are enabled (`<Nullable>enable</Nullable>` in `.csproj`).
- Implicit global usings are enabled (`<ImplicitUsings>enable</ImplicitUsings>`).
- Some classes use `#pragma warning disable CS8618` to suppress nullable warnings for non-initialized properties.
- Default values are set directly in property initializers (see `MailSettings.PickupFolder`).

## Developer Workflows
- **Build:** Use `dotnet build` in the project root to build the library.
- **Output:** Compiled DLLs are found in `bin/Debug/net9.0/`.
- **No tests or external dependencies** are present in this codebase.
- **Debugging:** Use the `ToString()` override in `MailSettings` for quick inspection of mail config objects.

## Integration Points
- This library is intended to be referenced by other .NET projects for configuration/secrets modeling.
- No direct external service integration or cross-component communication is present.

## Example Usage
```csharp
using SecretsModelsLibrary.Models;
var mail = new MailSettings { FromAddress = "noreply@example.com", Host = "smtp.example.com", Port = 25 };
Console.WriteLine(mail); // Uses custom ToString()
```

## File References
- `Models/Connectionstrings.cs`, `Models/EnvironmentType.cs`, `Models/HelpDesk.cs`, `Models/MailSettings.cs`
- `SecretsModelsLibrary.csproj` for build settings

---
If any section is unclear or missing, please provide feedback to improve these instructions.
