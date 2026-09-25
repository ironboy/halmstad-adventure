class Path : Location
{
    private Mathematician _mathematician = new();

    public override string Name => "Stigen";

    public override string[] Description => [
        "En smal, dimmig stig slingrar sig mellan granarna"
        
    ];
    public override string[] Actions => [
        "Kolla runt:LookAround",
        _mathematician.hasVanished
        ? "Matematikern är borta inget att se"
        : "Prata med mannen:TalkToMathematician"
    ];
    public void TalkToMathematician()
    {
        _mathematician.Run();
    }
    public void LookAround()
    {
        if(_mathematician.hasVanished)
        {
            Console.WriteLine("Fortfarande bara en stig. Mannen är borta...");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Inte mycket att se bara en vanlig stig och en äldre man som står vid trädet...");
            Console.ReadKey();
        }
    }
}