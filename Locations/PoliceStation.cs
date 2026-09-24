// Example location with a submenu (the "-" lines) and an item that disappears.
// The key goes into Player.Inventory so other locations can check for it.

class PoliceStation : Location
{   
    private readonly OmarSjoberg _omarSjoberg = new();
     private bool _talkedToOmar;

    public override string Name => "Polisstationen i Höganäs";

    public override string[] Description => [
        _talkedToOmar 
        ? "Du kliver in på den lilla polisstationen." :
        "Kriminalinspektör Omar Sjöberg, hälsar dig välkommen med en nick.\n\"Jag förstår inte varför de skickat dig men jag antar att jag får hälsa dig välkommen.\""
    ];

    public override string[] Actions => [
        "Se dig omkring:LookAround",
        "Prata med kriminalinspektören:TalkToOmarSjöberg"
    ];

    public void TalkToOmarSjöberg()
    {
        _omarSjoberg.Run();
    }

    public void LookAround()
    {
        Console.WriteLine("Du ser dig omkring och ser ett par små kontor. Till höger ligger ett litet personalrum där använda kaffekoppar hopar sig i diskhon.");
        Console.ReadLine();
    }
}

