# Copilot Instructions for SecretsUtilities

## Project Overview
This is a .NET 9.0 utility library focused on reading and managing user secrets for .NET projects. The main components are:
- `Utilities.cs`: Static helpers for locating and validating the user secrets folder, constructing project-specific paths, and checking JSON object emptiness.
- `ProjectSecretsReader.cs`: Reads `.csproj` files to extract the `UserSecretsId` and verify the existence of secrets folders for a given project.

## Key Architectural Patterns
- **Secrets Folder Location**: The secrets folder is determined by OS:
  - Windows: `%APPDATA%\Microsoft\UserSecrets`
  - Linux/Mac: `~/.microsoft/usersecrets`
- **Project-Specific Secrets**: Each project has a folder named after its `UserSecretsId` inside the secrets folder.
- **Separation of Concerns**: `Utilities` provides static methods for path and folder logic; `ProjectSecretsReader` handles `.csproj` parsing and secrets ID extraction.

## Developer Workflows
- **Build**: Standard .NET build (`dotnet build`) targeting `net9.0`. No custom build steps detected.
- **Debug**: Use Visual Studio or `dotnet run` for debugging. No special launch profiles or environment variables required.
- **Testing**: No test projects or test files detected. If adding tests, follow standard .NET conventions.

## Project-Specific Conventions
- **UserSecretsId Extraction**: Always use `ProjectSecretsReader.GetValue()` to retrieve the secrets ID from a `.csproj` file.
- **Folder Existence Checks**: Use `Utilities.SecretsFolderExists` and `ProjectSecretsReader.ProjectFolderExists()` for robust folder validation.
- **JSON Handling**: Use `Utilities.IsEmptyJsonObject(string)` to check for empty or invalid JSON objects.

## Integration Points
- **External Dependencies**: Relies on `System.Text.Json` and `System.Xml.Linq` for JSON and XML parsing.
- **No External Services**: No network or cloud integrations detected.

## Example Usage
- To get the secrets folder path:
  ```csharp
  var folder = Utilities.SecretsFolder;
  ```
- To check if a project secrets folder exists:
  ```csharp
  var reader = new ProjectSecretsReader("path/to/project.csproj");
  bool exists = reader.ProjectFolderExists();
  ```

## File References
- `Utilities.cs`: Path logic, JSON helpers
- `ProjectSecretsReader.cs`: .csproj parsing, secrets ID management
- `SecretsUtilities.csproj`: Project configuration

---
If any conventions or workflows are unclear or missing, please provide feedback to improve these instructions.
