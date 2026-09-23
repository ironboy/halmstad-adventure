class Himmelstorp : Location
{
    private Hikers hikers = new Hikers();
    private bool _searchTheDog;

    public override string Name => "Himmelstorp";

    public override string[] Description => [
        "En stor bokskog breder ut sig runt Eva.",
        "Två vandrare står framför henne på stigen.",
        _searchTheDog 
            ? "Vandrarna såg inte åt vilket håll hunden gick." 
            : "Eva hittar hundspår."
    ];

    public override string[] Actions => _searchTheDog 
        ? ["Prata med vandrarna:TalkToHikers"]
        : [
            "Sök igenom skogen:SearchTheForest",
            "Gå djupare in i skogen:GoDeeperInToTheForest"
          ]; 

    public void TalkToHikers()
    {
        Console.Clear();
        Console.WriteLine("Eva: Hur ser hunden ut och vet ni vart den tog vägen?");
        Console.WriteLine("Vandrarna: Det är en liten brun och svart med stora uppstående öron. Nej, vi såg inte vart han tog vägen.");
        Console.WriteLine("Eva: Okej, jag hjälper er att hitta honom.");
        Console.WriteLine("\nTryck Enter för att fortsätta...");
        Console.ReadLine();
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
        _searchTheDog = true;
        Console.WriteLine("Eva går djupare in i skogen och hittar tydliga hundspår som leder vidare mot stranden!");
        Console.WriteLine("\nTryck Enter för att fortsätta...");
        Console.ReadLine();
    }
}