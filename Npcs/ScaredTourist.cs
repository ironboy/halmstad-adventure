
class ScaredTourist : Npc
{
    public override string Name => "Rädd turist";
    public override string[] Description =>[
        "Turisten har bermuda-skjorta och shorts",
        "och ser ut som en nybliven pensionär.",
        "Skräcken lyser i ögonen på honom som om han",
        "nyss sett något oväntat och skrämmande.",
        "Han har kissat på sig"
    ];

    public override string[] Actions => [
        "Fråga om något ovanligt har hänt:TalkAboutUnusual",
        "Visa att spöken var fake:ShowEvidence"     //Show evidence menu exists only if u have it.
    ];

    public void TalkAboutUnusual()
    {
        Console.WriteLine("\"Jag vågar inte prata om det jag sett\" säger turisten tårögd");
        Console.ReadLine();
    }
    public void ShowEvidence()
    {
        Console.WriteLine("Du visar bluffbevisen till turisten, han lugnar ner sig");
        Player.Inventory.Remove("Bluffbevis");
        Console.ReadKey();
    }

    

    
}
