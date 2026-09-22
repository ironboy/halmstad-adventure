class Josefinelust : Location
{
    
    private bool _hasInterrogatedTourist;


    private ScaredTourist _scaredTourist = new();
    
    public override string Name => "Utanför grottan";

    public override string[] Description => [
        "Du står i klipplandskapet utanför grottan.",
        "Du ser en rädd turist nära grottmynningen.",
        "Han har kissat på sig"
    ];

    public override string[] Actions => [
       _hasInterrogatedTourist? "Undersök busken:ExamineBush" :  "Prata med turisten:TalkToTourist"
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
        _hasInterrogatedTourist = true;
        Player.Inventory.Add("Papper med pinkod");
        Console.WriteLine("Du tar upp pappret");
        Console.ReadLine();
        Menu.Close();   // close the submenu – the Actions list has changed
    }

}