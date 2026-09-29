/*
class Jane : Npc
{
    public override string Name => "Jane Doe";
 
    public override string[] Description => [
        "En mystisk person som står vid fyren.",
        "Hon verkar ha något viktigt att berätta."
    ];
 
    public override string[] Actions => [
        "Konfrontera Jane Doe:Confront"
    ];
 
    static readonly (string Item, string Menu, string EvaSays, string JaneReacts, string Hint)[] Evidence =
    {
        ("obduktionsrapport",
         "Lägg fram obduktionsrapporten",
         "Trollklorna är gjorda med en kirurgkniv. Samma snitt som i Whitechapel 1888.",
         "Jane rycker till. \"Rättsläkare... alltid detaljerna. Jag var noga med trollspåren.\"",
         "Rättsläkaren vet mer om såren än hon har berättat."),
 
        ("signalement",
         "Visa signalementet från hotelliggaren",
         "Du checkade in på Grand Hôtel under falskt namn kvällen före mordet.",
         "Jane ler kallt. \"Ett hotellrum är inget bevis. Men fortsätt, kommissarien.\"",
         "Någon på Grand Hôtel kanske minns vem som checkade in."),
 
        ("högtalare",
         "Visa högtalaren från grottan",
         "Kullamannens vrål kom ur en högtalare. Berget har aldrig vaknat.",
         "\"Bra ljudkvalitet, eller hur?\" säger Jane. Hennes röst är ansträngd.",
         "Vrålet från grottan lät nästan för tydligt. Gå tillbaka och lyssna."),
 
        ("skiss",
         "Visa konstnärens skiss",
         "Konstnären ritade en kvinna på piren i Arild. Det är ditt ansikte.",
         "Jane ser på skissen. Leendet försvinner. \"Han skulle aldrig ha ritat.\"",
         "Konstnären i Arild ritar alla som går förbi piren."),
 
        ("lånekort",
         "Visa lånekortet från slottsbiblioteket",
         "Du lånade boken om Kullamannen. Ditt namn står på kortet.",
         "\"Jag hade tänkt lämna tillbaka den\", viskar Jane och skrattar till.",
         "Någon har lånat boken om Kullamannen på slottsbiblioteket."),
 
        ("dagbokssida",
         "Läs upp dagbokssidan",
         "\"Jag hör dem fortfarande. Berget svarar när jag dödar.\" Du skrev det själv.",
         "Jane blir alldeles stilla. \"Var hittade du den? Den skulle vara borta.\"",
         "Jane skriver ner allt. Någonstans finns en sida hon inte hann bli av med."),
    };
 
    public void Confront()
    {
        Console.WriteLine("Du tar ett djupt andetag och börjar lägga fram bevisen.");
        Console.ReadLine();
 
        foreach (var e in Evidence)
        {
            if (!Player.Has(e.Item))
            {
                Console.WriteLine("Eva plockar fram bevisen men")
            }
        }
    }
}
*/  

class Jane : Npc
{
    public override string Name => "Jane Doe";

    public override string[] Description => [
        "En mystisk person som står vid fyren.",
        "Hon verkar ha något viktigt att berätta."
    ];

    public override string[] Actions => [
        "Prata med Jane Doe:TalkToJane",
        "Presentera alla bevis:ShowEvidence",
       
    ];
    static string[] allaBevis = { "obduktionsrapport", "signalement", "högtalare", "skiss", "lånekort", "dagboksida" };

    private void TalkToJane()
    {
        Console.WriteLine("Jane vänder sig mot dig.");
        Console.WriteLine("\"Så, du tror att du vet vem jag är?\"");
        Console.ReadLine();
    }
 
    private void ShowEvidence()
    {
        foreach (var bevis in allaBevis)
        {
            if (Player.Inventory.Contains(bevis))
            {
                VisaDialog(bevis);
            }
            
        }
    }
 
    static void VisaDialog(string bevis)
    {
        switch (bevis)
        {
            case "obduktionsrapport":
                Console.WriteLine("Du lägger fram obduktionsrapporten.");
                Console.WriteLine("Jane: \"...\"");
                break;
 
            case "signalement":
                Console.WriteLine("Du lägger fram signalementet.");
                Console.WriteLine("Jane: \"...\"");
                break;
 
            case "högtalare":
                Console.WriteLine("Du lägger fram högtalaren.");
                Console.WriteLine("Jane: \"...\"");
                break;
 
            case "skiss":
                Console.WriteLine("Du lägger fram skissen.");
                Console.WriteLine("Jane: \"...\"");
                break;
 
            case "lånekort":
                Console.WriteLine("Du lägger fram lånekortet.");
                Console.WriteLine("Jane: \"...\"");
                break;
 
            case "dagboksida":
                Console.WriteLine("Du lägger fram dagbokssidan.");
                Console.WriteLine("Jane: \"...\"");
                break;
        }
    }
 
