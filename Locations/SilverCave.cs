class SilverCave : Location
{
    private bool _speakerIsOff;
    private bool _projectorOff;
    private bool _quizComplete;
    public override string Name => "Inne i gråttan";

     public override string[] Description => [
        "Du står inne i gråttan och du ser projektorn som spelar upp ett spöke",
        "Du hör och ser att det finns en högtalare i gråttan som spelar upp skräck ljud",
        "Det finns även en laptop"        
    ];

    public override string[] Actions => [
       "Kolla på högtalaren",
       _speakerIsOff 
            ? "-Högtalaren är avstängd:SpeakerAlreadyOff"
            : "-Stäng av:TurnOffSpeaker",
        _speakerIsOff
            ? "-Lyssna på tystnaden:LitsenToSilence"
            : "-Bara står där och tänk på livet:JustStandThere",
        "Gå till projektorn",
        _projectorOff
            ? "-Projektorn är avstängd:ProjectorAlreadyOff"
            : "-Stäng av projektorn:TurnOffProjector",
        "Gå till laptopen",
        _quizComplete
            ? "-Försök hitta något mer på den?:LaptopAlreadyHacked"
            : "-Hacka dig in?:HackLaptop"
             
    ];

    public void TurnOffSpeaker()
    {
        Console.WriteLine("Högtalaren frågor om en pinkod för att stänga av");
        if(Player.Has("PINKOD"))
        {
            Console.WriteLine("Du anger korrekt pin-kod och musiken tystnar");
            Console.WriteLine("Du ser blodspår på högtalaren så du tar med den som bevis");
            Player.Inventory.Add("Högtalare");
            _speakerIsOff = true;
            Menu.Close();
        }
        else
        {
            Console.WriteLine("Du gissar på din favoritkod 1234 med det fungerar inte.");
        }
        Console.ReadLine();
    }
    public void SpeakerAlreadyOff()
    {
        Console.WriteLine("Inget att se den är avstängd...");
        Console.ReadKey();
    }
    public void TurnOffProjector()
    {
        Console.WriteLine("Du stänger av projektorn. Turisten kankse vågar prata med dig\nDu tar en bild så du kan bevisa att spöket var fake");
        _projectorOff = true;
        Player.Inventory.Add("Bluffbevis");
        Console.ReadKey();
        Menu.Close();
    }
    public void ProjectorAlreadyOff()
    {
        Console.WriteLine($"Inget att se den är avstängd...");
        Console.ReadKey();
    }
    public void LitsenToSilence()
    {
        Console.WriteLine($"Du står still och lyssnar på tystnaden\nDu får ångest så du skiter i det");
        Console.ReadKey();
    }
    public void JustStandThere()
    {
        Console.WriteLine($"Du försöker tänka på ditt liv men ljudet stör dig...");
        Console.ReadKey();
    }
    public void HackLaptop()
    {
       Console.WriteLine($"Du försöker logga in på den men för det måste du klara av ett quiz...");
       Console.ReadKey();
       bool answeredCorrectly = false;
       
       while (!answeredCorrectly)
        {   Console.Clear();
            Console.WriteLine($"Fråga 1. Vad kallas ett fel i ett program?\n1. Loop?\n2. Kompilator\n3. Bugg?\n4. Variabel?");
            if(int.TryParse(Console.ReadLine(), out int answer))
            {
                if (answer == 3)
                {
                    Console.WriteLine($"CORRECT!");
                    Console.ReadKey();
                    answeredCorrectly = true;
                }
                else
                {
                    Console.WriteLine($"FEL, TESTA IGEN!");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine($"OGILTIG INMATNING, FÖRSÖK IGEN!");
                Console.ReadKey();
            }
            
        }
        answeredCorrectly = false;
        
        while (!answeredCorrectly)
        {
            Console.Clear();
            Console.WriteLine($"Fråga 2. Vilken datatyp har bara värderna sant och falsk?\n1. Boolean?\n2. Sträng?\n3. Heltal?\n4. Array?");
            if(int.TryParse(Console.ReadLine(), out int answer))
            {
                if(answer == 1)
                {
                    Console.WriteLine($"CORRECT!");
                    Console.ReadKey();
                    answeredCorrectly = true;
                }
                else
                {
                    Console.WriteLine($"FEL, TESTA IGEN!");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine($"OGILTIG INMATNING, FÖRSÖK IGEN!");
                Console.ReadKey();
            }
        }
        answeredCorrectly = false;
        
        while (!answeredCorrectly)
        {
            Console.Clear();
            Console.WriteLine($"Fråga 3. Vad kallas en funktion som anropar sig själv?\n1. Asynkron?\n2. Anonym?\n3. Rekusiv?\n4. Iterativ?");
            if(int.TryParse(Console.ReadLine(), out int answer))
            {
                if (answer == 3)
                {
                    Console.WriteLine($"CORRECT!");
                    Console.ReadKey();
                    answeredCorrectly = true;
                }
                else
                {
                    Console.WriteLine($"FEL, TESTA IGEN!");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine($"OGILTIG INMATNING, FÖRSÖK IGEN!");
                Console.ReadKey();
            }
        }
        Console.WriteLine($"Grattis! Du har klarat quizet. Du får en \"QUIZ-MASTER BADGE!\"");
        Player.Inventory.Add("QUIZ-MASTER BADGE");
        _quizComplete = true;
        Console.ReadKey();
        Menu.Close();
    }
    public void LaptopAlreadyHacked()
    {
        Console.WriteLine($"Inget mer att hitta...waste of time");
        Console.ReadKey();
    }

}