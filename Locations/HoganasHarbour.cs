// Example location: shows state that changes the description,
// and how to hand over to an Npc's menu.

class HoganasHarbour : Location
{
    private bool Trollmarks;
    private bool WentNorth;

    public override string Name => "Höganäs hamn";

    public override string[] Description => [
        !Trollmarks
        ? "Hamnen är full av båtar. Några turister har samlats runt ett avspärrat område." :
          "Kroppen förs vidare till rättsmedicin."
    ];

    public override string[] Actions => [
        "Prata med Omar:TalkToOmar",
        "Se dig omkring:LookAround"
    ];

    public void TalkToOmar()
    {
        if(!Trollmarks)
            Console.WriteLine("Vi borde se oss omkring efter ledtrådar.");
        else
            Console.WriteLine("Folket pratar om att det är \"Kullamannen\" som ligger bakom de försvunna personerna pga.rivsåren.");
        Console.ReadLine();
    }

    public void LookAround()
    {
        Trollmarks = true;
        Console.WriteLine("Ni ser den döda kroppen med sår som ser ut som stora rivsår.");
        Console.ReadLine();
        
    }

    public override void South()
    {
        if(WentNorth)
            base.South();
        else
        {
            Console.WriteLine(Trollmarks ? 
            "Omar Sjöberg: \"Vi borde gå norrut till Rättsmedicin och få info om den döda kroppen.\"" 
            : "Omar Sjöberg: \"Vi borde kolla omkring hamnen lite mer.\"");
            Console.ReadLine();
        }
            
    }

    public override void West()
    {
        if(WentNorth)
            base.West();
        else
        {
            Console.WriteLine(Trollmarks ? 
            "Omar Sjöberg: \"Vi borde gå norrut till Rättsmedicin och få info om den döda kroppen.\"" 
            : "Omar Sjöberg: \"Vi borde kolla omkring hamnen lite mer.\"");
            Console.ReadLine();
        }
            
    }

    public override void North()
    {
        if(Trollmarks)
        {
            WentNorth = true;
            base.North();
        }
        else
        {
            Console.WriteLine("Omar Sjöberg: \"Vi borde kolla omkring hamnen lite mer.\"");
            Console.ReadLine();   
        }
            
        
    }
    
}
