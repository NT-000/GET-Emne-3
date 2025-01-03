using WebApplicationTest;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
var textObjects = new List<TextObject>
{
    new TextObject { Index = 1, Text = "Nico", ForeColor = "blue", BackColor = "yellow" },
    new TextObject { Index = 2, Text = "Arne", ForeColor = "red", BackColor = "blue" },
};
app.MapGet("/textobjects", () =>
{
    return textObjects;
});
app.MapPost("/textobjects", (TextObject textObject) =>
{
    textObjects.Add(textObject);
});

app.Run();


// app.MapGet("/weatherforecast", () =>
// {
//     return new Person[]
//     {
//         new Person("Jan", "London", 1980),
//         new Person("Frode", "Johnsen", 1932)
//     };
// });