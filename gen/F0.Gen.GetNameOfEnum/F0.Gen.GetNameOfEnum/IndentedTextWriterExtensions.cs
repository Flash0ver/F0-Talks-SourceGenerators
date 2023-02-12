using System.CodeDom.Compiler;

namespace F0.Gen.GetNameOfEnum;

internal static class IndentedTextWriterExtensions
{
    public static void OpenBlock(this IndentedTextWriter writer)
    {
        writer.WriteLine("{");
        writer.Indent++;
    }

    public static void CloseBlock(this IndentedTextWriter writer)
    {
        writer.Indent--;
        writer.WriteLine("}");
    }

    public static void CloseBlockSemicolon(this IndentedTextWriter writer)
    {
        writer.Indent--;
        writer.WriteLine("};");
    }

    public static void WriteLineNoTabs(this IndentedTextWriter writer)
    {
        writer.WriteLineNoTabs(null);
    }
}
