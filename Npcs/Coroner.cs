// Example Npc: has its own menu, remembers what you've said to it.

class Coroner : Npc
{
    public bool GetReport;

    public bool CauseOfDeath;

    public override string Name => "Dr. Lindqvist";

    public override string[] Description => [
        GetReport
        
            ? "The guard pretends not to see you."
            : "Dr. Lindqvist är djupt koncentrerad när du kommer in."
    ];

    public override string[] Actions => GetReport
        ? ["Wink:Wink"]
        : ["Fråga om dödsorsaken:AskAboutCoD",
           "Fråga om obduktionsrapporten:AskForReport"];

    public void AskAboutCoD()
    {
        CauseOfDeath = true;
        Console.WriteLine("\"Skadorna är gjorda med en kirurgisk kniv, inte av några trollklor.\"");
        Console.ReadLine();
        
    }

    public void AskForReport()
    {
        GetReport = true;
        Console.WriteLine("\"Rapporten ligger i skrivbordslådan.\"");
        Console.ReadLine();
        Menu.Close();   // the conversation is over – back to the room
    }

    public void Wink()
    {
        Console.WriteLine("Jag är upptagen.");
        Console.ReadLine();
    }
}
