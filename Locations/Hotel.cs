class GrandHotel : Location
{


    public List<string> _ledgerEntries = [ // public so receptionist can get it
        "På första sidan ser du hälsningmeddelanden vad föregående besökare lagt till i liggaren och vilket datum de checkade in.",
        "Härligt att vara här igen. Erika & Erik (Datum)",
        "A nice place to \"kill\" some time. / Jack <3 me (Datum)",
        "The most wonderful place i've been too! cheers (Datum) \x1b[3mJessica\x1b[23m", // yeah that is one juicy code. So start italic and end italic. Also knowned as ANSI formating codes
    ];

    public Receptionist _receptionist; // we are making the list accesible for the recptionist, so whe can use it in the class
                                       // public Badgäst _badgäst;
    public GrandHotel()
    {
        _receptionist = new Receptionist(_ledgerEntries); // 
        // _badgäst = new Badgäst();
    }
    public override string Name => "Grand Hotell";

    public override string[] Description => [
         "Upplev ett anrikt och fyrstjärnigt hotell mittemot det storslagna havet!",
          "är beskrivningen som möter dig",
          "Skrivet på den stora tavlan utanför receptionen"

    //"Välkommna till ett 4 stjärningt hotel, upplev anrik historia",
    // "Njut av härliga promenader eller historiksa monument med det stroslagna havet som din kompanjon mittemot!",
    // "Står det på den stora tavlan framför Grand Hotel" alt.
    ];

    public override string[] Actions => [
         "Titta i hotelliggaren:LookIntoLedger",
          "Prata med receptionisten Louise:TalkToReceptionist",
          //"Prata med badgästen Erik:TalkToBadgäst",
        
        
         
     ];


    public void LookIntoLedger()
    {
        if (_receptionist.AllowsLookInLedger)
        {
            // How to stop if Lisa doesn't allow?
            Console.WriteLine(string.Join("\n", _ledgerEntries));
        }
        else
        {
            Console.WriteLine("Receptionisten Louise hoppar fram och slår igen liggaren.");
        }
        Console.ReadLine();
    }

    public void TalkToReceptionist()
    {
        _receptionist.Run();
    }
}
//     public void TalkToBadgäst()
//     {
//         _badgäst.Run();
//     }

// }



// 