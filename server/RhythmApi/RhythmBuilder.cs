namespace RhythmApi;

public class RhythmBuilder
{
    private RhythmDesigner _designer;
    private ImageBuilder _imageBuilder;
    private FileSaver _fileSaver;
    
    public RhythmBuilder(RhythmDesigner designer, ImageBuilder imageBuilder, FileSaver fileSaver)
    {
        _designer = designer;
        _imageBuilder = imageBuilder;
        _fileSaver = fileSaver;
    }
    
}