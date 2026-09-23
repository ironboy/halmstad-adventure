class Nimis : Location
{
    public override string Name => "Nimis";

    private readonly Hermit _hermit = new();

public override string[] Description => [
   "Trätorn reser sig längs klippkanten, byggda av drivved och gamla plankor.",
    "En eremit sitter vid en liten eld nära Nimis fot, med blicken mot havet."
];

public override string[] Actions => [
    "Se dig omkring:LookAround",
    "Prata med eremiten:TalkToHermit"
];

public void LookAround()
{
    Console.WriteLine("Tornen knakar i vinden. Nedanför slår vågorna mot klipporna.");
    Console.WriteLine("Långt österut skymtar Kullens fyr genom disen.");
    Console.ReadLine();
}

public void TalkToHermit() => _hermit.Run();


}

