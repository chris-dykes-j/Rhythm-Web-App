namespace RhythmApi;

public class RhythmDesigner
{
   private readonly int _timeSignature;
   private readonly int _subDivision;
   private int _totalNotes;
   
   private readonly Random _random = new Random();
   
   public RhythmDesigner(int timeSignature, int subDivision, int totalNotes)
   {
      _timeSignature = timeSignature;
      _subDivision = subDivision;
      _totalNotes = totalNotes;
   }
   
   // Creates the rhythm, as a list of numbers.
   private int[] AssignNotePlacement()
   {
      int[] measure = new int[_timeSignature];
      var options = MakeOptionList(_timeSignature);
      while (_totalNotes > 0)
      {
         int index = _random.Next(0, options.Count);
         int choice = options[index];
         if (measure[choice] == _subDivision)
            options.RemoveAt(index);
         else
         {
            measure[choice]++;
            _totalNotes--;
         }
      }
      return  measure;
   }

   // Making the rhythm choice here as a sequence of ones and zeros.
   // i.e. 1010 is two eighth notes, 0010 is an eight rest and note, etc.
   public List<string> AssignRhythms()
   {
      int[] measure = AssignNotePlacement();
      List<string> result = new();
      foreach (int notes in measure)
      {
         List<char> beat = new();
         for (int i = 0; i < notes; i++)
            beat.Add('1');
         while (beat.Count < _subDivision)
            beat.Add('0');
         var item = string.Join("", beat.OrderBy(c => _random.Next()));
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