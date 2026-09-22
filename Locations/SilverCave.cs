class SilverCave : Location
{
    private bool _speakerIsOff;
    
    public override string Name => "Inne i gråttan";

     public override string[] Description => [
        "Du står inne i gråttan och du ser projektorn som spelar upp ett spöke",
        "Du ser även en ovanligt stort sten och hör ljud kommandes där ifrån"
    ];

    public override string[] Actions => [
       "Gå mot ljudet:WhatDoISee",
       "Kolla på högtalaren",
       "-Stäng av:TurnOffSpeaker",
       "-Headbanga:Headbang",
       "Gå till projektorn",
       "-Stäng av projektorn:TurnOffProjector",
    ];

    public void Headbang()
    {
        Console.WriteLine("Du headbanger till den coola Sven-Ingvars-musiken...");
        Console.ReadLine();
    }

    public void TurnOffSpeaker()
    {
        Console.WriteLine("Högtalaren frågor om en pinkod för att stänga av");
        if(Player.Has("Papper med pinkod"))
        {
            Console.WriteLine("Du anger korrekt pin-kod och musiken tystnar");
            _speakerIsOff = true;
        }
        else
        {
            Console.WriteLine("Du gissar på din favoritkod 1234 med det fungerar inte.");
        }
        Console.ReadLine();
    }
    public void TurnOffProjector()
    {
        Console.WriteLine("Du stänger av projektorn. Turisten kankse vågar prata med dig\nDu tar en bild så du kan bevisa att spöket var fake");
        Player.Inventory.Add("Bluffbevis");
        Console.ReadKey();
    }
    public void WhatDoISee()
    {
        Console.WriteLine($"Du ser en högtalare bakom stenen");
        Console.ReadKey();
    }
}