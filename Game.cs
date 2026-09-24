// The game itself: the main menu and the map.
// Add new locations by creating a class in Locations/ and placing it in the map.

class Game : Interactive
{
    public override string Name => "Jane the Ripper";

    public override string[] Description => ["Ett mord på Kullahalvön. Kullamannen? Eller något värre?"];

    public override string[] Actions => [
        "Starta spel:Start",
        "Hjälp:Help"
    ];

    protected override string ExitLabel => "Avsluta spelet";

    public void Start()
    {
        Player.Inventory.Clear();

        // Row 0 is north, column 0 is west. null = nothing there.
        World world = new([
            [new Gang5(), new Slottsbiblioteket(), new Reception()],
            [null,        new Kallare(),           null           ],
        ], 1, 0); // start: col 1, row 0 = Slottsbiblioteket

        world.Play();
    }

    public void Help()
    {
        Console.WriteLine("Välj ett nummer och tryck Enter. 0 tar dig alltid tillbaka.");
        Console.ReadLine();
    }
}