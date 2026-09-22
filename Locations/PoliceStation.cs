// Example location with a submenu (the "-" lines) and an item that disappears.
// The key goes into Player.Inventory so other locations can check for it.

class PoliceStation : Location
{   
    private readonly OmarSjöberg _omarSjöberg = new();
     private bool _talkedToOmar;

    public override string Name => "Polisstationen i Höganäs";

    public override string[] Description => [
        "Du kliver in på den lilla polisstationen.",
        _talkedToOmar ? "Du har redan pratat med Omar" : "Kriminalinspektör Omar Sjöberg, hälsar dig välkommen med en nick.",
        "'Jag förstår inte varför de skickat dig men jag antar att jag får hälsa dig välkommen.'"
    ];

    public override string[] Actions => [
        "Se dig runt:LookAround",
        "Prata med kriminalinspektören:TalkToOmarSjöberg"
    ];

    public void TalkToOmarSjöberg()
    {
        Console.WriteLine(_talkedToOmar
            ? "Ska vi åka då?"
            : "Kroppen hittades i Höganäs hamn, vi kör på en gång.");
        _talkedToOmar = true;
        Console.ReadLine();
    }

    public void LookAround()
    {
        Console.WriteLine("Du ser dig omkring och ser ett par små kontor. Till höger ligger ett litet personalrum där använda kaffekoppar hopar sig i diskhon.");
    }

    // An item that opens ANOTHER object's menu: just call its Run()
    public void TalkToGuard() => _guard.Run();

    // Prevent going east until the guard is bribed
    public override void East()
    {
        if (!_guard.Bribed)
        {
            Console.WriteLine("The guard steps in front of you \"Not today\"");
            Console.ReadLine();
        }
        else
        {
            // call the super class ("base") East method (in Location)
            base.East();
        }
    }
}
