namespace RhythmApi;

public class RhythmData
{
   public readonly int TimeSignature;
   public readonly int SubDivision;
   public readonly int TotalNotes;

   public RhythmData(int timeSignature, int subDivision, int totalNotes)
   {
      TimeSignature = timeSignature;
      SubDivision = subDivision;
      TotalNotes = totalNotes;
   }
}