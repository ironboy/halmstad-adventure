// location: beskrivning av rummet och skrivbordslåda med obtuktionsrapporten i

class Forensic : Location
{
    private bool _deskSearched;

    private Coroner _coroner = new();

    private DIHarrietBlake _harriet = new();

    public override string Name => "Rättsmedicin";

    public override string[] Description => [
        !_deskSearched
        ? "Ett kalt rum med kaklade väggar och inbyggda likkylar. Intill en annan vägg står ett skrivbord med en svag lampa som lyser.":
        "Det påminner dig om några mord som skett i London, du bestämmer dig för att ringa DI Harriet Blake"
    ];

public override string[] Actions => !_coroner.GetReport ? [
        "Se dig omkring:LookAround",
        "Prata med Dr.Lindkvist:TalkToCoroner"
  ] : !_deskSearched ? [
        "Se dig omkring:LookAround",
        "Prata med Dr.Lindkvist:TalkToCoroner",
        "Titta på skrivbordet",
        "-Öppna lådan:TakeReport",
        "-Lämna lådan:LeaveIt"
  ] : [
        "Se dig omkring:LookAround",
        "Prata med Dr.Lindkvist:TalkToCoroner",
        "Ring Harriet Blake:CallHarriet"
  ];

    public void TakeReport()
    {
        _deskSearched = true;
        _coroner.ReportTaken = true;
        Player.Inventory.Add("obduktionsrapport");
        Console.WriteLine("Det står att skärsåren är gjorda av kirurgiska knivar. Du tar med dig obduktionsrapporten.");
        Console.ReadLine();
        Menu.Close();   // close the submenu – the Actions list has changed
    }

    public void LeaveIt()
    {
        Console.WriteLine("Du undersöker inte skrivbordslådan... än.");
        Console.ReadLine();
    }

    public void TalkToCoroner()
    {
        _coroner.Run();
    }

    public void LookAround()
    {
        Console.WriteLine("Litta döingar...");
        Console.ReadLine();
    }

    public void CallHarriet()
    {
        _harriet.Run();
    }

}
