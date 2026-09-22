 class Himmelstorp : Location
 {
     private readonly Hikers _hikers = new();
    

     public override string Name => "Himmelstorp";

     public override string[] Description => [
         "En stor bokskog breder ut sig runt Eva.",
         "Två vandrare står framför henne på stigen."
     ];

     public override string[] Actions => [
         "Prata med hikers:TalkToHikers"
     ];

    public void TalkToHikers() => _hikers.Run();

    public override void East()
    {
            Console.WriteLine("Vandrarna: Våran hund sprang iväg från oss, kan du hjälpa oss att hitta honom?");
            Console.ReadLine();
    }
}
