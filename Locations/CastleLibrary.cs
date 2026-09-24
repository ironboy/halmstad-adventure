// CASTLE LIBRARY (Slottsbiblioteket) – the whole library in one location.
// The Reception and Aisle 5 are parts of this room, not separate locations.
// The player meets the librarian directly: she is part of the description,
// and the conversation is plain actions in the room's own menu (no NPC, no submenus).
//
// Progress is kept in bool fields. Actions is re-read every time the menu is drawn,
// so new choices appear by themselves as the fields change.

class CastleLibrary : Location
{
    // REPLACE with the name your group decided the murderer borrowed the book under.
    private const string Borrower = "[Gry Nikolai]";

    private bool _askedAboutBook;
    private bool _knowsBorrower;
    private bool _knowsAboutAisle5;
    private bool _bookFound;
    private bool _riddleRead;

    public override string Name => "Slottsbiblioteket";

    public override string[] Description => [
        "Höga valv, dammig luft och hyllor så långt ögat når.",
        _askedAboutBook
            ? "Bibliotekarien står kvar vid receptionsdisken och väntar på dina frågor."
            : "Vid receptionsdisken tittar bibliotekarien upp över glasögonen. \"Kan jag hjälpa kommissarien?\"",
        _bookFound
            ? "Boken om Kullamannen ligger uppslagen framför dig."
            : "Längst in skymtar Gång 5, där de äldsta böckerna står."
    ];

    public override string[] Actions
    {
        get
        {
            List<string> actions = [];

            if (!_askedAboutBook)
                actions.Add("Fråga om boken om Kullamannen:AskAboutBook");

            if (_askedAboutBook && !_knowsBorrower)
                actions.Add("Visa polisbrickan och fråga vem som lånade boken:ShowBadge");

            if (_askedAboutBook && !_knowsAboutAisle5)
                actions.Add("Fråga om det finns fler exemplar:AskAboutCopies");

            if (_knowsAboutAisle5 && !_bookFound)
                actions.Add("Leta i Gång 5:SearchAisle5");

            if (_bookFound)
                actions.Add("Läs sista kapitlet:ReadRiddle");

            return actions.ToArray();
        }
    }

    public void AskAboutBook()
    {
        _askedAboutBook = true;
        Console.WriteLine("Hon bläddrar i utlåningsliggaren och stannar upp.");
        Console.WriteLine("\"Boken om Kullamannen lånades ut i morse. Ingen har rört den på flera år.\"");
        Console.ReadLine();
    }

    public void ShowBadge()
    {
        _knowsBorrower = true;
        Player.Inventory.Add("lånekortets namn");
        Console.WriteLine("Du lägger polisbrickan på disken. Hon tvekar, sedan vänder hon på lånekortet.");
        Console.WriteLine($"\"{Borrower}. En kvinna med jackan knäppt ända upp.");
        Console.WriteLine("Hon gömde boken under jackan när hon gick.\"");
        Console.ReadLine();
    }

    public void AskAboutCopies()
    {
        _knowsAboutAisle5 = true;
        Console.WriteLine("\"Det finns ett gammalt exemplar till. Gång 5, översta hyllan, längst in.\"");
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