    static void AvgorSlutet()
    {
        bool harAllaBevis = allaBevis.All(b => Player.Inventory.Contains(b));
 
        if (harAllaBevis)
        {
            Console.WriteLine("\nDu har lagt fram alla bevis. Du griper Jane.");
            // logik för att gripa Jane / vinst-scenen
        }
        else
        {
            Console.WriteLine("\nDu saknar bevis. Du får börja om utanför fyren.");
            // flytta spelaren till fyren / återställ spelet
        }
    }
 

}

/*void ConfrontJane()
    {
        var shown = new List<string>();
 
        Console.WriteLine("Jane vänder sig mot dig.");
        Console.WriteLine("\"Så, du tror att du vet vem jag är?\"");
        Console.ReadLine();
 
        while (shown.Count < Evidence.Length)
        {
            // Only evidence the player holds and hasn't used yet
            var options = Evidence
                .Where(e => Player.Has(e.Item) && !shown.Contains(e.Item))
                .ToList();
 
            Console.WriteLine();
            for (int i = 0; i < options.Count; i++)
                Console.WriteLine($"{i + 1}. {options[i].Menu}");
            Console.WriteLine("0. Anklaga henne med det du har");
            Console.Write("> ");
 
            if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 0 || choice > options.Count)
            {
                Console.WriteLine("Välj ett nummer.");
                continue;
            }
 
            if (choice == 0) break;
 
            var picked = options[choice - 1];
            shown.Add(picked.Item);
 
            Console.WriteLine();
            Console.WriteLine($"Eva: \"{picked.EvaSays}\"");
            Console.WriteLine(picked.JaneReacts);
            Console.ReadLine();
        }
 
        if (shown.Count == Evidence.Length)
        {
            Console.WriteLine();
            Console.WriteLine("Bevisen ligger utspridda framför henne. Jane säger ingenting längre.");
            Console.WriteLine("Hon sjunker ihop på trappan. Det är över.");
            Console.WriteLine("*** DU VANN ***");
            Console.ReadLine();
            Environment.Exit(0); // TODO: replace with ending/credits
        }
        else
        {
            var missing = Player.Missing(Evidence.Select(e => e.Item).ToArray());
            Console.WriteLine();
            Console.WriteLine("Jane ler kallt. \"Det räcker inte, kommissarien.\"");
            Console.WriteLine("Hon rör sig blixtsnabbt. Allt blir svart.");
            Console.WriteLine("*** DU ÄR DÖD ***");
            Console.WriteLine($"(Du saknade: {string.Join(", ", missing)})"); // remove for the real game
            Console.ReadLine();
            Environment.Exit(0);

*/



// static readonly (string Item, string Menu, string EvaSays, string JaneReacts)[] Evidence =
//     {
//         ("obduktionsrapport",
//          "Lägg fram obduktionsrapporten",
//          "Trollklorna är gjorda med en kirurgkniv. Samma snitt som i Whitechapel 1888.",
//          "Jane rycker till. \"Rättsläkare... alltid detaljerna. Jag var noga med trollspåren.\""),
 
//         ("signalement",
//          "Visa signalementet från hotelliggaren",
//          "Du checkade in på Grand Hôtel under falskt namn kvällen före mordet.",
//          "Jane ler kallt. \"Ett hotellrum är inget bevis. Men fortsätt, kommissarien.\""),
 
//         ("högtalare",
//          "Visa högtalaren från grottan",
//          "Kullamannens vrål kom ur en högtalare. Berget har aldrig vaknat.",
//          "\"Bra ljudkvalitet, eller hur?\" säger Jane. Hennes röst är ansträngd."),
 
//         ("skiss",
//          "Visa konstnärens skiss",
//          "Konstnären ritade en kvinna på piren i Arild. Det är ditt ansikte.",
//          "Jane ser på skissen. Leendet försvinner. \"Han skulle aldrig ha ritat.\""),
 
//         ("lånekort",
//          "Visa lånekortet från slottsbiblioteket",
//          "Du lånade boken om Kullamannen. Ditt namn står på kortet.",
//          "\"Jag hade tänkt lämna tillbaka den\", viskar Jane och skrattar till."),
 
//         ("dagbokssida",
//          "Läs upp dagbokssidan",
//          "\"Jag hör dem fortfarande. Berget svarar när jag dödar.\" Du skrev det själv.",
//          "Jane blir alldeles stilla. \"Var hittade du den? Den skulle vara borta.\""),
//     };

//  vi kan komma in i fyren utan alla bevis, men vid konfrontation utan alla bevis "konfronteras" vi av Jane Doe och vi "dödas" och kommer 
//tillbaka med hint alt. hint har givits efter Jane Doe konfronterar. 

// bool harAllaBevis = allaBevis.All(
//     b => Player.Inventory.Any(i => i.Equals(b, StringComparison.OrdinalIgnoreCase)

//  bool harAllaBevis = allaBevis.All(b => Player.Inventory.Contains(b));


 