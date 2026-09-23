// location: beskrivning av rummet och skrivbordslåda med obtuktionsrapporten i

class Forensic : Location
{
    private bool _deskSearched;
    private bool _calledHarriet;

    private Coroner _coroner = new();

    public override string Name => "Rättsmedicin";

    public override string[] Description => [
        "Ett kalt rum med kaklade väggar och inbyggda likkylar. Intill en annan vägg står ett skrivbord med en svag lampa som lyser.",
        _deskSearched ? "Byrålådan är tom." : "I byrålådan hittar du en obduktionsrapport."
    ];

/*public override string[] Actions => !_deskSearched
        ? ["Se dig omkring:LookAround",
         "Titta på skrivbordet:",
           "-Öppna lådan:TakeRapport",
           "-Lämna lådan:LeaveIt"]
        :

        ? ["Se dig omkring:LookAround",
        "Ring Harriet Blake:CallHarriet"
        ]
        :["Prata med Dr.Lindkvist:TalkToCoroner"
        ];*/

public override string[] Actions => !_coroner.GetReport ? [
        "Se dig omkring:LookAround",
        "Prata med Dr.Lindkvist:TalkToCoroner"
  ] : !_deskSearched ? [
      "Titta på skrivbordet",
      "-Öppna lådan:TakeReport",
      "-Lämna lådan:LeaveIt"
  ] : [
     "Ring Harriet Blake:CallHarriet"
  ];

    public void TakeReport()
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

    public void TalkToCoroner()
    {
        _coroner.Run();
    }

    public void LookAround()
    {
        Console.WriteLine("Litta döingar...");
        Console.ReadLine();
    }

}
