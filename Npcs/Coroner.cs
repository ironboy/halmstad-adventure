// Example Npc: has its own menu, remembers what you've said to it.

class Coroner : Npc
{
    public bool GetReport;

    public override string Name => "Dr. Lindqvist";

    public override string[] Description => [
          "Dr. Lindqvist är djupt koncentrerad när du kommer in."
    ];

    public override string[] Actions => GetReport
        ? ["Prata med Dr Lindqvist:TalktToCoroner"]
        : ["Fråga om obduktionsrapporten:AskForReport"];

    public void AskForReport()
    {
        GetReport = true;
        Console.WriteLine("\"Rapporten ligger i skrivbordslådan.\"");
        Console.ReadLine();
        Menu.Close();   // the conversation is over – back to the room
    }

    public void TalkToCoroner()
    {
        Console.WriteLine("Jag är upptagen.");
        Console.ReadLine();
    }
}
