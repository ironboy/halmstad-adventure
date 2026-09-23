class SilverCave : Location
{
    private bool _speakerIsOff;
    private bool _knowOfSpeaker;
    private bool _projectorOff;
    public override string Name => "Inne i gråttan";

     public override string[] Description => [
        "Du står inne i gråttan och du ser projektorn som spelar upp ett spöke",
        "Du ser även en ovanligt stort sten och hör spök ljud kommandes där ifrån",
        "Du antar att det är en högtalare och börjar tänka"
        
    ];

    public override string[] Actions => [
       "Kolla på högtalaren",
       _speakerIsOff 
            ? "-Högtalaren är avstängd:SpeakerAlreadyOff"
            : "-Stäng av:TurnOffSpeaker",
        _speakerIsOff
            ? "-Lyssna på tystnaden:LitsenToSilence"
            : "-Bara står där och tänk på livet:JustStandThere",
        "Gå till projektorn",
        _projectorOff
            ? "-Projektorn är avstängd:ProjectorAlreadyOff"
            : "-Stäng av projektorn:TurnOffProjector"
       
    ];

    public void TurnOffSpeaker()
    {
        Console.WriteLine("Högtalaren frågor om en pinkod för att stänga av");
        if(Player.Has("PINKOD"))
        {
            Console.WriteLine("Du anger korrekt pin-kod och musiken tystnar");
            Console.WriteLine("Du ser blodspår på högtalaren så du tar med den som bevis");
            Player.Inventory.Add("Högtalare");
            _speakerIsOff = true;
            Menu.Close();
        }
        else
        {
            Console.WriteLine("Du gissar på din favoritkod 1234 med det fungerar inte.");
        }
        Console.ReadLine();
    }
    public void SpeakerAlreadyOff()
    {
        Console.WriteLine("Inget att se den är avstängd...");
        Console.ReadKey();
    }
    public void TurnOffProjector()
    {
        Console.WriteLine("Du stänger av projektorn. Turisten kankse vågar prata med dig\nDu tar en bild så du kan bevisa att spöket var fake");
        _projectorOff = true;
        Player.Inventory.Add("Bluffbevis");
        Console.ReadKey();
        Menu.Close();
    }
    public void ProjectorAlreadyOff()
    {
        Console.WriteLine($"Inget att se den är avstängd...");
        Console.ReadKey();
    }
    public void LitsenToSilence()
    {
        Console.WriteLine($"Du står still och lyssnar på tystnaden\nDu får ångest så du skiter i det");
        Console.ReadKey();
    }
    public void JustStandThere()
    {
        Console.WriteLine($"Du försöker tänka på ditt liv men ljudet stör dig...");
        Console.ReadKey();
        
    }

}