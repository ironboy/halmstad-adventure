// Example Npc: has its own menu, remembers what you've said to it.

class OmarSjöberg : Npc
{
    public override string Name => "Omar Sjöberg";

    public override string[] Description => [
        "Arbetskollega ifrån Helsingsborg"
    ];

    public override string[] Actions => [
        "Ask about the door:AskAboutDoor"
    ];

    public void AskAboutDoor()
    {
        Console.WriteLine("\"Locked. Has been for years. Move along.\"");
        Console.ReadLine();
    }
}
