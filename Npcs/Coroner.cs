// Example Npc: has its own menu, remembers what you've said to it.

using System.Collections.Concurrent;

class Coroner : Npc
{
    public bool GetReport;

    public bool ReportTaken;

    public override string Name => "Dr. Lindqvist";

    public override string[] Description => [
          "Dr. Lindqvist är djupt koncentrerad när du kommer in."
    ];

    public override string[] Actions =>
        ["Prata med Dr Lindqvist:TalkToCoroner",
        "Fråga om obduktionsrapporten:AskForReport"];

    public void AskForReport()
    {
        GetReport = true;
        Console.WriteLine("\"Rapporten ligger i skrivbordslådan.\"");
        Console.ReadLine();
        Menu.Close();   // the conversation is over – back to the room
    }

    public void TalkToCoroner()
    {
        if (!GetReport)
        {
            Console.WriteLine("Jag är upptagen");
            Console.ReadLine();
        }
        else if (!ReportTaken)
        {
            Console.WriteLine("Kroppen är obducerad.");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Jag har annat jag behöver jobba med nu.");
            Console.ReadLine();
        }
    }
}
