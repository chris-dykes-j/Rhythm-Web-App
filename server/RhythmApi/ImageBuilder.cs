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
        SKBitmap time = new();
        string timeSource = _timeSignature == 4 ? "RhythemApi.src.44.jpg" : "RhythmApi.src.34.jpg";
        var assembly = GetType().GetTypeInfo().Assembly;
        using (var stream = assembly.GetManifestResourceStream(timeSource))
        {
            if (stream != null)
                time = SKBitmap.Decode(stream);
        }
        return time; // test if works
    }
}