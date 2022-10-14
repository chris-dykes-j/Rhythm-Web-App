using System.Reflection;
using SkiaSharp;

namespace RhythmApi;

// Creates the final product.
public class ImageBuilder
{
    private readonly List<string> _notes;
    private readonly int _timeSignature;
    
    public ImageBuilder(List<string> notes, int timeSignature)
    {
        _notes = notes;
        _timeSignature = timeSignature;
    }

    // Makes the image.
    public SKBitmap MakeImage()
    {
        SKBitmap result;
        var start = GetTimeSignature();
        var rhythms = GetRhythmImages();

        int width = start.Width; // Width of the entire measure
        rhythms.ForEach(r => width += r.Width);
        
        result = new SKBitmap(width, rhythms[0].Height);
        using (var canvas = new SKCanvas(result))
        {
            canvas.DrawBitmap(start, 0, 0);
            float x = start.Width;
            rhythms.ForEach(rhythm =>
            { 
                canvas.DrawBitmap(rhythm, x, 0);
                x += rhythm.Width;
            });
        }
        return result;
    }
    
    // Gets the time signature image
    private SKBitmap GetTimeSignature()
    {
        var bitmap = new SKBitmap();
        string timeSource = _timeSignature switch  {
            4 => "RhythmApi.src.44.jpg",
            3 => "RhythmApi.src.34.jpg",
            2 => "RhythmApi.src.24.jpg",
            5 => "RhythmApi.src.54.jpg",
            6 => "RhythmApi.src.68.jpg",
            7 => "RhythmApi.src.78.jpg",
            9 => "RhythmApi.src.68.jpg",
            12 => "RhythmApi.src.98.jpg",
            _ => "RhythmApi.src.14.jpg",
        };
        var assembly = Assembly.GetExecutingAssembly();
        using (var stream = assembly.GetManifestResourceStream(timeSource))
        {
            bitmap = SKBitmap.Decode(stream);
        }
        return bitmap;
    }

    private List<SKBitmap> GetRhythmImages()
    {
        var result = new List<SKBitmap>();
        var assembly = Assembly.GetExecutingAssembly();
        foreach (string note in _notes)
        {
            string path = $"RhythmApi.src.{note}.jpg";
            using var stream = assembly.GetManifestResourceStream(path);
            var item = SKBitmap.Decode(stream);
            result.Add(item);
        }
        return result;
    }
}
