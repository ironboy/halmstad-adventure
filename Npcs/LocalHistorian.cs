// LOCAL HISTORIAN (Hembygdsforskaren) – NPC at the reception in CastleLibrary.
// A weird man in a pointed hat who distrusts the police.
//
// To win him over the commissioner must promise TWO things:
//   1. access to the castle's inner chambers
//   2. that the surveillance cameras are off while he is there
//      (the cameras the player found in the Castle)
//
// Flat menu, no submenus. Actions is re-read every time the menu is drawn,
// so new choices appear by themselves as the bool fields change.
//
// The public fields are read by CastleLibrary – same idea as Castle reading
// _castlemanager.Threatened.

class LocalHistorian : Npc
{
    
    private const string Borrower = "[Gry Nicholsson]";

    private bool _knowsWish;           // he has told you what he wants
    private bool _promisedAccess;      // promise 1: the inner chambers
    private bool _promisedCamerasOff;  // promise 2: cameras off
    private bool _knowsBorrower;

    public bool KnowsAboutAisle5;      // read by CastleLibrary to unlock "Leta i Gång 5"

    // Both promises made = he is on your side
    public bool Persuaded => _promisedAccess && _promisedCamerasOff;

    public override string Name => "Hembygdsforskaren";

    public override string[] Description => [
        Persuaded
            ? "Hembygdsforskaren lutar sig fram över disken. \"Vad vill kommissarien veta?\""
            : "Mannen med den spetsiga hatten blänger på dig. \"Vad gör en polis här?\""
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

            if (Persuaded && !KnowsAboutAisle5)
                actions.Add("Fråga om det finns fler exemplar:AskAboutCopies");

            if (Persuaded && _knowsBorrower && KnowsAboutAisle5)
                actions.Add("Fråga om Kullamannen:AskAboutLegend");

            return actions.ToArray();
        }
    }

    // ---------- Swaying him ----------

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
        KnowsAboutAisle5 = true;
        Console.WriteLine("\"Det finns ett gammalt exemplar till. Gång 5, översta hyllan, längst in.");
        Console.WriteLine("Läs det sista kapitlet – det är där hon hittade vägen.\"");
        Console.ReadLine();
    }

    public void AskAboutLegend()
    {
        Console.WriteLine("\"Kullamannen vaktar berget och havet. Den som förstår hans gåtor");
        Console.WriteLine("hittar vägen. Den som inte förstår... ja.\"");
        Console.ReadLine();
    }
}