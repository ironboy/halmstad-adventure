class Hikers : Npc
{
   private bool _talkedToHikers;
   public override string Name => "Hikers";

   public override string [] Description => [ 
    "De två vandrarna ser stressade ut ."
   ];
public override string[] Actions => [
        "Fråga vad som hänt:AskWhatHappend"
       
    ];

    public bool TalkedToHikers { get => _talkedToHikers; set => _talkedToHikers = value; }

    public void AskWhatHappend()
    {
       Console.WriteLine("Eva: Vad har hänt?");
       Console.WriteLine("Vandrarna: När vi var vid Nimis o så sprang vår hund iväg. Han bettede sig lite undligt vill du hjälpa oss att hitta honom?");
       
        Console.WriteLine("Eva: Hur ser hunden ut och vet ni vart den tog vägen?");
        Console.WriteLine("Vandrarna: Det är en liten brun och svart hund med stora öron! Den blev skrämd och sprang ner mot Klippstranden.");
        Console.WriteLine("Eva: Jag går ner till Klippstranden och kollar om den är kvar där.");
       // Console.WriteLine("\n[Ny plats upplåst: Du kan nu gå till Klippstranden!]");
        Console.WriteLine("\nTryck Enter för att fortsätta...");
        Console.ReadLine();
        _talkedToHikers = true;
        Menu.Close();
    }
        
}