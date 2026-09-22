class Nimis : Location
{
    public override string Name => "Nimis";

public override string[] Description => [
    "-----------------------",
    "Vid elden sitter en eremit."
];

public override string[] Actions => [
    "Look around:LookAround",
    "Talk to the hermit:TalkToHermit"
];

public void LookAround()
{
    Console.WriteLine();
    Console.ReadLine();
}

public void TalkToHermit()
{
   
}

}

