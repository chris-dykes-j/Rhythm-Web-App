using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace RhythmApi.Controllers;

[ApiController]
[Route("/")]
public class RhythmController : ControllerBase
{
   [EnableCors("Client")]
   [HttpGet("{time:int}/{div:int}/{notes:int}")]
   public JsonResult Get(int time, int div, int notes)
   {
      var data = new RhythmData(time, div, notes);
      var rhythmBuilder = new RhythmBuilder(data);
      rhythmBuilder.MakeRhythm();
      return new JsonResult(Ok(rhythmBuilder.GetImagePath()));
   }
}