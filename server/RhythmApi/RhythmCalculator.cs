namespace RhythmApi;

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
      var options = MakeOptions(_timeSignature);
      var random = new Random();
      
      for (int k = _totalNotes; k > 0; k--)
      {
         int i;
         try
         {
            i = options[random.Next(0, options.Count - 1)];
         }
         catch (ArgumentOutOfRangeException e)
         {
            i = 0;
         }

         Console.WriteLine($"Options length: {options.Count-1}, i: {i}");
         if (bar[options[i]] == _subDivision)
            options.Remove(i);
         else
            bar[options[i]]++;
      }
      return bar;
   }

   private static List<int> MakeOptions(int length)
   {
      var options = new List<int>();
      for (int i = 0; i < length; i++)
         options.Add(i);
      return options;
   }
}