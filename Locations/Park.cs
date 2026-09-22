class Park : Location
{
    private bool _talkedToGardener;

    public override string Name => "Park";

    public override string[] Description => [
        "En finklippt gräsmatta fylld med blomster, trimmade träd och i fjärran ett slott." +
        "Mitt i blomstern sitter det en trädgårdsmästare och påtar i rabatten",
        _talkedToGardener ? "Trädgårdsmästaren har återgått till sitt arbete." : ""
    ];

    public override string[] Actions => _talkedToGardener
        ? ["Look Around:LookAround"]
        : ["Look Around: LookAround", "Prata med trädgårdsmästaren:TalkToGardener"];

    public void LookAround()
    {
        Console.WriteLine("Ogräs, jordhögar och trimmade träd");
        Console.ReadLine();
    }

    public void TalkToGardener()
    {
        _talkedToGardener = true;
        Console.WriteLine("Trädgårsmästaren berättar om en kvinna som kom och smög in i slottet");
        Console.ReadLine();   
    }
    public void Leave()
    {
        Console.WriteLine("Du lämnar trädgårsmästaren ifred");
        Console.ReadLine();
    }
}
