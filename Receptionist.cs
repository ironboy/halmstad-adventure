using System.Formats.Asn1;

class Receptionist : Npc
{
    public bool AllowsLookInLedger;


    public List<string> Besökare = ["James Fawnhill","Thomas Andersson","Claus von Braum","Jenny Karlsson","Emelie J. Mongomery"];

    public override string Name => "Receptionisten Louise";

    public override string[] Description => [
        "Du ser en människa bakom bordet och antar att detta är hotellpersonal",
        "Mörka ringar runt ögonen ger intrycket av att hon är utarbetad",
        ""
    ];

    public override string [] Actions => [
         "Fråga Loiuse, \"Kan jag få kolla i liggaren?\":AskAboutLedger",
         "Fråga Lisa, \"Vad kostar er dyraste svit?\":AskAboutSuite"
    ];

    public void AskAboutSuite()
    {
        
         Console.WriteLine("\"Ja vad trevligt att du vill ha ett rum, de kostar 5000kr per natt\"");
         Console.WriteLine("Vill du skriva in dig i liggaren redan nu?");
         Console.WriteLine("Svara Ja/Nej");
        
         AllowsLookInLedger = Console.ReadLine()!.Trim().Equals("Ja");
         
         



        if (AllowsLookInLedger)
        {
            Console.Write("Skriv ditt namn: ");
            string namn = Console.ReadLine()!;

            Besökare.Add(namn);
            Console.WriteLine("Varsågod, här är liggaren");

            

            foreach (string besökare in Besökare)
            {
                Console.WriteLine(besökare);
            }
        }
        else
        {
            Console.WriteLine("Jasså, äru snål eller?");
        }

        Console.ReadLine();
    }

    public void AskAboutLedger()
    {
        if (AllowsLookInLedger)
        {
            Console.WriteLine("Självklart för er som hyr sviter!");
        }
        else
        {
            Console.WriteLine("\"Sådana uppgifter lämnar vi inte ut\"");
        }

        Console.ReadLine();
    }
}



// class Receptionist : Npc
// {
//     public bool AllowsLookInLedger;

//     public List<string> Besökare =  ["James Fawnhill","Thomas Andersson","Claus von Braum","Jenny Karlsson","Emelie J. Mongomery"];

//        public override string Name => "Loiuse";  


//     public override string [] Description => [
//                  "Receptionisten välkommmar dig vid desken, du tittar hastigt på hennes namn-tag på bröstet",
//                  "noterar att det står Louise"   
//     ];
    
//     // : seperates the key "Ask Loiuse...\" from the value AskAboutLedger"
//     public override string [] Actions => [
//         "Fråga Loiuse, \"Kan du få kolla i liggaren?\":AskAboutLedger",
//         "Fråga Lisa, \"Vad kostar er dyraste svit?\":AskAboutSuite"
//     ];
    
//     public void AskAboutLedger()
//     {
//         Console.WriteLine("\"Ja vad trevligt att du vill ha ett rum\"");
//         Console.WriteLine("Vill du skriva in dig i liggaren redan nu?");
//         Console.WriteLine("Svara receptionist Ja/Nej");
//         Console.WriteLine("Varsågod, här är liggaren");

//         AllowsLookInLedger = Console.ReadLine()!.Trim().Equals("Ja");

//         if (AllowsLookInLedger)
// {
//     Console.Write("Skriv ditt namn:");
//     string namn = Console.ReadLine()!;

//     Besökare.Add(namn);


//     foreach (string besökare in Besökare)
//     {
//         Console.WriteLine(besökare);
//     }
// }
// else
// {
//     Console.WriteLine("\"Sådana uppgifter lämnar vi inte\"");
// }
//  }
// }
    

    


