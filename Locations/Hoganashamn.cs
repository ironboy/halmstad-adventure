// Example location: shows state that changes the description,
// and how to hand over to an Npc's menu.

class Hoganashamn : Location
{
    private bool Trollmarks;
    private bool WentSouth;

    public override string Name => "Höganäs hamn";

    public override string[] Description => [
        !Trollmarks
        ? "Hamnen är full av båtar. Några turister har samlats runt ett avspärrat område." :
          "Kroppen förs vidare till rättsmedicin."
    ];

    public override string[] Actions => [
        "Prata med Omar:Omar",
        "Se dig omkring:Kolla"
    ];

    public void Omar()
    {
        if(!Trollmarks)
            Console.WriteLine("Vi borde se oss omkring efter ledtrådar.");
        else
            Console.WriteLine("Folket pratar om att det är \"Kullamannen\" som ligger bakom de försvunna personerna pga.rivsåren.");
        Console.ReadLine();
    }

    public void Kolla()
    {
        Trollmarks = true;
        Console.WriteLine("Ni ser den döda kroppen med sår som ser ut som stora rivsår.");
        Console.ReadLine();
        
    }

    public override void North()
    {
        if(WentSouth)
            base.North();
        else
        {
            Console.WriteLine(Trollmarks ? 
            "Omar Sjöberg: \"Vi borde gå syd till Rättsmedicin och få info om den döda kroppen.\"" 
            : "Omar Sjöberg: \"Vi borde kolla omkring hamnen lite mer.\"");
            Console.ReadLine();
        }
            
    }

    public override void West()
    {
        if(WentSouth)
            base.West();
        else
        {
            Console.WriteLine(Trollmarks ? 
            "Omar Sjöberg: \"Vi borde gå syd till Rättsmedicin och få info om den döda kroppen.\"" 
            : "Omar Sjöberg: \"Vi borde kolla omkring hamnen lite mer.\"");
            Console.ReadLine();
        }
            
    }

    public override void South()
    {
        if(Trollmarks)
        {
            WentSouth = true;
            base.South();
        }
        else
        {
            Console.WriteLine("Omar Sjöberg: \"Vi borde kolla omkring hamnen lite mer.\"");
            Console.ReadLine();   
        }
            
        
    }
    
}
