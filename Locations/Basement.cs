// 3b. BIBLIOTEKETS KÄLLARE – platsen där hembygdsforskaren sitter.
// Klassnamnet skrivs utan ä för att slippa teckenkodningsproblem i gruppen;
// Name (det spelaren ser) kan fortfarande ha svenska tecken.

class Basement : Location
{
    private readonly LocalHistorian _hembygdsforskaren = new();

    public override string Name => "Bibliotekets källare";

    public override string[] Description => [
        "Ett kallt, fuktigt rum under biblioteket. Ett stearinljus fladdrar.",
        _hembygdsforskaren.Bribed
            ? "Hembygdsforskaren nickar mot dig – ni har en överenskommelse."
            : "En skum man med spetsig hatt sitter böjd över gamla papper."
    ];

    public override string[] Actions => [
        "Se dig omkring:LookAround",
        "Prata med den skumma mannen:TalkToHembygdsforskaren"
    ];

    public void LookAround()
    {
        Console.WriteLine("Lådor med kartor, en gammal karta över Kullaberget på väggen.");
        Console.ReadLine();
    }

    public void TalkToHembygdsforskaren() => _hembygdsforskaren.Run();
}
