class Hermit : Npc
{
    public bool AskAboutLight;

    public override string Name => "Hermit";

    public override string[] Description => [
        "En gammal man sitter vid en drivvedseld, med blicken fäst vid Nimis."
    ];

    public override string[] Actions => [
        "Ask about Nimis:AskAboutNimis",
        "Ask about the lighthouse:AskAboutLighthouse",
        "Leave:Leave"
    ];

    public void AskAboutNimis()
    {
       Console.WriteLine("\"\"");
       Console.ReadLine();
    }

    public void AskAboutLighthouse()
    {
        AskAboutLight = true;
        Console.WriteLine("\"\"");
        Console.ReadLine();
          
    }

    public void Leave()
    {
        Console.WriteLine("");
        Console.ReadLine();
        Menu.Close();
    }
}
