class Hikers : Npc
{
   public override string Name => "Hikers";

   public override string [] Description => [ 
    "De två vandrarna ser stressade ut ."
   ];
public override string[] Actions => [
        "Ask what happened:AskWhatHappend",
        "Leave:Leave"
    ];
    
     public void AskWhatHappend()
    {
       Console.WriteLine("Eva: Vad har hänt?");
       Console.WriteLine("Vandrarna: När vi var vid Nimis o så sprang vår hund iväg. Han bettede sig lite undligt vill du hjälpa oss att hitta honom?");
       Console.ReadLine();
    }
        





}