// CASTLE LIBRARY (Slottsbiblioteket) – the whole library in one location.
// The Reception and Aisle 5 are parts of this room, not separate locations.
// The player meets the local historian (hembygdsforskaren) directly: he is part of
// the description, and the conversation is plain actions in the room's menu
// (no NPC class, no submenus).
//
// To win him over the commissioner must promise TWO things:
//   1. access to the castle's inner chambers
//   2. that the surveillance cameras are off while he is there
// (the cameras the player found in the Castle).
//
// Actions is re-read every time the menu is drawn, so new choices
// appear by themselves as the bool fields change.

class CastleLibrary : Location
{
    // REPLACE with the name your group decided the murderer borrowed the book under.
    private const string Borrower = "[Gry Nicholsson]";

    private bool _knowsWish;           // he has told you what he wants
    private bool _promisedAccess;      // promise 1: the inner chambers
    private bool _promisedCamerasOff;  // promise 2: cameras off → he cooperates
    private bool _knowsBorrower;
    private bool _knowsAboutAisle5;
    private bool _bookFound;
    private bool _riddleRead;

    // Both promises made = he is on your side
    private bool Persuaded => _promisedAccess && _promisedCamerasOff;

    public override string Name => "Slottsbiblioteket";

    public override string[] Description => [
        "Höga valv, dammig luft och hyllor så långt ögat når.",
        Persuaded
            ? "Hembygdsforskaren lutar sig fram över receptionsdisken. \"Vad vill kommissarien veta?\""
            : "Bakom receptionsdisken sitter en skum man med spetsig hatt. \"Vad gör en polis här?\"",
        _bookFound
            ? "Boken om Kullamannen ligger uppslagen framför dig."
            : "Längst in skymtar Gång 5, där de äldsta böckerna står."
    ];

    public override string[] Actions
    {
        get
        {
            List<string> actions = [];

            // Before he is persuaded
            if (!_knowsWish)
                actions.Add("Fråga om boken om Kullamannen:AskAboutBook");

            if (_knowsWish && !_promisedAccess)
                actions.Add("Lova honom tillträde till slottets innersta rum:PromiseAccess");

            if (_promisedAccess && !_promisedCamerasOff)
                actions.Add("Lova att kamerorna är avstängda när han är där:PromiseCamerasOff");

            // After he is persuaded
            if (Persuaded && !_knowsBorrower)
                actions.Add("Fråga vem som lånade boken:AskWhoBorrowed");

            if (Persuaded && !_knowsAboutAisle5)
                actions.Add("Fråga om det finns fler exemplar:AskAboutCopies");

            if (_knowsAboutAisle5 && !_bookFound)
                actions.Add("Leta i Gång 5:SearchAisle5");

            if (_bookFound)
                actions.Add("Läs sista kapitlet:ReadRiddle");

            return actions.ToArray();
        }
    }

    // ---------- Swaying the historian ----------

    public void AskAboutBook()
    {
        _knowsWish = true;
        Console.WriteLine("\"Böcker ger jag inte ut till poliser.\" Han muttrar vidare för sig själv:");
        Console.WriteLine("\"Trettio år har jag bett att få se slottets innersta rum. Trettio år av nej.");
        Console.WriteLine("Och förvaltaren med sina kameror... han ser allt.\"");
        Console.ReadLine();
    }

    public void PromiseAccess()
    {
        _promisedAccess = true;
        Console.WriteLine("\"Förvaltaren gör som polisen säger. Ett ord från mig, så öppnas kamrarna.\"");
        Console.WriteLine("Han tittar upp. \"Och kamerorna? Jag vill inte att någon ser mig där inne.\"");
        Console.ReadLine();
    }

    public void PromiseCamerasOff()
    {
        _promisedCamerasOff = true;
        Console.WriteLine("\"Kamerorna står stilla när du är där. Det ordnar jag.\"");
        Console.WriteLine("Han tar av sig hatten. Händerna darrar. \"Då har vi en överenskommelse, kommissarien.\"");
        Console.ReadLine();
    }

    // ---------- Once persuaded ----------

    public void AskWhoBorrowed()
    {
        _knowsBorrower = true;
        Player.Inventory.Add("lånekortets namn");
        Console.WriteLine("Han vänder på lånekortet i liggaren.");
        Console.WriteLine($"\"{Borrower}. En kvinna med jackan knäppt ända upp.");
        Console.WriteLine("Hon trodde inte på sägnen. Hon använde den. Och hon gömde boken under jackan.\"");
        Console.ReadLine();
    }

    public void AskAboutCopies()
    {
        _knowsAboutAisle5 = true;
        Console.WriteLine("\"Det finns ett gammalt exemplar till. Gång 5, översta hyllan, längst in.");
        Console.WriteLine("Läs det sista kapitlet – det är där hon hittade vägen.\"");
        Console.ReadLine();
    }

    public void SearchAisle5()
    {
        _bookFound = true;
        Console.WriteLine("Du går in i Gång 5. Längst in på översta hyllan: ett slitet exemplar av boken!");
        Console.ReadLine();
    }

    public void ReadRiddle()
    {
        Console.WriteLine("Någon har strukit under en rad med blyerts:");
        Console.WriteLine();
        Console.WriteLine("  \"Där berget möter havet vakar ett öga som aldrig sover.");
        Console.WriteLine("   Det vaknar när solen somnar. Sök mig där ljuset vandrar.\"");
        Console.WriteLine();
        if (!_riddleRead)
        {
            Player.Inventory.Add("gåtan om fyren");   // the next group's location can check this
            _riddleRead = true;
        }
        Console.ReadLine();
    }
}