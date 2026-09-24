class Gardener : Npc
{
    private bool _askedForHelp;
    private bool _glassesFound;
    public bool GlassesFound => _glassesFound;

    public override string Name => "Gardener";

    public override string[] Description => [
        _glassesFound
            ? "Trädgårdsmästaren ler tacksamt mot dig."
            : _askedForHelp
                ? "Trädgårdsmästaren väntar otåligt på sina glasögon."
                : "\"Gå inte på gräset! Mina glasögon ligger där någonstans, jag vill inte att du trampar på dem.\""
    ];

    public override string[] Actions => _glassesFound
        ? ["Vem var kvinnan som sprang in i dig?:AskWhoSheWas",
           "Varför hade hon så bråttom?:AskWhyInAHurry",
           "Var det något avvikande med henne?:AskIfAnythingOdd",
           "Vart sprang hon?:AskWhereSheWent",
           "Backa:Backa"]
        : _askedForHelp
            ? ["Leta efter glasögonen",
               "-I gräsmattan:SearchGrass",
               "-I busken:SearchBush",
               "-I rabatten:SearchFlowerbed"]
            : ["Presentera dig och visa polisbricka:AskAboutVisitors"];

    public void AskAboutVisitors()
    {
        _askedForHelp = true;
        Console.WriteLine("\"Vänta lite, kommissarien! Jag hjälper dig gärna med vad du önskar men snälla hjälp mig hitta glasögonen först.\"");
        Console.ReadLine();
    }

    public void SearchGrass()
    {
        Console.WriteLine("\"Nej, inte där! Akta gräset förresten - mina glasögon kan ligga precis var som helst.\"");
        Console.ReadLine();
    }

    public void SearchBush()
    {
        Console.WriteLine("\"Nej... fast vänta, hon sprang inte ens nära busken. Tänk efter, var stod jag när hon rände förbi?\"");
        Console.ReadLine();
    }

    public void SearchFlowerbed()
    {
        _glassesFound = true;
        Console.WriteLine("\"Ja! Där, bland blommorna - det var precis där hon sprang rätt in i mig!\"");
        Console.ReadLine();
        Console.WriteLine("Du ser nått som reflekterar solljuset tillbaka till dig. Glasögonen!");
        Console.WriteLine("Trädgårdsmästaren sätter på sig glasögonen och andas ut. \"Tack, kommissarien. Vad ville du veta?\"");
        Console.ReadLine();
        Menu.Close();
    }

    public void AskWhoSheWas()
    {
        Console.WriteLine("\"Jag vet inte men hon sprang rakt in i mig häromdagen. Jag tappade glasögonen i smällen -");
        Console.ReadLine();
        Console.WriteLine("och hon hjälpte inte ens till att leta, bara sprang vidare. Väldigt otrevligt av henne.\"");
        Console.ReadLine();
    }

    public void AskWhyInAHurry()
    {
        Console.WriteLine("\"Bråttom är knappast ordet - hon flydde. Blek som ett spöke, och innan hon försvann in i slottet såg jag henne kasta en snabb blick över axeln, som om något - eller någon - jagade henne.\"");
        Console.ReadLine();
    }

    public void AskIfAnythingOdd()
    {
        Console.WriteLine("\"Avvikande... nu när du frågar - hon höll krampaktigt i något under jackan. Jag tänkte inte mer på det då.\"");
        Console.ReadLine();
    }

    public void AskWhereSheWent()
    {
        Console.WriteLine("\"Vart hon tog vägen? Rakt mot slottets ytterdörr, jag hörde den slå igen bakom henne.\"");
        Console.ReadLine();
    }

    public void Backa()
    {
        Console.WriteLine("Du backar undan och lämnar trädgårdsmästaren ifred.");
        Console.ReadLine();
        Menu.Close();
    }
}