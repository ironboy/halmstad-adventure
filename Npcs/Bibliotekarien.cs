// 2a. BIBLIOTEKARIEN – NPC i receptionen.
//
// Dialogen låses upp steg för steg med tre bool-fält:
//   _askedAboutBook   → frågar du om boken öppnas nya frågor
//   _knowsBorrower    → har du visat polisbrickan får du namnet
//   _knowsSecondCopy  → hon berättar om exemplaret i Gång 5 och forskaren
//
// "Vem lånade boken?" är en UNDERMENY (raderna som börjar med "-"),
// precis som "Search the fountain" i Courtyard.

class Bibliotekarien : Npc
{
    // BYT UT mot det namn som er grupp bestämt att mördaren lånade boken i.
    private const string Borrower = "[Gry Nicholsson]";

    private bool _askedAboutBook;
    private bool _knowsBorrower;
    private bool _knowsSecondCopy;

    public override string Name => "Bibliotekarien";

    public override string[] Description => [
        _knowsBorrower
            ? "Bibliotekarien håller lånekortet hårt. Hon ser orolig ut nu."
            : "Bibliotekarien tittar upp över glasögonen. \"Kan jag hjälpa kommissarien med något?\""
    ];

    public override string[] Actions
    {
        get
        {
            // Steg 1: bara grundfrågor
            if (!_askedAboutBook)
                return ["Fråga om biblioteket:AskAboutLibrary",
                        "Fråga om boken om Kullamannen:AskAboutBook"];

            // Steg 2 och 3: vi bygger listan bit för bit
            List<string> actions = ["Fråga om biblioteket:AskAboutLibrary"];

            if (_knowsBorrower)
                actions.Add("Berätta mer om kvinnan:AskAboutWoman");
            else
                actions.AddRange(["Vem lånade boken?",                  // rubrik för undermenyn
                                  "-Visa polisbrickan:ShowBadge",
                                  "-Släpp det för tillfället:DropIt"]);

            if (!_knowsSecondCopy)
                actions.Add("Finns det fler exemplar?:AskAboutCopies");
            else
                actions.Add("Vem är hembygdsforskaren?:AskAboutForskaren");

            return actions.ToArray();
        }
    }

    // ---------- Steg 1 ----------

    public void AskAboutLibrary()
    {
        Console.WriteLine("\"Slottsbiblioteket har funnits i över trehundra år. Det mesta står här uppe,");
        Console.WriteLine("men de äldsta samlingarna förvaras nere i källaren.\"");
        Console.ReadLine();
    }

    public void AskAboutBook()
    {
        _askedAboutBook = true;
        Console.WriteLine("Hon bläddrar i utlåningsliggaren och stannar upp.");
        Console.WriteLine("\"Boken om Kullamannen... oj... den lånades ut i morse. Konstigt, ingen har");
        Console.WriteLine("rört den på flera år, och så plötsligt i dag.\"");
        Console.ReadLine();
        Menu.Close();   // nya frågor har låsts upp – rita om menyn
    }

    // ---------- Steg 2: vem lånade boken? ----------

    public void ShowBadge()
    {
        _knowsBorrower = true;
        Player.Inventory.Add("lånekortets namn");   // andra rum kan kolla detta med Player.Has(...)
        Console.WriteLine("Du lägger polisbrickan på disken. Hon tvekar, sedan vänder hon på lånekortet.");
        Console.WriteLine($"\"{Borrower}. En kvinna. Hon kom inspringande, andfådd, med jackan knäppt");
        Console.WriteLine("ända upp. Hon skrev under utan att ens ta av sig handskarna.\"");
        Console.ReadLine();
        Menu.Close();   // stänger undermenyn – "Vem lånade boken?" byts ut
    }

    public void DropIt()
    {
        Console.WriteLine("\"Lånesekretess och GDPR, kommissarien. Det förstår ni säkert!\"");
        Console.WriteLine("Hon ser ut att kunna ge med sig... om du visar vem du är.");
        Console.ReadLine();
    }

    public void AskAboutWoman()
    {
        Console.WriteLine("\"Hon frågade inte efter boken – hon visste exakt var den stod.");
        Console.WriteLine("Och hon höll den under jackan när hon gick, som om någon inte fick se den.\"");
        Console.ReadLine();
    }

    // ---------- Steg 3: vägen till källaren och Gång 5 ----------

    public void AskAboutCopies()
    {
        _knowsSecondCopy = true;
        Console.WriteLine("\"Det finns ett andra exemplar, ett gammalt. Det står i Gång 5,");
        Console.WriteLine("men den gången är avspärrad. Bara hembygdsforskaren vet exakt var det står –");
        Console.WriteLine("han sitter nere i källaren, söderut från entrén.\"");
        Console.ReadLine();
        Menu.Close();
    }

    public void AskAboutForskaren()
    {
        Console.WriteLine("\"En egen typ. Tror på varenda sägen om Kullamannen. Poliser tycker han inte om...\"");
        Console.WriteLine("Hon sänker rösten. \"...men han har tjatat i trettio år om att få komma in");
        Console.WriteLine("i slottets stängda kamrar. Förvaltaren säger alltid nej.\"");
        Console.ReadLine();
    }
}