class Fyren : Location
{
    public override string Name => "Fyren";

 private Jane _jane = new();
    private bool doorapproached = false;
    private bool insideLighthouse = false;
    public override string[] Description => [
        "Fyrljuset sveper över klipporna, och för ett ögonblick ser du en stor, mörk gestalt vid stupkanten.", 
        "När ljuset kommer tillbaka är den borta.",
        "Det är en vacker utsikt över havet och kusten det påminner om gåtan.",
        "Dimman ligger tät över Kullaberg." 
    ];

public override string[] Actions => [
         "Se dig omkring:LookAround",
        !doorapproached 
            ? "Gå fram till Fyren:ApproachLighthouse" 
            : !insideLighthouse
            ? "Öppna dörren till fyren:OpenLighthouseDoor"
            : "Prata med Jane:TalkToJane"
    ];

public void OpenLighthouseDoor()
    {
        Console.WriteLine("Du öppnar dörren till fyren och går in. Det är mörkt och tyst. Eva går upp för den smala trappan. Högst upp ser hon en kvinna som tittar ut över havet.");
        Console.ReadLine();
       insideLighthouse = true;
        
    }
public void LookAround()
    {
        if (!insideLighthouse)
        {
            Console.WriteLine("Du ser havet, klipporna och dimman som sveper in över Kullaberg.");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("En kvinna står vid fönstret högst upp i fyren, med jackan knäppt ända upp.","Hon vänder sig inte om. \"Jag visste att du skulle komma, kommissarien.\"");
            Console.ReadLine();
        }
    }


    public void ApproachLighthouse()
    {
        Console.WriteLine("Du går fram till fyren och ser en mystisk person vid kanten av stupet.");
        Console.ReadLine();
        doorapproached = true;
    }

    public void TalkToJane()
    {
        _jane.Run();
    }

}

