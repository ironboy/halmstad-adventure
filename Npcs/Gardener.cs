class Gardener : Npc
{
    public bool disturbed;

    public override string Name => "Gardener";

    public override string[] Description => [
        disturbed
            ? "Trädgårdsmästaren blänger på dig."
            : "\"Gå inte på gräset!\""
    ];

    public override string[] Actions => disturbed
        ? ["Backa:Backa"]
        : ["Fråga om misstänkta:AskAboutVisitors",
           "Visa polisbricka:ShowBadge"];

    public void AskAboutVisitors()
    {
        Console.WriteLine("\"Jag pratar inte med poliser, lämna mig\"");
        Console.ReadLine();
    }

    public void ShowBadge()
    {
        disturbed = true;
        Console.WriteLine("Stressade ögon \"Vad vill du veta kommensarie?\"");
        Console.ReadLine();
        Console.WriteLine("Trädgårdsmästaren berättar om en kvinna som kom och smög in i slottet.");
        Console.ReadLine();
        Menu.Close();
    }

    public void Backa()
    {
        Console.WriteLine("Du backar undan och lämnar trädgårdsmästaren ifred.");
        Console.ReadLine();
        Menu.Close();
    }
}