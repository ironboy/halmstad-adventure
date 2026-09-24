// SLOTTSBIBLIOTEKET – entrén, i mitten av bibliotekets karta.
// Bara titta och gå vidare. Utgångarna skapas automatiskt av World utifrån
// vilka rutor som ligger bredvid i Game.cs:
//   väster = Gång 5, öster = Receptionen, söder = Källaren.
//
// NYTT: vägen västerut till Gång 5 är spärrad tills spelaren fått tipset
// av hembygdsforskaren. Samma mönster som RuneRoom.East(), men vi frågar
// Player istället för en NPC – forskaren bor ju i ett annat rum.

class CastleLibrary : Location
{
    public override string Name => "Slottsbiblioteket";

    public override string[] Description => [
        "Höga valv, dammig luft och hyllor så långt ögat når.",
        "Österut ligger receptionen. En smal stentrappa leder ner söderut mot källaren.",
        Player.Has("tips om gång 5")
            ? "Repet framför Gång 5 i väster är nedtaget."
            : "Ett rött rep spärrar av Gång 5 i väster. \"Endast behörig personal.\""
    ];

    public override string[] Actions => [
        "Se dig omkring:LookAround"
    ];

    public void LookAround()
    {
        Console.WriteLine("Porträtt av gamla slottsherrar stirrar ner från väggarna.");
        Console.WriteLine("Det är tyst... bara ljudet av en bok som stängs någonstans i receptionen.");
        Console.ReadLine();
    }

    // Spärra västerut tills spelaren vet vad hen letar efter i Gång 5
    public override void West()
    {
        if (!Player.Has("tips om gång 5"))
        {
            Console.WriteLine("Du lyfter på repet, men vad letar du ens efter bland tusentals böcker?");
            Console.WriteLine("Någon här borde veta mer.");
            Console.ReadLine();
        }
        else
        {
            base.West();   // gör den vanliga förflyttningen (koden i Location)
        }
    }
}
