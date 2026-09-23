class Josefinelust : Location
{
    
    private ScaredTourist _scaredTourist = new();
    
    public override string Name => "Utanför grottan";

    public override string[] Description => [
        "Du står i klipplandskapet utanför grottan.",
        "Du ser en rädd turist nära grottmynningen."
        
    ];

    public override string[] Actions => [
      "Prata med turisten:TalkToTourist",
      _scaredTourist.Scared
        ? "Titta runt:LookAround"
        : "Kolla i busken:ExamineBush"
    ];

    public void TalkToTourist()
    {
       _scaredTourist.Run();
    }

    public void ExamineBush()
    {
        Console.WriteLine("Du hittar ett papper med en pinkod");
        Player.Inventory.Add("PINKOD");
        Console.ReadLine();
    }
    public void LookAround()
    {
        Console.WriteLine($"Du ser inget men turisten verkar veta något ");
        Console.ReadKey();
    }
    
}