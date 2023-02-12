using System.Runtime.CompilerServices;
using F0.GeneratedNamespace;
using F0.Talks.SourceGenerators.Demo;

JsonSerializerDemo.Roundtrip();
Console.WriteLine();

Console.WriteLine($"ModuleInitializer: {Helper.Text}");

Console.WriteLine($"Roslyn 3.8: {Helper.GetText()}");
Console.WriteLine($"Roslyn 3.9: {PostInitialization.Roslyn3_9.Get()}");

Console.WriteLine($"Roslyn 4.0: {new Generated1().Number}");

Console.WriteLine($"Roslyn 4.3: {Helper.GetNumber()}");

public static partial class Helper
{
    public static string? Text { get; set; }

    [ModuleInitializer]
    internal static void Init()
    {
        Text = "initialized";
    }

    internal static partial string GetText();

    [Generated]
    internal static partial int GetNumber();
}
