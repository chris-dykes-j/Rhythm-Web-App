using RhythmApi;
using SkiaSharp;


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Need to figure out how this all works.
app.MapGet("/", () => "Cool test");

app.MapGet("/{timeSignature}/{subDivision}/{totalNotes}", () => "Hi");

app.Run();


// Refactor as unit tests, later.

// Create blueprint test
var blueprint = new RhythmDesigner(4, 4, 2);
var beats = blueprint.AssignRhythms();
foreach (var beat in beats) 
    Console.WriteLine(beat);

// Create image test
var imgBuilder = new ImageBuilder(beats, 4);
var result = imgBuilder.MakeImage();

// Save image test
var image = SKImage.FromBitmap(result);
using var data = image.Encode(SKEncodedImageFormat.Png, 80);
using var stream = File.OpenWrite(Path.Combine("./src", "test.png"));
data?.SaveTo(stream);
