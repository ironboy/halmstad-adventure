// Example location: shows state that changes the description,
// and how to hand over to an Npc's menu.

class Höganäshamn : Location
{
    private readonly OmarSjöberg omarSjöberg = new();

    public override string Name => "Höganäshamn";

    public override string[] Description => [
        "Det är en hamn"
    ];

    public override string[] Actions => [
        "Prata med Omar:Omar",
        ":"
    ];

    public void Omar()
    {
        Console.WriteLine("");
        Console.ReadLine();
    }
    
}
