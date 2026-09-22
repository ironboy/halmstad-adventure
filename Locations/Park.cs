class Park : Location
{
    private bool _talkedToGardener;
    private readonly Gardener _gardener = new();

    public override string Name => "Park";

    public override string[] Description => [
        "En finklippt gräsmatta fylld med blomster, trimmade träd och i fjärran ett slott." +
        "Mitt i blomstern sitter det en trädgårdsmästare och påtar i rabatten",
        _talkedToGardener ? "Trädgårdsmästaren har återgått till sitt arbete." : ""
    ];

    public override string[] Actions => _talkedToGardener
        ? ["Se dig omkring:LookAround"]
        : ["Se dig omkring:LookAround", "Prata med trädgårdsmästaren:TalkToGardener"];

    public void LookAround()
    {
        Console.WriteLine("Ogräs, jordhögar och trimmade träd.");
        Console.ReadLine();
    }

    public void TalkToGardener()
    {
        _talkedToGardener = true;
        var menu = Menu.Create([_gardener.Name, .. _gardener.Actions], _gardener);
        menu.Run("Backa");
        Menu.Close();
    }
}