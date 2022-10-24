using Microsoft.AspNetCore.Mvc;

namespace RhythmApi.Controllers;

[ApiController]
[Route("/")]
public class RhythmController : ControllerBase
{
   [HttpGet("{time:int}/{div:int}/{notes:int}")]
   public string Get(int time, int div, int notes)
   {
      var data = new RhythmData(time, div, notes);
      var rhythmBuilder = new RhythmBuilder(data);
      rhythmBuilder.MakeRhythm();
      return rhythmBuilder.GetImagePath();
   } 
}