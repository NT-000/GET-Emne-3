using System.Text.Json;
using WebApplicationTest;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
List<TextObject> textObjects;
if (File.Exists("textobjects.json"))
{
    var json = File.ReadAllText("textobjects.json");
    JsonSerializer.Deserialize<List<TextObject>>(json);
}
else
{
    textObjects = new List<TextObject>();
}
textObjects = new List<TextObject>(); 

app.MapGet("/textobjects", () =>
{
    return textObjects;
});
app.MapPost("/textobjects", (TextObject textObject) =>
{
    textObjects.Add(textObject);
    var json = JsonSerializer.Serialize(textObject);
    File.WriteAllText("textobjects.json", json);
});

app.Run();
