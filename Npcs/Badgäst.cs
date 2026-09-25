
class Badgäst : Npc
{
    public Badgäst()
    {

    }
        public override string Name => "Badgästen Erik";
        public override string[] Description =>
        [
            "En misstänksam gäst står i hotellobbyn.",
            "Vem var den misstänksamma gästen."
        ];

        public override string[] Actions => [
            "1. Vad gör du här på hotellet?",
            "2. Såg du något misstänksamt igår kväll?"
        ];
        public void TalkAboutHotel()
    
    {
        Console.WriteLine("Jag har sett en misstänsam gäst i hotellet.");
    }
    public void TalkAboutGuest()
    {
        Console.WriteLine("Jag såg gästen gå mot Ransvik igår kväll.");
        Console.WriteLine("Han verkade ha väldigt bråttom.");
    }
    public override void Run()
    {
        foreach (string action in Actions)
        {
            Console.WriteLine(action);
        }
        string? choice = Console.ReadLine();

        if (choice == "1")
        {
            TalkAboutHotel();
        }
        else if (choice == "2")
        {
            TalkAboutGuest();
        }
        else
        {
            Console.WriteLine("Ogiltigt val. ");
        }


    }
    
    
}