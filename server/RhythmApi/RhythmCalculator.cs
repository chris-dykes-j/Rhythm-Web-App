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
   public int[] CalculateRhythm()
   {
      int[] bar = new int[_timeSignature];
      List<int> options = MakeOptions(_timeSignature);
      Random random = new();
      
      while (_totalNotes > 0) 
      {
         int index = random.Next(0, options.Count);
         int choice = options[index];
         if (bar[choice] == _subDivision)
            options.RemoveAt(index);
         else
         {
            bar[choice]++;
            _totalNotes--;
         }
      }
      return bar;
   }

   // Creates the list of options, the options being which index to add one.
   private static List<int> MakeOptions(int length)
   {
      List<int> options = new();
      for (int i = 0; i < length; i++)
         options.Add(i);
      return options;
   }
}