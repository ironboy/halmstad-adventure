class Painter : Npc
{
    private bool _gaveSketch;

    public override string Name => "Konstnären Leo";

    public override string[] Description => [
        _gaveSketch
            ? "Konstnären håller på att packa ihop sina saker."
            : "En konstnär sitter vid kajen med ett skissblock i händerna."
    ];

    public override string[] Actions => _gaveSketch
        ? ["Fråga igen:AskAgain"]
        : [
            "Fråga vad konstnären såg:AskWhatPainterSaw",
            "Fråga om skissen:AskAboutSketch",
            "Be att få skissen:AskForSketch"
        ];

    public void AskWhatPainterSaw()
    {
        Console.WriteLine(
            "\"Jag såg en kvinna på piren den kvällen. " +
            "Hon såg ut att försöka undvika att bli sedd.\""
        );
        Console.ReadLine();
    }

    public void AskAboutSketch()
    {
        Console.WriteLine(
            "\"Jag började skissa henne eftersom hennes beteende verkade märkligt. " +
            "Jag hann få med hennes utseende innan hon försvann.\""
        );
        Console.ReadLine();
    }

    public void AskForSketch()
    {
        _gaveSketch = true;
        Player.Inventory.Add("skiss");

        Console.WriteLine(
            "Konstnären tvekar ett ögonblick och räcker sedan över skissen."
        );
        Console.ReadLine();

        Menu.Close();
    }

    public void AskAgain()
    {
        Console.WriteLine(
            "\"Jag har redan berättat vad jag vet.\""
        );
        Console.ReadLine();
    }
}