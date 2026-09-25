

class Gammalfiskare : Npc  //: Extend if there a class u inherited          iNpc for interface
{
  
    // public string? Prata;

    public override string Name => "Gammalfiskare";

    public override string[] Description => [
        "Du möter en kraftig man med stor omkrest i bringa",
        "En härjad man med stora underarmar"     


    ];
    
 
      public override string[] Actions =>
     [
         "Prata med Pudding:Talk"
     ];


//     public void Prata()
// {
//     Console.WriteLine("Pudding tittar på dig.");
//     Console.WriteLine("\"Jasså, vad gör du här?\"");
//     Console.ReadKey();
// }
    
// }
    
}