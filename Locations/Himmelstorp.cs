class Himmelstorp : Location
{
    private Hikers hikers = new Hikers();

    private bool _searchTheForest;

    public override string Name => "Himmelstorp";

    public override string[] Description => [
        "En stor bokskog breder ut sig runt Eva.",
        "Två vandrare står framför henne på stigen.",
        hikers.TalkedToHikers
            ? "Vandrarna sa att hunden sprang ner mot Klippstranden."
            : "Vandrarna ser upprörda ut.",
        // _searchTheForest
        //     ? "Eva går djupare in i skogen"
        //     : "Hon går för att prata med dom"
    ];

    public override string[] Actions => GetActions();
    private string[] GetActions()
    {
        List<string> returnActions = new List<string>();

        returnActions.Add(hikers.TalkedToHikers ? "Prata med vandrarna igen:TalkToHikers" : "Prata med vandrarna:TalkToHikers");
       
        if (!_searchTheForest)
        {
            returnActions.Add("Sök igenom skogen:SearchTheForest");
            returnActions.Add("Gå djupare in i skogen:GoDeeperInToTheForest");
        }
         if (hikers.TalkedToHikers)
        {
            returnActions.Add("Gå till Klippstranden:GoToBeach");
        }

        return returnActions.ToArray();

    }

    public void TalkToHikers()
    {
        Console.Clear();
        hikers.Run();
    }

    public void GoToBeach()
    {
        Console.Clear();
        Console.WriteLine("Eva följer stigen ner mot Klippstranden...");
        Console.WriteLine("\nTryck Enter för att fortsätta...");
        Console.ReadLine();
        base.South();
    }

    public void SearchTheForest()
    {
        Console.Clear();
        Console.WriteLine("Eva går in i skogen och hittar inget förutom mer skog och olika djurspår.");
        Console.WriteLine("\nTryck Enter för att fortsätta...");
        Console.ReadLine();
    }

    public void GoDeeperInToTheForest()
    {
        Console.Clear();
        _searchTheForest = true;
        Console.WriteLine("Eva går djupare in i skogen och hittar hundspår som verkar gått ifrån vandrarna ner mot Klippstranden.");
        Console.WriteLine("Det finns inget mer intressant att undersöka här.");
        Console.WriteLine("\nTryck Enter för att fortsätta...");
        Console.ReadLine();
    }

}


























