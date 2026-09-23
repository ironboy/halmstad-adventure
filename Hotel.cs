class  Hotel: Location
{
 
    public Receptionist _receptionist = new();
     
    private List<string> _ledgerEntries = [
        "Härligt att vara här igen. Erika & Erik",
        "A nice place for a murder. Jane <3",
        "The most wonderful place i've been too"
    ];
 
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
          "Prata med receptionisten Lisa:TalkToReceptionist",
        
         
     ];
 
     
    public void LookIntoLedger()
    {
        if(_receptionist.AllowsLookInLedger){
            // How to stop if Lisa doesn't allow?
            Console.WriteLine(string.Join("\n",_ledgerEntries));
        }
        else
        {
            Console.WriteLine("Receptionisten Lisa hoppar fram och slår igen liggaren.");
        }
        Console.ReadLine();    
    }
 
    public void TalkToReceptionist()
    {
        _receptionist.Run();
    }
}



// 