using SkiaSharp;

namespace RhythmApi;

public class FileSaver
{
    private readonly SKImage _image;
    private readonly List<string> _notes;
    
    private readonly string _filePath;
    
    public FileSaver(SKImage image, List<string> notes)
    {
        _image = image;
        _notes = notes;
        _filePath = MakeFileName(".png"); 
    }

    public void SaveImage()
    {
        using var data = _image.Encode(SKEncodedImageFormat.Png, 80);
        using var stream = File.OpenWrite(Path.Combine("./result", _filePath));
        data?.SaveTo(stream);
    }

    private string MakeFileName(string fileType)
    {
        string result = "";
        _notes.ForEach(note =>
        {
            result += note;
        });
        return result;
    }
}