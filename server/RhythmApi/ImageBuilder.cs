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
    public SKImage MakeImage()
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
        return SKImage.FromBitmap(result);
    }
    
    // Gets the time signature image
    private SKBitmap GetTimeSignature()
    {
        var bitmap = new SKBitmap();
        string timeSource = _timeSignature == 4 ? "RhythmApi.src.44.jpg" : "RhythmApi.src.34.jpg";
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