class Josefinelust : Location
{
    public bool TouristScared = true; //How to set to false through interaction with Tourist?

    private ScaredTourist _scaredTourist = new();
    
    public override string Name => "Utanför grottan";

    public override string[] Description => [
        "Du står i klipplandskapet utanför grottan.",
        "Du ser en rädd turist nära grottmynningen."
        
    ];

    public override string[] Actions => [
      TouristScared ? "Prata med turisten:TalkToTourist" : "Kolla i busken" 
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