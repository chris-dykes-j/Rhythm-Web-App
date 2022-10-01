namespace RhythmApi;

public class RhythmCalculator
{
   private readonly int _timeSignature;
   private readonly int _subDivision;
   private int _totalNotes;
   
   private readonly Random _random = new Random();
   
   public RhythmCalculator(int timeSignature, int subDivision, int totalNotes)
   {
      _timeSignature = timeSignature;
      _subDivision = subDivision;
      _totalNotes = totalNotes;
   }
   
   // Creates the rhythm, as a list of numbers.
   private int[] AssignNotePlacement()
   {
      int[] bar = new int[_timeSignature];
      List<int> options = MakeOptionList(_timeSignature);
      
      while (_totalNotes > 0) 
      {
         int index = _random.Next(0, options.Count);
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

   // Making the rhythm choice here as a sequence of ones and zeros.
   // i.e. 1010 is two eighth notes, 0010 is an eight rest and note, etc.
   public List<string> AssignRhythms()
   {
      int[] bar = AssignNotePlacement();
      List<string> result = new();
      
      foreach (int notes in bar)
      {
         List<char> beat = new();
         for (int i = 0; i < notes; i++)
            beat.Add('1');
         while (beat.Count < _subDivision)
            beat.Add('0');
         var item = String.Join("", beat.OrderBy(c => _random.Next()));
         result.Add(item); 
      }
      
      return result;
   }
   
   // Creates the list of options, the options being which index to add one.
   private static List<int> MakeOptionList(int length)
   {
      List<int> options = new();
      for (int i = 0; i < length; i++)
         options.Add(i);
      return options;
   }
}