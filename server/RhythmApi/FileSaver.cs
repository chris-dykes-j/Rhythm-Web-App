using SkiaSharp;

namespace RhythmApi;

public class FileSaver
{
    private string _filePath = null!;
    
    public void SaveImage(SKImage image, List<string> notes)
    {
        _filePath = MakeFileName(notes, ".png"); 
        using var data = image.Encode(SKEncodedImageFormat.Png, 80);
        using var stream = File.OpenWrite(Path.Combine("./result", _filePath));
        data?.SaveTo(stream);
    }

    private string MakeFileName(List<string> notes, string fileType)
    {
        string result = "";
        notes.ForEach(note => result += note);
        result += fileType;
        return result;
    }
    
    public string GetPath => "./result/" + _filePath;
}