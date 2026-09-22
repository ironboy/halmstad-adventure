// Example location with a submenu (the "-" lines) and an item that disappears.
// The key goes into Player.Inventory so other locations can check for it.

class Forensic : Location
{
    private bool _deskSearched;

    public override string Name => "Rättsmedicin";

    public override string[] Description => [
        "Ett kalt rum med kaklade väggar och inbyggda likkylar. Intill en annan vägg står ett skrivbord med en svag lampa som lyser.",
        _deskSearched ? "Byrålådan är tom." : "I byrålådan hittar du en obduktionsrapport."
    ];

    public override string[] Actions => _deskSearched
        ? ["Look around:LookAround"]
        : ["Look around:LookAround",
           "Search the deskDrawer",
           "-Reach in:TakeRapport",
           "-Leave it:LeaveIt"];

    public void LookAround()
    {
        Console.WriteLine("Det finns lådor under skrivbordet och en skrivbordstol med en kavaj hängd över.");
        Console.ReadLine();
    }

    public void GetAuthopsyRapport()
    {
        _deskSearched = true;
        Player.Inventory.Add("obduktionsrapport");
        Console.WriteLine("Obduktionsrapporten pekar på att 'rivmärkena' är gjorda med en kirurgkniv.");
        Console.ReadLine();
        Menu.Close();   // close the submenu – the Actions list has changed
    }

    public void LeaveIt()
    {
        Console.WriteLine("Du undersöker inte skrivbordslådan... än.");
        Console.ReadLine();
    }
}
