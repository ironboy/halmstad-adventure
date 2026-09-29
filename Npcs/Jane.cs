class Jane : Npc
{
    public override string Name => "Jane Doe";

    public override string[] Description => [
        "En mystisk person som står vid fyren.",
        "Hon verkar ha något viktigt att berätta."
    ];

    public override string[] Actions => [
        "Prata med Jane Doe:TalkToJane",
        "Arrestera Jane:ArrestJane",
        "Knuffa Jane in i väggen",
        "Visa signalament från hotelliggaren",
        "Visa högtalaren från grottan",
        "Visa konstnärens skiss",
        "Visa lånekortet från slottsbiblioteket",
        "Läs upp dagboksidan",
        "",
        "Konfrontera Janne Doe"
       
    ];
    static List<string> insamladeBevis = new List<string>();
    static string[] allaBevis = { "obduktionsrapport", "signalement", "högtalare", "skiss", "lånekort", "dagboksida" };
 
    static void Main()
    {
        // insamladeBevis fylls på under spelets gång, där spelaren faktiskt hittar bevisen
        // t.ex: insamladeBevis.Add("obduktionsrapport");
 
        PresenteraAllaBevis();
        AvgorSlutet();
    }
 
    static void PresenteraAllaBevis()
    {
        foreach (var bevis in allaBevis)
        {
            if (insamladeBevis.Contains(bevis))
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
 