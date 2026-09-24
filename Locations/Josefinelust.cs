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
      _scaredTourist.ToldAboutBush
        ? "Kolla i busken:ExamineBush"
        : "Titta runt:LookAround"
         
    ];

    public void TalkToTourist()
    {
       _scaredTourist.Run();
    }

    public void ExamineBush()
    {
        if(Player.Has("PINKOD"))
        {
            Console.WriteLine("En vanlig buske...");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Du hittar ett papper med en pinkod");
            Player.Inventory.Add("PINKOD");
            Console.ReadLine();
        }
       
    }
    public void LookAround()
    {
        Console.WriteLine($"Du ser inget ovanligt men turisten verkar veta något ");
        Console.ReadKey();
    }
    
}