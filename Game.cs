// The game itself: the main menu and the map.
// Add new locations by creating a class in Locations/ and placing it in the map.

class Game : Interactive
{
    public override string Name => "Jane the Ripper";

    public override string[] Description => ["Ett mord på Kullahalvön. Kullamannen? Eller något värre?"];

    public override string[] Actions => [
        "Start game:Start",
        "Help:Help"
    ];

    protected override string ExitLabel => "Quit";

    public void Start()
    {
        // Everything is created fresh, so a new game starts from scratch:
        // new locations (their state is reset) and an empty inventory.
        Player.Inventory.Clear();

        // Row 0 is north, column 0 is west. null = nothing there.
         World world = new([
            [new Park(), new Castle(),    new CastleLibrary(), ],
            [null,       null,            null,                ],
            [null,       null,            null,                ],
        ], 0, 0); // start: col 0, row 0 = Park
    }

    public void Help()
    {
        Console.WriteLine("Pick a number and press Enter. 0 always takes you back.");
        Console.ReadLine();
    }
}
