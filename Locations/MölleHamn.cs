class MölleHamn : Location
{
   public override string Name  => "MölleHamn";
    private bool Searchtheabadonedshed;
    public override string[]  Description => [
            "Du anländer till en molloken syn vid Möllehamn, du känner hur det börjar blåsa upp till storm och vill ta dig innomhus snart",
            "Det finns en hint av olja och fisk-lukt i luften"//vinden
        
    ];
    public override string[] Actions => Searchtheabadonedshed
        ? ["Look around: LookAround"] // so this is a way to makle an if and else, cant make an else if tho ? :
        : ["Look around: LookAround",
            "Search the shed",
            "-Go in and search:Take the hook with the stain of blood",
            "-Leave the area:LeaveIt"];
      }