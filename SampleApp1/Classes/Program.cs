using System.Reflection;
using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace SampleApp1;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        var assembly = Assembly.GetEntryAssembly();
        var product = assembly?.GetCustomAttribute<AssemblyProductAttribute>().Product;

        Console.Title = product!;
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }
}
