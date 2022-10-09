using Microsoft.AspNetCore.Mvc;
using SkiaSharp;

namespace RhythmApi.Controllers;

[ApiController]
[Route("[controller]")]
public class RhythmController : ControllerBase
{
    [HttpGet]
    public IActionResult<SKBitmap> Create(SKBitmap result)
    {
        var blueprint = new RhythmDesigner(4, 4, 2);
        var beats = blueprint.AssignRhythms();
        var imgBuilder = new ImageBuilder(beats, 4);
        var result = imgBuilder.MakeImage();
        return result;
    }
}