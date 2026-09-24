class Park : Location
{
    private bool _talkedToGardener;
    private readonly Gardener _gardener = new();

    public override string Name => "Park";

    public override string[] Description => [
        "En finklippt gräsmatta fylld med blomster, trimmade träd och mot öster ett slott." +
        " Mitt i blomstern sitter det en trädgårdsmästare och påtar i rabatten",
        _talkedToGardener ? "Trädgårdsmästaren har återgått till sitt arbete." : ""
    ];

    public override string[] Actions => _talkedToGardener
        ? ["Se dig omkring:LookAround"]
        : ["Se dig omkring:LookAround", "Gå mot trädgårdsmästaren:TalkToGardener"];

    public void LookAround()
    {
        Console.WriteLine("Du ser att trädgårdsmästaren gräver runt frenetiskt och där har lämnats jordhögar lite här och var.");
        Console.ReadLine();
    }

  public void TalkToGardener()
{
    _talkedToGardener = true;
    _gardener.Run();
}
 public override void East()
    {
        if (!_gardener.GlassesFound)
        {
            Console.WriteLine("Du bör nog prata klart med trädgårdsmästaren innan du går vidare.");
            Console.ReadLine();
        }
        else
        {
            // call the super class ("base") East method (in Location)
            base.East();
        }
    }
}
