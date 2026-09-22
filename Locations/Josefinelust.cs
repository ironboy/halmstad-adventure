class Josefinelust : Location
{
    
    private bool _hasInterrogatedTourist;

    private ScaredTourist _scaredTourist = new();
    
    public override string Name => "Utanför grottan";

    public override string[] Description => [
        "Du står i klipplandskapet utanför grottan.",
        "Du ser en rädd turist nära grottmynningen."
    ];

    public override string[] Actions => [
       _hasInterrogatedTourist ? "Undersök busken:ExamineBush" : "Prata med turisten:TalkToTourist"
    ];

    public void TalkToTourist()
    {
       _scaredTourist.Run();
    }

    public void ExamineBush()
    {
        Console.WriteLine("You examine the bush. It's big");
        Console.ReadLine();
    }
}