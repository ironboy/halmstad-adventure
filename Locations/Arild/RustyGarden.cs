

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
<<<<<<< HEAD

    public void LeaveHotel()
    {
        South();
    }

    // Hand over to the priest's own menu, like TalkToGuard in RuneRoom
    public void TalkToPriest() => _priest.Run();



    public override void LeaveHotel()

    { 
    if (!_receptionist.Bribed)

        {
            BlockedMessage();
        }
        else
        {
            base.South();
        }

    }
  
private void BlockedMessage()

    {
    Console.WriteLine("Du kan inte gå härifrån än. Prästen vet något - det känner du på dig");
    Console.ReadLine();
    }
}


=======
>>>>>>> 8ba71a190398857255b0f8dff3907ee7a430afdd
}