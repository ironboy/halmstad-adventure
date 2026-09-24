// Example Npc: has its own menu, remembers what you've said to it.

class OmarSjoberg : Npc
{
    public override string Name => "Omar Sjöberg";

    bool introduction;

    public override string[] Description => [
        "Arbetskollega ifrån Helsingsborg"
    ];

    public override string[] Actions => 
        !introduction
        ? ["Presentera dig för Omar:IntroduceYourself"]
        : ["Bli uppdaterad om fallet:AskAboutCase"];
      
    public void IntroduceYourself()
    {
        introduction = true;
        Console.WriteLine("Hej! Det är jag som är Eva Nylén från Helsingborgspolisen.");
        Console.ReadLine();
    }


    public void AskAboutCase()
    {
        Console.WriteLine("\"Kroppen hittades i Höganäs hamn. Vi åker på en gång.\"");
        Console.ReadLine();
    }
}