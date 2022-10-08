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

    // Test with the time signature to start.
    public SKBitmap MakeImage()
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
}