using Microsoft.AspNetCore.Mvc;
using SkiaSharp;

namespace RhythmApi.Controllers;

[ApiController]
[Route("/{time:int}/{div:int}/{notes:int}")]
public class RhythmController : ControllerBase
{
   public SKImage Get(int time, int div, int notes)
   {
        var blueprint = new RhythmDesigner(4, 4, 10);
        var beats = blueprint.AssignRhythms();
        var imgBuilder = new ImageBuilder(beats, 4);
        var result = imgBuilder.MakeImage();
        return result;
   } 
}