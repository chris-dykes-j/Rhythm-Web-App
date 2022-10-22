using SkiaSharp;

namespace RhythmApi;

public class RhythmBuilder
{
    private readonly RhythmData _data;
    private readonly RhythmDesigner _designer;
    private readonly ImageBuilder _imageBuilder;
    private readonly FileSaver _fileSaver;

    public RhythmBuilder(RhythmData data)
    {
        _data = data;
        _designer = new RhythmDesigner(_data.TimeSignature, _data.SubDivision, _data.TotalNotes);
        _imageBuilder = new ImageBuilder();
        _fileSaver = new FileSaver();
    }

    public void MakeRhythm()
    {
        var notes = _designer.AssignRhythms();
        var image = _imageBuilder.MakeImage(notes, _data.TimeSignature);
        _fileSaver.SaveImage(image, notes);
    }

    public string GetImagePath() => _fileSaver.GetPath;
    
}