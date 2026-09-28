class Fyren : Location
{
    public override string Name => "Fyren";
    private bool doorapproached = false;
    public override string[] Description => [
        "Fyrljuset sveper över klipporna, och för ett ögonblick ser du en stor, mörk gestalt vid stupkanten.", 
        "När ljuset kommer tillbaka är den borta.",
        "Det är en vacker utsikt över havet och kusten det påminner om gåtan.",
        "Dimman ligger tät över Kullaberg." 
    ];

public override string[] Actions => [
        !doorapproached ? "Gå fram till Fyren:ApproachLighthouse" : "Öppna dörren till fyren:OpenLighthouseDoor",
        "Se dig omkring:LookAround"
    ];

public void OpenLighthouseDoor()
    {
        Console.WriteLine("Du öppnar dörren till fyren och går in. Det är mörkt och tyst.");
        Console.ReadLine();
        doorapproached = true;
    }
public void LookAround()
    {
        Console.WriteLine("Du ser havet, klipporna och dimman som sveper in över Kullaberg.");
        Console.ReadLine();
    }


    public void ApproachLighthouse()
    {
        Console.WriteLine("Du går fram till fyren och ser en mystisk person vid kanten av stupet.");
        Console.ReadLine();
        doorapproached = true;
    }
}

