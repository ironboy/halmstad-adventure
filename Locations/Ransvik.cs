using System.Runtime.CompilerServices;
using System.Xml.Serialization;

class Ransvik : Location
{
    public override string Name => "Ransvik";

    private int talkCount;
    private bool storyTold;

    public bool Utredd => storyTold;

    public void TalkToBadgästen()
        {
            talkCount++;
            if (talkCount < 2)
            {
                Console.WriteLine("En ensam gäst ligger kvar i solstolen trots att kvällen redan blivit sval.");
                Console.WriteLine("Kunde inte sova, så jag smet ut hit för en cigarett, säger hon.");
            }
            else
            {
                Console.WriteLine("Hon nickar igenkännande åt dig.");
                Console.WriteLine("Tillbaka igen? Då kanske jag ska berätta vad jag faktiskt såg.");
            }
            Console.ReadLine();
}

    public void AskWhatSheSaw()
    {
        storyTold = true;
        Console.WriteLine("En sko. Bara en, nedanför klipporna. Likadana som damerna på Grand Hotel bär.");
        System.Console.WriteLine("Jag såg också ett ljus röra sig mot Mölle hamn ungefär samtidigt.");
        Console.ReadLine();
    }

    public void SmallTalk()
    {
        System.Console.WriteLine("Skönt väder ikväll.");
        Console.ReadLine();
    }

    

 public override string [] Description => [
        "HEJ OCH VÄLKOMMEN TILL RANSVIK",
        "Mat, hav och njutning här i vårat idyliska Ransvik",
        Utredd? "Du känner till platsen" : "En ensam badgäst ligger kvar i solstolen trots den sena kvällen"

    ];
public override string[] Actions => talkCount < 2
    ? ["Prata med badgästen:TalkToBadgästen"]
    : storyTold
        ? ["Prata om vädret:SmallTalk"]
        : ["Fråga vad hon sett:AskWhatSheSaw"];

    
   
}