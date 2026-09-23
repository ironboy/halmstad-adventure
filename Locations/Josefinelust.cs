class Josefinelust : Location
{
    
    private ScaredTourist _scaredTourist = new();
    
    public override string Name => "Utanför grottan";

    public override string[] Description => [
        "Du står i klipplandskapet utanför grottan.",
        "Du ser en rädd turist nära grottmynningen."
        
    ];

    public override string[] Actions => [
      _scaredTourist.Scared ? "Prata med turisten:TalkToTourist" : "Kolla i busken:ExamineBush", 
    ];

    public void TalkToTourist()
    {
       _scaredTourist.Run();
    }

    public void ExamineBush()
    {
        Console.WriteLine("You find a note, which has a pincode.");
        Console.ReadLine();
    }

    public void TakeNote()
    {
        Player.Inventory.Add("Papper med pinkod");
        Console.WriteLine("Du tar upp pappret");
        Console.ReadLine();
        Menu.Close();
    }

}