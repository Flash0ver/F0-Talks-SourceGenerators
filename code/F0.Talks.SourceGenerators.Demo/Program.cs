using F0.Talks.SourceGenerators.Demo;
using System.Runtime.CompilerServices;

JsonSerializerDemo.Roundtrip();

Console.WriteLine(Helper.Text);
Console.WriteLine(Helper.Get());

Console.WriteLine(PostInitialization.Roslyn3_9.Get());

Console.WriteLine(new Generated1().Number);

public static partial class Helper
{
    public static string? Text { get; set; }

    [ModuleInitializer]
    internal static void Init()
    {
        Text = "initialized";
    }

    internal static partial string Get();
}
