 class Himmelstorp : Location
 {
     private  Hikers hikers = new Hikers();


     private bool _searchTheDog;
     private bool _searchTheForest;
    

     public override string Name => "Himmelstorp";

     public override string[] Description => [
         "En stor bokskog breder ut sig runt Eva.",
         "Två vandrare står framför henne på stigen.",
         
         _searchTheDog ? "Vandrarna såg inte åt vilket håll hunden gick." : "Eva hittar hundspår."
     ];

     public override string[] Actions => _searchTheDog 
     ? ["Talk to the hikers:TalkToHikers"]
        : ["searchTheForest:SearchTheForest.",
            "Go deeper in to the Forest:GoDeeperInToTheForest"

        ]; 
                                                           
public void TalkToTheHikers()
    {
        Console.WriteLine("Eva: Hur ser hunden ut och vet vi vart den tog vägen?.");
        Console.WriteLine("Vandrarna: Nej vi såg inte vart han tog vägen?");
        Console.WriteLine("Eva: Okej, jag hjälper er att hitta honom.");
        Console.ReadLine();
    }

    public void SearchTheForest()
    {
        Console.WriteLine("Eva går in i skogen och hittar inget förutom mer skog och olika djurspår");
        Console.ReadLine();
    }
    public void GoDeeperInToTheForest()
    {
        _searchTheDog = true;
        Console.WriteLine("Eva går djupare in i skogen och hittar hundspår.");
        Console.ReadLine();
        
    }




 }
