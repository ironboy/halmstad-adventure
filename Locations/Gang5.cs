// 4. GÅNG 5 – här finns gåtan.
// Den här platsen kan inte se hembygdsforskarens Bribed-fält (han bor i Kallare),
// så den frågar Player istället: har spelaren fått tipset?

class Gang5 : Location
{
    private bool _bookFound;
    private bool _riddleRead;

    public override string Name => "Gång 5 i biblioteket";

    public override string[] Description => [
        "En lång, ekande biblioteksgång.",
        _bookFound
            ? "Boken om Kullamannen ligger uppslagen framför dig."
            : "Böcker står kant i kant på hyllorna på båda sidor."
    ];

    // Tre lägen: inget tips → leta förgäves, tips → hitta boken, bok hittad → läs.
    public override string[] Actions => _bookFound
        ? ["Läs sista kapitlet:ReadRiddle"]
        : Player.Has("tips om gång 5")
            ? ["Leta på översta hyllan:FindBook"]
            : ["Leta bland hyllorna:SearchBlindly"];

    public void SearchBlindly()
    {
        Console.WriteLine("Tusentals böcker. Utan att veta var du ska leta är det hopplöst.");
        Console.WriteLine("Kanske vet någon i biblioteket mer?");
        Console.ReadLine();
    }

    public void FindBook()
    {
        _bookFound = true;
        Console.WriteLine("Längst in på översta hyllan: ett slitet exemplar av boken om Kullamannen!");
        Console.ReadLine();
        Menu.Close();   // Actions har ändrats
    }

    public void ReadRiddle()
    {
        Console.WriteLine("Någon har strukit under en rad med blyerts:");
        Console.WriteLine();
        Console.WriteLine("  \"Där berget möter havet vakar ett öga som aldrig sover.");
        Console.WriteLine("   Det vaknar när solen somnar. Sök mig där ljuset vandrar.\"");
        Console.WriteLine();
        if (!_riddleRead)
        {
            Player.Inventory.Add("gåtan om fyren");   // nästa grupps plats kan kolla detta
            _riddleRead = true;
        }
        Console.ReadLine();
    }
}
