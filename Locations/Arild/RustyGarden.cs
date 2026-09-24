

class RustyGarden : Location
{
    // Create an instance of the npc (HotelReceptionist) as a field (_receptionist)
    private HotelReceptionist _receptionist = new();
    public override string Name => "Rostiga gården";

    public override string[] Description => [
     "Du går in i det dystra tomma hotellet Rostiga gården.",
     "Det ända du ser är hotellrecpetionisten sittandes ensam bakom recpetionen"
    ];

    public override string[] Actions => [
        "Gå fram till Hotellreceptionsten:TalkToHotelReceptionist",
        "Kolla runt:LookAround",
        "Lämna Hotell:LeaveHotel"
    ];

    public void TalkToHotelReceptionist()
    {
        _receptionist.Run();
    }

    public void LookAround()
    {
        Console.WriteLine("Inget särskilt här, som vilket landsortshotell som helst.");
        Console.ReadLine();
    }

    public void LeaveHotel()
    {
        // Ska antingen (North, West, East, South)
        // Måste lägga till gruppens andra locations och väderstreck
    }

}