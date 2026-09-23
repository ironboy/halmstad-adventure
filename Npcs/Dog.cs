class Dog : Npc
{
    public bool Bribed;

    public override string Name => "Dog";

    public override string[] Description => [
        Bribed
            ? "Hunden ignorerar dig."
            : "\"woff woff! hunden skäller mot drivveden.\""
    ];

    public override string[] Actions => Bribed
        ? [] 
        : [
            "Vissla på hunden:VisslaTillHunden",
            "Offer a coin:Bribe"
          ];

    public void VisslaTillHunden()
    {
        Console.WriteLine("\"Hunden ignorerar dig, får testa något annat.\"");
        Console.ReadLine();
    }

    public void Bribe()
    {
        Bribed = true;
        Console.WriteLine("Hunden visar intresse för pinnen du håller i och följer efter dig.");
    }
}