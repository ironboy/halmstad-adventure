class Harbour : Location
{
    private readonly Painter _painter = new();
    private bool _sketchReceived;

    public override string Name => "Arilds hamn";

    public override string[] Description => [
        "Den lilla hamnen ligger stilla under den grå himlen.",
        "Fiskebåtar guppar försiktigt vid bryggorna.",
        _sketchReceived
            ? "Du har redan fått konstnärens skiss."
            : "En konstnär står en bit bort och skissar på ett papper."
    ];

    public override string[] Actions => [
        "Titta runt:LookAround",
        "Prata med konstnären:TalkToPainter"
    ];

    public void LookAround()
    {
        Console.WriteLine(
            "Du ser fiskebåtar, gamla träbryggor och en konstnär " +
            "som verkar vara koncentrerad på sitt arbete."
        );
        Console.ReadLine();
    }

    public void TalkToPainter()
    {
        if (_sketchReceived)
        {
            Console.WriteLine("Konstnären fortsätter att arbeta på sin nästa skiss.");
            Console.ReadLine();
            return;
        }

        _painter.Run();

        if (Player.Has("skiss"))
        {
            _sketchReceived = true;
        }
    }
}