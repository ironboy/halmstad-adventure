 class Himmelstorp : Location
 {
     private readonly Hikers _hikers = new();

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
            "Follow the dog:FollowTheDog"

        ]; 
                                                           
public void TalkToTheHikers()
    {
        Console.WriteLine("Våran hund sprang iväg från oss, kan du hjälpa oss att hitta honom?.");
        Console.ReadLine();
    }

    public void SearchTheForest()
    {
        Console.WriteLine("Eva går in i skogen och hittar inget förutom mer skog och olika djurspår");
        Console.ReadLine();
    }
    public void FollowTheDog()
    {
        _searchTheDog = true;
        Console.WriteLine("Eva hittar hundspår o följer dom mot Klippstranden.");
        Console.ReadLine();
        
    }




 }
