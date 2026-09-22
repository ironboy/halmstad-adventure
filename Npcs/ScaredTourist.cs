// Example Npc: has its own menu, remembers what you've said to it.

class ScaredTourist : Npc
{
    public override string Name => "Rädd truist";

    public override string[] Description =>[
        "Turisten har bermuda-skjorta och shorts",
        "och ser ut som en nybliven pensionär.",
        "Skräcken lyser i ögonen på honom som om han",
        "nyss sett något oväntat och skrämmande."
    ];

    public override string[] Actions => [
        "Fråga om något ovanligt har hänt:TalkAboutUnusual",
        "Prata om vädret:TalkAboutWeather"
    ];

    public void TalkAboutUnusual()
    {
        Console.WriteLine("\"Jag vågar inte prata om det jag sett\" säger turisten tårögd");
        Console.ReadLine();
    }

     public void TalkAboutWeather()
    {
        Console.WriteLine("\"Vädret har varit fint hela dagen\" säger turisten och ser lite gladare ut.");
        Console.ReadLine();
    }


    
}
