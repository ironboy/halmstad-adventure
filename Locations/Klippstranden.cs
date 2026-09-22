// KLAR!

class Klippstranden : Location
{
    private bool _beachSearched;

    public override string Name => "Klippstranden";

    public override string[] Description => [
        "En synerligen tom strand, vid drivvedstornet ses hunden leka.",
        _beachSearched ? "Hunden drar i ved" : "Hunden verkar hittat något"
    ];

    public override string[] Actions => _beachSearched
        ? ["Look around:LookAround"]
        : [
            "Look around:LookAround",
           "Search the beach: SearchBeach",
           "-Reach in:TakeNote",
           "-Leave it:LeaveIt"];

    public void LookAround()
    {
        Console.WriteLine("Flera lösa drivvedsbitar, svårta att se, hunden börjar gräva vänster om dig.");
        Console.ReadLine();
    }

    public void SearchBeach()
    {
        Console.WriteLine("Du letar igenom stranden och hittar en spricka i drivveden.");
        Console.ReadLine();
    }

    public void TakeNote()
    {
        _beachSearched = true;
        Player.Inventory.Add("dagbokssida");
        Console.WriteLine("Du hittade en dagbokssida!");
        Console.ReadLine();
        Menu.Close();   // close the submenu – the Actions list has changed
    }

    public void LeaveIt()
    {
        Console.WriteLine("You leave it. For now.");
        Console.ReadLine();
    }
}
