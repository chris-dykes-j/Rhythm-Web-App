var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// builder.Services.AddScoped(typeof(IWebHostEnvironment));
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "Client", policy =>
        policy.WithOrigins("http://127.0.0.1:5500"));
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors("Client");
app.UseStaticFiles();
app.MapControllers();

app.Run();

// More Test
/*
var data = new RhythmData(4, 4, 5);
var rhythmBuilder = new RhythmBuilder(data);
rhythmBuilder.MakeRhythm();
string path = rhythmBuilder.GetImagePath();
Console.WriteLine(path);
*/

// Need to figure out how this all works.

/*
// Refactor as unit tests, later.

// Create blueprint test
var blueprint = new RhythmDesigner(4, 4, 10);
var beats = blueprint.AssignRhythms();
foreach (var beat in beats) 
    Console.WriteLine(beat);

// Create image test
var imgBuilder = new ImageBuilder(beats, 4);
var image = imgBuilder.MakeImage();

// Save image test
using var data = image.Encode(SKEncodedImageFormat.Png, 80);
using var stream = File.OpenWrite(Path.Combine("./src", "test.png"));
data?.SaveTo(stream);
*/