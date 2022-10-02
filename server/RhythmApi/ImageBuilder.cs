using System.Drawing;

namespace RhythmApi;

public class ImageBuilder
{
    private readonly string[] _notes;

    public ImageBuilder(string[] notes)
    {
        _notes = notes;
    }

    public static Bitmap MakeImage(int timeSignature)
    {
        var start = new Bitmap(@"./src/start.jpg");
        var time = new Bitmap(@"./src/" + 
           ((timeSignature == 4)
           ? "44.jpg"
           : "34.jpg"));
        var result = new Bitmap(start.Width + time.Width, Math.Max(start.Height, time.Height));
        
        using (Graphics graphics = Graphics.FromImage(result))
        {
            graphics.DrawImage(start, 0, 0);
            graphics.DrawImage(time, start.Width, 0);
        }

        return result;
    }
}