using Statiq.Markdown;
using System.Text.RegularExpressions;

return await Bootstrapper
    .Factory
    .CreateDefault(args)
    .BuildPipeline("Render Presentation", static builder => builder
        .WithInputReadFiles("*.md")
        .WithProcessModules(new LinkModule(), new RenderMarkdown())
        .WithPostProcessModules(new SlideModule())
        .WithOutputWriteFiles(".html"))
    .BuildPipeline("Copy CSS", static builder => builder
        .WithInputReadFiles("*.css")
        .WithOutputWriteFiles(".css"))
    .RunAsync();

internal sealed class LinkModule : ParallelModule
{
    private readonly Regex regex;

    public LinkModule()
    {
        regex = new Regex(@"(\[.+]\(\.\/[^/]+\.)(md)(\))", RegexOptions.Compiled);
    }

    protected override async Task<IEnumerable<IDocument>> ExecuteInputAsync(IDocument input, IExecutionContext context)
    {
        MemoryStream stream = new();
        StreamWriter writer = new(stream);

        await using (Stream content = input.ContentProvider.GetStream())
        {
            using (StreamReader reader = new(content))
            {
                while (await reader.ReadLineAsync() is { } line)
                {
                    line = regex.Replace(line, "$1html$3", 1);

                    await writer.WriteLineAsync(line);
                }
            }
        }

        await writer.FlushAsync();

        IContentProvider provider = context.GetContentProvider(stream, MediaTypes.Html);

        IEnumerable<IDocument> output = input
            .Clone(input.Source, input.Destination, context, provider)
            .Yield();

        return output;
    }
}

internal sealed class SlideModule : ParallelModule
{
    protected override async Task<IEnumerable<IDocument>> ExecuteInputAsync(IDocument input, IExecutionContext context)
    {
        MemoryStream stream = new();
        StreamWriter writer = new(stream);

        await writer.WriteLineAsync("<!DOCTYPE html>");
        await writer.WriteLineAsync("<html>");
        await writer.WriteLineAsync("<head>");
        await writer.WriteLineAsync(@"<link rel=""stylesheet"" href=""styles.css"">");
        await writer.WriteLineAsync("</head>");
        await writer.WriteLineAsync("<body>");
        await writer.FlushAsync();

        await using (Stream content = input.ContentProvider.GetStream())
        {
            await content.CopyToAsync(stream);
        }

        await writer.WriteLineAsync("</body>");
        await writer.WriteLineAsync("</html> ");
        await writer.FlushAsync();

        IContentProvider provider = context.GetContentProvider(stream, MediaTypes.Html);

        IEnumerable<IDocument> output = input
            .Clone(input.Source, input.Destination, context, provider)
            .Yield();

        return output;
    }
}
