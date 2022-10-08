using System.Reflection;
using SkiaSharp;

namespace RhythmApi;

public class ImageBuilder
{
    private readonly List<string> _notes;
    private readonly int _timeSignature;
    
    public ImageBuilder(List<string> notes, int timeSignature)
    {
        _notes = notes;
        _timeSignature = timeSignature;
    }

    public SKBitmap MakeImage()
    {
        SKBitmap result;
        var start = MakeTimeSignature();
        var rhythms = GetRhythmImages();

        int width = start.Width; // Width of the entire measure
        rhythms.ForEach(r => width += r.Width);
        
        result = new SKBitmap(width, rhythms[0].Height);
        using (var canvas = new SKCanvas(result))
        {
            canvas.DrawBitmap(start, 0, 0);
            // Nested for loop is never nice...
            rhythms.ForEach(rhythm =>
            {
                for (float x = start.Width; x < width; x += rhythm.Width)
                {
                    canvas.DrawBitmap(rhythm, x, 0);
                }    
            });
        }
        return result;
    }
    
    private SKBitmap MakeTimeSignature()
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
        var list = new List<SKBitmap>(); 
        var assembly = Assembly.GetExecutingAssembly();
        var options = assembly.GetManifestResourceNames().ToList();
        
        // This has lots of problems.
        foreach (string option in options)
        {
            string image = option.Replace("RhythmApi.src.", "").Replace(".jpg", "");
            if (_notes.Contains(image))
            {
                using var stream = assembly.GetManifestResourceStream(option); 
                list.Add(SKBitmap.Decode(stream));
            }
        }
        return list;
    }
}