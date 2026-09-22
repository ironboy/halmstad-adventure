// description: telefonsamtal till London

class DIHarrietBlake : Npc
{
    public bool Called;

    public override string Name => "Detective";

    public override string[] Description => [
        Called
            ? "Du får reda på att liknande mord har skett i London"
            : "Det står en telefon på skrivbordet."
    ];

    public override string[] Actions => Called
        ? ["Ring DI Harriet Blake igen:CallAgain"]
        : ["Ring DI Harriet Blake:Call"];
           


    public void Call()
    {
        Called = true;
        Console.WriteLine("Du plockar upp telefonen och ringer rättsmedicin i London \"Detta är DI Harriet Blake\"");
        Console.ReadLine();
        Menu.Close();   // the conversation is over – back to the room
    }

    public void CallAgain()
    {
        Console.WriteLine("Jag har inte tid med dig.");
        Console.ReadLine();
    }
}
