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
    static string[] allaBevis = { "Obduktionsrapport", "Hårtuss", "Högtalare", "Skiss", "Lånekort", "Dagbokssida" };

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
            case "Obduktionsrapport":
                Console.WriteLine("Du slänger rapporten på bordet. \"Rivsåren. Alla sa att det var Kullamannens klor.",
            "Men Dr. Lindkvist säger något annat: kirurgiska knivar. Precis som morden i London.\"");
                Console.WriteLine("Jane: \"London...\" Det är första gången hennes röst spricker.");
                Console.ReadLine();
                break;
 
            case "Hårtuss":
                Console.WriteLine("Du läser högt ur ditt anteckningsblock. \"Signalementet från den blodiga kroken i Mölle hamn:",
                "långt, svart hår. Det stämmer med dig.\"");
                Console.WriteLine("\"Halva Kullen har svart hår\", fräser Jane, men hon för handen till sitt hår.");
                Console.ReadLine();
                break;
 
            case "Högtalare":
                Console.WriteLine("Du ställer den blodfläckade högtalaren från Silvergrottan framför henne.",
                "\"Skräckljuden i grottan. Spöket på väggen. Du byggde en sägen så att ingen skulle leta efter en människa.\"");
                Console.WriteLine("Jane ler snett. \"Folk vill tro på monster. Jag gav dem bara det de ville ha.\"");
                Console.ReadLine();
                break;
 
            case "Skiss":
                Console.WriteLine("Du vecklar ut konstnärens skiss. Kvinnan på piren tittar upp från pappret. Det är hennes ansikte.",
                "\"Leo såg dig den kvällen. Du försökte gömma dig, men inte tillräckligt bra.\"");
                Console.WriteLine("Hon stirrar på teckningen länge. \"Han fick till ögonen\", viskar hon.");
                Console.ReadLine();
                break;
 
            case "Lånekort":
                Console.WriteLine("\"Boken om Kullamannen i slottsbiblioteket. Utlånad till Jane Doe.",
                "Du trodde inte på sägnen. Du studerade den. Du använde den.\"");
                Console.WriteLine("\"Man måste känna sitt monster\", säger hon tyst, \"om man ska bära hans namn.\"");
                Console.ReadLine();
                break;
 
            case "Dagbokssida":
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
            Console.Clear();
            Console.WriteLine("Bevisen ligger utspridda framför henne. Jane skriker \"FIGHT\"");
            Console.WriteLine("Jane kastar ut sin kullaboll och där kommer \"Kullamannen\"");
            Console.WriteLine("Eva kastar ut sin kullaboll och där kommer \"Johan Falk\"");
            Console.ReadKey();
            if(Fight()) // Om man vinner fighten
            {
                Console.WriteLine("Jane grips");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Du dör lol noob");
                Console.ReadKey();
                Menu.Close();
            }
            
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

    static bool Fight()
    {
        var johan = new Johan();
        var kullamannen = new Kullamannen();
        var random = new Random();
        while(johan.Hp > 0 && kullamannen.Hp > 0)   //Körs till någon har mer än 0 HP
        {
            Console.Clear();
            Console.WriteLine($"{johan.Name}: {johan.Hp} HP");
            Console.WriteLine($"{kullamannen.Name}: {kullamannen.Hp} HP\n");
            Console.WriteLine($"1. Skjut (15 skada)\n2. Slå (10 skada)\nVälj attack: ");

            string input = Console.ReadLine();

            if (input == "1")
            {
                johan.Attack(kullamannen, 1);   //Choice parameter för vilken attack som ska användas
            }
            else if (input == "2")
            {
                johan.Attack(kullamannen, 2);
            }
            else
            {
                continue;
            }
            if (kullamannen.Hp > 0)
            {
                int enemyChoice = random.Next(1,3);
                kullamannen.Attack(johan, enemyChoice);
            }
            Console.ReadKey();         
        }
        return kullamannen.Hp <= 0;
    }
 
// jane kastar kullamannen
// eva kastar Johan Falk
}
