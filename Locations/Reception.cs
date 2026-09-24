// 2b. RECEPTIONEN – platsen där bibliotekarien står.
// Samma mönster som RuneRoom: platsen ÄGER en NPC och öppnar hennes meny med Run().

class Reception : Location
{
    private readonly Bibliotekarien _bibliotekarien = new();

    public override string Name => "Receptionen";

    public override string[] Description => [
        "En disk av mörkt trä med en gammal utlåningsliggare.",
        "Bakom disken står bibliotekarien och sorterar lånekort."
    ];

    public override string[] Actions => [
        "Se dig omkring:LookAround",
        "Prata med bibliotekarien:TalkToBibliotekarien"
    ];

    public void LookAround()
    {
        Console.WriteLine("En hög med återlämnade böcker. En lucka i hyllan där något saknas.");
        Console.ReadLine();
    }

    // En Action som öppnar ETT ANNAT objekts meny: anropa bara dess Run()
    public void TalkToBibliotekarien() => _bibliotekarien.Run();
}
