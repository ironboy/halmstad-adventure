class MölleHamn : Location
{
   
//    public override string Name  => "MölleHamn";
//   public Npc Npc = new Gammalfiskare();
//      private readonly Gammalfiskare _ = new();
    public override string[]  Description => [
            "Du anländer till en molloken syn vid Möllehamn, du känner hur det börjar blåsa upp till storm och vill ta dig inomhus snart",
            "Det finns en hint av olja och fisk-lukt i luften"//vinden



   
    ];

//     public void TalkToPudding()
// {
//     _.Prata();
// }
    public override string[] Actions => 
    
        ShedSearched // Condition

          ? [
            "Search the shed:Searchtheshed"] // so this is a way to makle an if and else, cant make an else if tho ? :
        : [

        
            "Search the shed:Searchtheshed", // needed to have the same pattern, but i dont want it too have 2 sheds and should add an desc. to Mölle for the conspicuous sheds
            "Search the shed",
            "-Go in and search:TakeTheHook", // yeah less desc. and more method bahh
            "-Leave the area:LeaveIt"];

        public void LeaveIt()  // ska ta mig tillbaka metoden funkar inte or dvs leave it men forsätter senare.
        {
            Menu.Close(); // Ahh där satt den dock ng min efter förra kommentaren ^_^ ctrl+shift+f = gefunen 08:22 09-24-26 ty Lead

        }
        
    public bool ShedSearched;
    public void Searchtheshed()
    {
        ShedSearched = true;    
    }
     
    public void TakeTheHook()
{
    Console.WriteLine("Du hittar en blodig krok.");
    Console.WriteLine("På kroken finns en stor svart hårtuss.");
    Console.WriteLine("Du tar upp hårtussen.");

    Player.Inventory.Add("Hårtuss");

    Console.WriteLine();
    Console.WriteLine("Signalement tillagt i inventariet.");
    Console.WriteLine("Tryck på valfri tangent för att fortsätta...");

    Console.ReadKey(); // this line had to be put in so it read, otherwise it just flashed the CW


   
}
    
   
        
    }

    
      