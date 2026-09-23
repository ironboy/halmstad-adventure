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

    //public void Start()
   // {
        // Everything is created fresh, so a new game starts from scratch:
        // new locations (their state is reset) and an empty inventory.
      //  Player.Inventory.Clear();
            /*
        // Row 0 is north, column 0 is west. null = nothing there.
        World world = new([
            [new RuneRoom(), new Hallway()],
            [null,           new Courtyard()],                ////DEN GAMLA - ska tas bort, bara här för att jämföra
            [null,           new Gate()],
        ], 0, 0); // 0,0 = RuneRoom col = 0, row = 0 
            ////
        
        World world = new([
            [new Nimis(), new Himmelstorp()],           /////DEN VI SKA HA NÄR ALLT ÄR KLART
            [null, new Klippstranden()],
        ], 0, 0);

        */
        // Tillfällig testkarta med BARA din location:              ////LISETTES TEST, ändra till eget location för test av egen kod.
       /* World world = new([
        [ new Klippstranden() ]
        ], 0, 0);
        */

       /* World world = new([       ///Darias test
        [ new Nimis() ]
        ], 0, 0);*/
        public void Start()
    {
        Console.Clear();

        // Nollställer spelarens inventory vid nytt spel
        Player.Inventory.Clear();

        // Världens rutnät (2D-array):
        // Rad 0, Kolumn 0 = Nimis (Startpunkt)
        // Rad 0, Kolumn 1 = Himmelstorp (Öster om Nimis)
        // Rad 1, Kolumn 1 = Klippstranden (Söder om Himmelstorp)
        World world = new([
            [ new Nimis(),         new Himmelstorp() ],
            [ null,               new Klippstranden() ]
        ], 0, 0); // (rad 0, kolumn 0) startar spelaren på Nimis
        world.Play();
    }

    public void Help()
    {
        Console.WriteLine("Pick a number and press Enter. 0 always takes you back.");
        Console.ReadLine();
    }
}
