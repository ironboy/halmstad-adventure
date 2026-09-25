// Example location: shows state that changes the description,
// and how to hand over to an Npc's menu.

class Castle : Location
{
    private readonly CastleManager _castlemanager = new();
    private bool _searchclues;

    public override string Name => "Krapperups Slott";

    public override string[] Description => [
        "Slottet är stort med många gångar och rum, figuren syns inte till.",
        
        _searchclues ? "Du har redan letat igenom slottet." : "Figuren kanske gömmer sig i ett av rummen.",
        "En slottsförvaltare står i entrén."
    ];
    public override string[] Actions => [
        "Leta igenom slottet efter figuren:SearchForClues",
        "Prata med slottsförvaltaren:TalkToCastleManager"
    ];

    public void SearchForClues()
    {
        Console.WriteLine(_searchclues
            ? "Att leta igenom slottet igen gav inga nya ledtrådar."
            : "\"Leta igenom slottet efter figuren\" – Du ser övervakningskameror. slottsförvaltaren kanske har sett något.");
        _searchclues = true;
        Console.ReadLine();
    }

    // An item that opens ANOTHER object's menu: just call its Run()
    public void TalkToCastleManager()
    {
        _castlemanager.Run();
    }

    // Prevent going east until the guard is bribed
    public override void East()
    {
        if (!_searchclues)
        {
            Console.WriteLine("Du vet inte vart du ska leta härnäst");
            Console.ReadLine();
        }
        else if (!_castlemanager.CameraWatched)
        {
            Console.WriteLine("Jag borde fråga slottsförvaltaren om filmen från övervakningskameran.");
            Console.ReadLine();
        }
        else if(!_castlemanager.Threatened)
        {
            Console.WriteLine("Jag vet fortfarande inte vart figuren gick.");
            Console.ReadLine();
        }
        else
        {
            // call the super class ("base") East method (in Location)
            base.East();
        }
    }
}
