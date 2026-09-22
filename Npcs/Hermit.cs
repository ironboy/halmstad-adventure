class Hermit : Npc
{
    public bool AskAboutLight;

    public override string Name => "Hermit";

    public override string[] Description => [
        "En gammal man sitter vid en elden, med blicken fäst vid Nimis."
    ];

    public override string[] Actions => [
        "Ask about Nimis:AskAboutNimis",
        "Ask about the lighthouse:AskAboutLighthouse",
        "Leave:Leave"
    ];

    public void AskAboutNimis()
    {
       Console.WriteLine("\"Nimis bara står,\" säger han\" Jag ser bara till att det förblir så\"");
       Console.ReadLine();
    }

    public void AskAboutLighthouse()
    {
        AskAboutLight = true;
        Console.WriteLine("\"Det har lyst i fyren på nätterna. Det borde inte göra det. Ingen bor där längre\"");
        Console.ReadLine();
          
    }

    public void Leave()
    {
        Console.WriteLine("Eremiten vänder sig tillbaka mot elden");
        Console.ReadLine();
        Menu.Close();
    }
}
