class Hikers : Npc
{
   public override string Name => "Hikers";

   public override string [] Description => [ 
    "De två vandrarna ser stressade ut ."
   ];
public override string[] Actions => [
        "Ask what happened:AskWhatHappend",
        "Ask about the lighthouse:AskAboutLighthouse",
        "Leave:Leave"
    ];
    
     public void AskWhatHappend()
    {
       Console.WriteLine("Eva: Vad har hänt?\n Vandrarna: när vi var vid Nimis o så sprang vår hund iväg han bettede sig lite undligt vill du hjälpa oss att hitta honom?");
       Console.ReadLine();
    }
        





}