using System.Text.Json;
using System.Text.Json.Serialization;

namespace F0.Talks.SourceGenerators.Demo;

internal static class JsonSerializerDemo
{
    public static void Roundtrip()
    {
        Entity entity = new()
        {
            Name = "Generation",
            Number = 0x_F0,
        };

        string json = JsonSerializer.Serialize(entity, SerializerContext.Default.Entity);
        Console.WriteLine(json);

        Entity? roundtrip = JsonSerializer.Deserialize<Entity>(json, SerializerContext.Default.Entity);
        Console.WriteLine(roundtrip!.ToString());
    }
}

public record class Entity
{
    public string? Name { get; set; }
    public int Number { get; set; }
}

[JsonSerializable(typeof(Entity))]
[JsonSourceGenerationOptions(WriteIndented = true)]
public partial class SerializerContext : JsonSerializerContext
{
}
