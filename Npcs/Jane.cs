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
    static string[] allaBevis = { "obduktionsrapport", "signalement", "högtalare", "skiss", "lånekort", "dagbokssida" };

    private void TalkToJane()
    {
        Console.WriteLine("Jane vänder sig mot dig.");
        Console.WriteLine("\"Så, du tror att du vet vem jag är?\"");
        Console.ReadLine();
    }
 
    private void ShowEvidence()
    {
       bool goodEnding = true;
        foreach (var bevis in allaBevis)
        {
            if (Player.Inventory.Contains(bevis))
            {
                VisaDialog(bevis);
            }
            else
            {
                goodEnding = false;
            }
            
        }

        AvgorSlutet(goodEnding);
    }
 
    static void VisaDialog(string bevis)
    {
        switch (bevis)
        {
            case "obduktionsrapport":
                Console.WriteLine("Du slänger rapporten på bordet. \"Rivsåren. Alla sa att det var Kullamannens klor.",
            "Men Dr. Lindkvist säger något annat: kirurgiska knivar. Precis som morden i London.\"");
                Console.WriteLine("Jane: \"London...\" Det är första gången hennes röst spricker.");
                Console.ReadLine();
                break;
 
            case "signalement":
                Console.WriteLine("Du läser högt ur ditt anteckningsblock. \"Signalementet från den blodiga kroken i Mölle hamn:",
                "långt, svart hår. Det stämmer med dig.\"");
                Console.WriteLine("\"Halva Kullen har svart hår\", fräser Jane, men hon för handen till sitt hår.");
                Console.ReadLine();
                break;
 
            case "högtalare":
                Console.WriteLine("Du ställer den blodfläckade högtalaren från Silvergrottan framför henne.",
                "\"Skräckljuden i grottan. Spöket på väggen. Du byggde en sägen så att ingen skulle leta efter en människa.\"");
                Console.WriteLine("Jane ler snett. \"Folk vill tro på monster. Jag gav dem bara det de ville ha.\"");
                Console.ReadLine();
                break;
 
            case "skiss":
                Console.WriteLine("Du vecklar ut konstnärens skiss. Kvinnan på piren tittar upp från pappret. Det är hennes ansikte.",
                "\"Leo såg dig den kvällen. Du försökte gömma dig, men inte tillräckligt bra.\"");
                Console.WriteLine("Hon stirrar på teckningen länge. \"Han fick till ögonen\", viskar hon.");
                Console.ReadLine();
                break;
 
            case "lånekort":
                Console.WriteLine("\"Boken om Kullamannen i slottsbiblioteket. Utlånad till Jane Doe.",
                "Du trodde inte på sägnen. Du studerade den. Du använde den.\"");
                Console.WriteLine("\"Man måste känna sitt monster\", säger hon tyst, \"om man ska bära hans namn.\"");
                Console.ReadLine();
                break;
 
            case "dagboksida":
                Console.WriteLine("Du lägger dagbokssidan från drivvedstornet på bordet. Handstilen är hennes.",
            "\"Du skrev ner allt. Datum, platser, namn. Och så försökte du gömma det i havet.\"");
                Console.WriteLine("Jane blir helt stilla. \"Den sidan... den skulle ha flutit bort.\"");
                Console.ReadLine();
                break;
        }

    }
 
    static void AvgorSlutet(bool ending)
    {
       // bool harAllaBevis = allaBevis.All(b => Player.Inventory.Contains(b));
 
        if (ending)
        {
            Console.WriteLine("Bevisen ligger utspridda framför henne. Jane säger ingenting längre. \n Du griper henne.");
            Console.ReadLine();
            new Game().Run();
            // logik för att gripa Jane / vinst-scenen
        }
        else
        {
            Console.WriteLine("Jane ler kallt. \"Det räcker inte, kommissarien.\"");
            Console.WriteLine("Hon rör sig blixtsnabbt. Allt blir svart.");
            Console.WriteLine("\nDu saknade bevis och får börja om utanför fyren.");
            Console.ReadLine();
            Menu.Close();
            // flytta spelaren till fyren / återställ spelet
        }
    }
 

}
