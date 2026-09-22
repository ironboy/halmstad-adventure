// Example location: shows state that changes the description,
// and how to hand over to an Npc's menu.

class Höganäshamn : Location
{
    private bool Trollmarks;
    private bool WhentSouth;

    public override string Name => "Höganäshamn";

    public override string[] Description => [
        "Det är en hamn"
    ];

    public override string[] Actions => [
        "Prata med Omar:Omar",
        "Kolla om kring:Kolla"
    ];

    public void Omar()
    {
        if(!Trollmarks)
            Console.WriteLine("Vi borde kolla omkring efter ledtrådar om de personerna som har försvunnit");
        else
            Console.WriteLine("Folket pratar om att det är \"Kullamannen\" som ligger bakom de försvunna personerna.");
        Console.ReadLine();
    }

    public void Kolla()
    {
        Console.WriteLine("Efter du har kollat omkring hamnen en stund hittar du en död person.");
        Trollmarks = true;
    }

    public override void North()
    {
        if(WhentSouth)
            base.North();
        else
            Console.WriteLine(Trollmarks ? 
            "Omar Sjöberg: \"Vi borde gå syd till Rättsmedicin och få info om den döda kroppen.\"" 
            : "Omar Sjöberg: \"Vi borde kolla omkring hamnen lite mer.\"");
    }

    public override void West()
    {
        if(WhentSouth)
            base.West();
        else
            Console.WriteLine(Trollmarks ? 
            "Omar Sjöberg: \"Vi borde gå syd till Rättsmedicin och få info om den döda kroppen.\"" 
            : "Omar Sjöberg: \"Vi borde kolla omkring hamnen lite mer.\"");
    }

    public override void East()
    {
        if(WhentSouth)
            base.East();
        else
            Console.WriteLine(Trollmarks ? 
            "Omar Sjöberg: \"Vi borde gå syd till Rättsmedicin och få info om den döda kroppen.\"" 
            : "Omar Sjöberg: \"Vi borde kolla omkring hamnen lite mer.\"");
    }

    public override void South()
    {
        if(Trollmarks)
        {
            WhentSouth = true;
            base.South();
        }
        else 
            Console.WriteLine("Omar Sjöberg: \"Vi borde kolla omkring hamnen lite mer.\"");
        
    }
    
}
