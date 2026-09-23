//KLAR
class Klippstranden : Location
{
    private bool _beachSearched;
    private Dog dog = new Dog();

    public override string Name => "Klippstranden";

    public override string[] Description => [
        "En synerligen tom strand, vid drivvedstornet.",
        dog.Bribed
            ? "Hunden är upptagen med sin pinne. Vägen till drivveden är fri."
            : "En hund står vid drivveden och skäller – den verkar ha hittat något men släpper inte fram dig."
    ];

    public override string[] Actions => GetActions();

    private string[] GetActions()
    {
        if (_beachSearched)
        {
            return ["Look around:LookAround"];
        }

        if (dog.Bribed)
        {
            return [
                "Look around:LookAround",
                "Sök igenom drivveden:SearchBeach"
            ];
        }

        return [
            "Look around:LookAround",
            "Prata med hunden:TalkToDog"
        ];
    }

    public void LookAround()
    {
        Console.Clear();
        if (dog.Bribed)
        {
            Console.WriteLine("Hunden är distraherad. Du ser nu en spricka i drivveden där något papper sticker ut.");
        }
        else
        {
            Console.WriteLine("Hunden står i vägen för drivvedstornet. Du måste få bort den för att kunna undersöka närmare.");
        }
        Console.WriteLine("\nTryck Enter för att fortsätta...");
        Console.ReadLine();
    }

    public void TalkToDog()
    {
        bool inDogMenu = true;

        while (inDogMenu && !dog.Bribed)
        {
            Console.Clear(); 
            Console.WriteLine("Du går fram till hunden.");
            Console.WriteLine(dog.Description[0]);
            
            Console.WriteLine("1. Vissla på hunden");
            Console.WriteLine("2. Erbjud en pinne");
            Console.WriteLine("0. Gå tillbaka");
            Console.Write("> ");
            
            string input = Console.ReadLine();

            if (input == "1")
            {
                Console.Clear();
                dog.VisslaTillHunden();
            }
            else if (input == "2")
            {
                Console.Clear();
                dog.Bribe(); 

                Console.WriteLine("\nVägen till drivvedstornet är nu fri!");
                Console.WriteLine("Tryck Enter för att återvända till menyn...");
                Console.ReadLine();

                inDogMenu = false; 
            }
            else if (input == "0")
            {
                inDogMenu = false;
            }
        }
    }

    public void SearchBeach()
    {
        Console.Clear();
        if (_beachSearched)
        {
            Console.WriteLine("Du har redan genomsökt drivveden och tagit dagbokssidan.");
            Console.WriteLine("\nTryck Enter för att fortsätta...");
            Console.ReadLine();
            return;
        }

        Console.WriteLine("Du går fram till drivvedstornet och undersöker det noggrant.");
        Console.WriteLine("I en spricka mellan trästockarna ser du hörnet av en ihopvikt papperssida.\n");
        
        Console.WriteLine("Vill du sträcka dig in i sprickan?");
        Console.WriteLine("1. Sträck dig in och ta sidan");
        Console.WriteLine("2. Lämna den tills vidare");
        Console.Write("> ");

        string choice = Console.ReadLine();
        if (choice == "1")
        {
            TakeNote();
        }
        else
        {
            LeaveIt();
        }
    }

    public void TakeNote()
    {
        Console.Clear();
        _beachSearched = true;
        Player.Inventory.Add("dagbokssida");
        Console.WriteLine("Du lirkar försiktigt loss pappret... Du hittade en dagbokssida!");
        Console.WriteLine("Du stoppar ner dagbokssidan i ditt inventory.");
        Console.WriteLine("\nTryck Enter för att fortsätta...");
        Console.ReadLine();
    }

    public void LeaveIt()
    {
        Console.Clear();
        Console.WriteLine("Du låter sidan sitta kvar i drivveden än så länge.");
        Console.WriteLine("\nTryck Enter för att fortsätta...");
        Console.ReadLine();
    }
}