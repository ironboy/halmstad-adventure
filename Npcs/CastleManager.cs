// Example Npc: has its own menu, remembers what you've said to it.

using System.Collections.Concurrent;

class CastleManager : Npc
{
    // Set by Castle right before Run(), so the manager knows whether
    // the player has searched the castle yet (that's where the cameras are found).
    private bool _castleSearched;
    private bool _askedAboutCamera;
    private bool _threatened;
    private bool _cameraWatched;
    public bool Threatened => _threatened;
    public bool CameraWatched => _cameraWatched;

    public override string Name => "Slottsförvaltare";

    public override string[] Description => [
        !_castleSearched
            ? "Slottsförvaltaren nickar kort men verkar upptagen med annat. Jag borde leta efter ledtrådar först."
            : _cameraWatched
                ? "Slottsförvaltaren ler stelt."
                : _threatened
                    ? "Slottsförvaltaren muttrar argt för sig själv."
                    : _askedAboutCamera
                        ? "Slottsförvaltaren korsar armarna."
                        : "Slottsförvaltaren möter dig i entrén. \"Hur kan jag stå till tjänst?\""
    ];

    public override string[] Actions =>
        !_castleSearched ? ["Fråga om hjälp:AskBeforeSearch"]
        : _askedAboutCamera ? ["Hota med att stänga ner slottet under utredningen:Threaten"]
        : ["Fråga om att få se övervakningsfilmen:AskAboutCamera"];

    public void MarkCastleSearched() => _castleSearched = true;

    public void AskBeforeSearch()
    {
        Console.WriteLine("\"Jag kan inte hjälpa dig med något förrän du vet vad du letar efter. " +
            "Leta igenom slottet ordentligt först.\"");
        Console.ReadLine();
        Menu.Close();   // back to the room – nothing more to do here yet
    }

    public void AskAboutCamera()
    {
        _askedAboutCamera = true;
        Console.WriteLine("\"Det kan jag tyvärr inte visa dig. Det handlar om våra gästers integritet.\"");
        Console.ReadLine();
    }

    public void Threaten()
    {
        _threatened = true;
        _cameraWatched = true;
        Console.WriteLine("\"Om du inte visar mig filmen får jag stänga ner slottet under hela utredningen.\"");
        Console.WriteLine("Slottsförvaltaren suckar. \"Okej, okej... Kom, jag visar dig filmen.\"");
        Console.WriteLine("Du ser figuren på övervakningskameran – den bad om vägbeskrivning till biblioteket.");
        Console.ReadLine();
        Menu.Close();
    }
}
