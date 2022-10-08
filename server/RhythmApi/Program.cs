using RhythmApi;
using SkiaSharp;

var calculator = new RhythmDesigner(4, 4, 9);
var beats = calculator.AssignRhythms();

foreach (var beat in beats) 
{
    Console.WriteLine(beat);
}

var imgBuilder = new ImageBuilder(beats, 4);
var result = imgBuilder.MakeImage();

using (var image = SKImage.FromBitmap(result))
using (var data = image.Encode(SKEncodedImageFormat.Png, 80))
{
    using (var stream = File.OpenWrite(Path.Combine("./src", "1.png")))
    {
        data.SaveTo(stream);
    }
}