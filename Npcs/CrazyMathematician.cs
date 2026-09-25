class Mathematician : Npc
{
    public override string Name => "Matematiker";
    public bool hasVanished {get; private set;} = false;

    public override string[] Description => [
      "En äldre man i gammaldags kostym står lutad mot trädet och räknar tyst på fingrarna",
      "Han lämnar inga fotspår i leran, och luften runt honom är märkligt kall"
    ];

    public override string[] Actions => [
       "Fråga om han vet vägen till grottan:AskDirections",
       "Fråga vad han känner till Kulla mannen:AskAboutMyth",
       Player.Has("QUIZ-MASTER BADGE")
        ? "Visa quiz badge till matematikern:ShowQuizBadge"
        : "-"   //Remove items from inventory
    ];
    public void AskDirections()
    {
        Console.Clear();
        Console.WriteLine(@"""Enkelt!"" säger han och tar genast fram sin anteckingsbok.
        
""Du går 4,2 centimeter rakt fram. Akta dig för stenen genom att svänga 3 centimer åt vänster.
Sedan 7,8 centimeter i en vinkel på ungefär 34,5 grader mot nordöst, men bara om vinden kommer från -
sydväst, annars blir felmarginalen katastrofal...""

Han forstätter i vad som känns som tio minuter.
Du gav upp att lyssna för länge sen");
        Console.ReadKey();
    }
    public void AskAboutMyth()
    {
        Console.Clear();
        Console.WriteLine(@"""Baserat på min statistiska modell,"" säger han och pekar stolt på
ett anteckningsblad fullt av klotter och ekvationer, ""är sannolikheten för Kullamannens existens -
exakt 23,7 procent. Plus minus 0,4 beroende på månfas.""

Han nickar, som om det förklarade allt.");
        
        Console.ReadKey();
    }
    public void ShowQuizBadge()
    {
        Console.Clear();
        Console.WriteLine(@"Du tar fram QUIZ-MASTER-badgen och visar den för honom.
    
    Han stelnar till och blicken ändras
    
    ""...du klarade den,"" säger han tyst. ""Ingen har klarat den på över hundra år""
    
    Han river upp en sida i sin anteckningsbok, full av siffror och kordinater.
    
    ""Avstånden mellan de nya morden. Jag har mätt dem. Och gissa vad?
    Exakt samma mönster som WhiteChapel, 1888. Bara flyttat hit, i mindre skala.
    Vinklarna stämmer. Avstånden stämmer. På decimalen""
    
    Du stirrar på honom och tänker, hur vet han om morden!?
    
    Innan du hinner säga något så säger han. ""Det mesta går att räkna ut om man vet vart man ska titta.""
    
    Du blinkar till av en fluga som flyger förbi ansiktet.
    
    När du öppnar ögönen igen står han inte där längre.
    Ingen väg han kunde ha gått. Bara gräset orört, som om ingen någonsin stått där");
    Console.ReadKey();
    Player.Inventory.Remove("QUIZ-MASTER BADGE");
    hasVanished = true;
    Menu.Close();
    }
}