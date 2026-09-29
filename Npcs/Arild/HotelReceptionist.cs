class HotelReceptionist : Npc
{

    private bool hasSaidNo = false;

    public bool Bribed;
    public override string Name=>"Hotellreceptionisten Rachael";

    public override string[] Description => [
        "Receptionisten ser trött och hängig ut",
        "Hon kopplar på sitt service-smile:",
        "\"Hur kan jag hjälpa dig?\""
    ];

    public override string[] Actions => [
        (!hasSaidNo ? 
            "\"Kan du berätta om vem som checkade in igår kväll?\":TellAboutYesterdaysGuests":
            "\"Det gäller ett mord\":AboutAMurder"),
    ];

    public void TellAboutYesterdaysGuests()
    {
        Console.WriteLine("\"Jag berättar aldrig om våra gäster.\"");
        hasSaidNo = true;
        Console.ReadLine();
    }

    public void AboutAMurder()
    {
        Console.WriteLine("\"Okej då kan jag göra ett undantag, igår checkade en lång man in i ett singelrum och lite senare gjorde en kvinna samma sak, dock väldigt sent på kvällen\"");
        Console.ReadLine();
        
    }
}