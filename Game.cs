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

    public void Start() // wasnt static or altleast the current code wouldnt let me use static
    {
        // Everything is created fresh, so a new game starts from scratch:
        // new locations (their state is reset) and an empty inventory.
        Player.Inventory.Clear();

        // Row 0 is north, column 0 is west. null = nothing there.
        World world = new([
        [new Forensic(),        null,                  null],
        [new Hoganashamn(),     new PoliceStation(),   null],
        [new Travel(),          null,                  null],
        [new MölleHamn(),       new GrandHotel(),      null],
        [new Ransvik(),         null,                  null],
        [new Path(),            new Josefinelust(),    new SilverCave()],
        [null,                  null,                  null],
        [null,                  null,                  null],
        ], 1, 1);
        // 0,0 = RuneRoom col = 0, row = 0


        world.DevMode = true;   // "DEV: Teleport" in every menu - set to false for the real game
        world.Play();
    }

    public void Help()
    {
        Console.WriteLine("Pick a number and press Enter. 0 always takes you back.");
        Console.ReadLine();
    }
}
