using Statiq.App;
using Statiq.Common;
using Statiq.Markdown;

return await Bootstrapper
    .Factory
    .CreateDefault(args)
    .BuildPipeline("Render Markdown", builder => builder
        .WithInputReadFiles("*.md")
        .WithProcessModules(new RenderMarkdown())
        .WithPostProcessModules(new SlideModule())
        .WithOutputWriteFiles(".html"))
    .BuildPipeline("Copy CSS", builder => builder
        .WithInputReadFiles("*.css")
        .WithOutputWriteFiles(".css"))
    .RunAsync();

internal sealed class SlideModule : ParallelModule
{
    protected override async Task<IEnumerable<IDocument>> ExecuteInputAsync(IDocument input, IExecutionContext context)
    {
        input.GetContentProvider();

        MemoryStream stream = new();
        StreamWriter writer = new(stream);

        await writer.WriteLineAsync("<!DOCTYPE html>");
        await writer.WriteLineAsync("<html>");
        await writer.WriteLineAsync("<head>");
        await writer.WriteLineAsync(@"<link rel=""stylesheet"" href=""styles.css"">");
        await writer.WriteLineAsync("</head>");
        await writer.WriteLineAsync("<body>");
        await writer.FlushAsync();

        using (Stream content = input.ContentProvider.GetStream())
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
