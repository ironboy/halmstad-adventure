
class ScaredTourist : Npc
{
    public override string Name => "Rädd turist";

    public bool Scared {get; private set;} = true;
    public override string[] Description =>[
        "Turisten har bermuda-skjorta och shorts",
        "och ser ut som en nybliven pensionär.",
        "Skräcken lyser i ögonen på honom som om han",
        "nyss sett något oväntat och skrämmande.",
        "Han har kissat på sig"
    ];

    public override string[] Actions => [
        !Scared
            ? "Fråga igen om turisten har sett något ovanligt:AskAgain"
            : (Player.Has("Bluffbevis")
                ? "Visa att spöken var påhittad:ShowEvidence"
                : "Fråga om något ovanligt har hänt här:TalkAboutUnusual")
    ];
    
    public void TalkAboutUnusual()
    {
        Console.WriteLine("\"Jag vågar inte prata om det jag sett\" säger turisten tårögd");
        Console.ReadLine();
        Menu.Close();
    }
    public void ShowEvidence()
    {
        Console.WriteLine("Du visar bluffbevisen till turisten");
        Console.WriteLine("Omg jag är så dum! Man är inte så klok när man är så gammal som mig\nNu ska jag åka hem och tvätta byxorna... \"Säger han\"");
        Scared = false;
        Console.ReadKey();
        Menu.Close();
    }
    public void AskAgain()
    {
        Console.WriteLine("\"Jag såg något konstigt i busken men jag var så rädd så jag våga inte kolla\" säger turisten");
        Console.ReadKey();

    }
}
