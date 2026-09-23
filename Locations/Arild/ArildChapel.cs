// Arild chapel: the priest won't talk until you bring him wine from the rack.
// Based on the RuneRoom example (state that changes the description + Npc menu).

using System.Runtime.CompilerServices;

class ArildChapel : Location
{
    private readonly ArildPriest _priest = new();
    private bool _wineTaken;
    private int _searchCount;

    public override string Name => "Arilds kapell";

    public override string[] Description => [
        "Ett litet stenkapell på en kulle i byns utkant,",
        "med mossiga väggar och ett slitet klocktorn.",
        "Därinne står enkla träbänkar i det dunkla ljuset från höga fönster,",
        "och vid altaret vakar en stilla staty av Gudinnan.",
        _wineTaken
            ? "Vinhyllan i hörnet är nu helt tom."
            : "I ett hörn står en vinhylla med dammiga flaskor – märkligt många av dem redan tomma.",
        "En fridfull plats där tiden tycks gå lite långsammare."
    ];

    // Menu show 2 option, either talk with priest or go to winerack.
    public override string[] Actions => [
        "Prata med prästen:TalkToPriest",
        "Gå till vinhyllan:WineRack"
    ];

    public void WineRack()
    {
        if (_wineTaken)
        {
            Console.WriteLine("Bara tomma flaskor kvar. Någon här har god törst.");
            Console.ReadLine();
            return;
        }

        _searchCount++;

        //1 in 3 chance each search, but always found the 4th try

        bool found = (_searchCount > 1 && Random.Shared.Next(3) == 0) || _searchCount >= 4;

        if (found)

            {
            Console.WriteLine("Längst in hittar du en oöppnad flaska rött. Du tar den med dig.");
            _wineTaken = true;
            _priest.HasWine = true;   // now the priest menu shows "ge prästen vinet"
            } 
            else 
            {
        
            Console.WriteLine($"[Försök {_searchCount}] Du lyfter flaska efter flaska. Tom... Tom... Tom...");

        }
        Console.ReadLine();

    }

    

    // Hand over to the priest's own menu, like TalkToGuard in RuneRoom
    public void TalkToPriest() => _priest.Run();



    public override void North()

    { 
    if (!_priest.Bribed)

        {
            BlockedMessage();
        }
        else
        {
            base.North();
        }

    }
    public override void East()
    {
    if (!_priest.Bribed)

        {
            BlockedMessage();
        }    
    else
        {
        base.East(); 
        }

    
    }
private void BlockedMessage()

    {
    Console.WriteLine("Du kan inte gå härifrån än. Prästen vet något - det känner du på dig");
    Console.ReadLine();
    }
}