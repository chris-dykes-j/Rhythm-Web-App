namespace RhythmApi.Controllers;

public class RhythmCalculator
{
   private readonly int _timeSignature;
   private readonly int _subDivision;
   private int _totalNotes;
   public RhythmCalculator(int timeSignature, int subDivision, int totalNotes)
   {
      _timeSignature = timeSignature;
      _subDivision = subDivision;
      _totalNotes = totalNotes;
   }

   // Creates the rhythm, as a list of numbers.
   public IEnumerable<int> CalculateRhythm()
   {
      var bar = new int[_timeSignature];
      var random = new Random();
      // I could use a nicer algorithm...
      while (_totalNotes > 0)
      {
         var i = random.Next(_timeSignature);
         if (bar[i] >= _subDivision) continue;
         bar[i]++;
         _totalNotes--;
      }
      return bar;
   }
}