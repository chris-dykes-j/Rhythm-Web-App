namespace RhythmApi;

// Needs changed. Should now assign an image given a number sequence (string)
public class RhythmSelector
{
   private readonly int[] _bar;
   private readonly int _subDivision;

   public RhythmSelector(int[] bar, int subDivision)
   {
      _bar = bar;
      _subDivision = subDivision;
   }

   public List<string> MakeBeat()
   {
      List<string> beats = new();

      foreach (int notes in _bar)
      {
         string choice = notes switch
         {
            1 => ChooseOne(),
            2 => ChooseTwo(),
            3 => ChooseThree(),
            4 => ChooseFour(),
            _ => ChooseRest()
         };
         beats.Add(choice);
      }
      
      return beats;
   }
   
   // These methods are too repetitive, but this is the idea.
   private string ChooseTwo()
   {
      Random random = new();
      int choice = random.Next(0, 5);
      return choice switch
      {
         1 => "DottedEighth, Sixteenth",
         2 => "EightRest, TwoSixteenths",
         _ => "TwoEights" // Goes on and on
      };
   }

   private string ChooseOne()
   {
      Random random = new();
      int choice = random.Next(0, 1);
      return choice switch
      {
         1 => "EighthRest, EightNote",
         _ => "QuarterNote"
      };
   }

   private string ChooseRest()
   {
      return "Rest";
   }
  
  // Note implementing these for now.
  private string ChooseFour()
  {
     return "Cool";
  }

   private string ChooseThree()
   {
      return "CoolBro";
   }
}