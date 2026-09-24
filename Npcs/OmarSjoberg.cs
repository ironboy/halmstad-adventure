// Example Npc: has its own menu, remembers what you've said to it.

using System.Collections;

class OmarSjoberg : Npc
{
    public override string Name => "Omar Sjöberg";

    bool introduction;
    bool askedAboutCase;

    public override string[] Description =>  [ !introduction || askedAboutCase
       ? "Skeptisk kollega på polisstationen i Höganäs."
       : "Jag förstod det..",
    ];

    public override string[] Actions => !introduction ? [
        "Presentera dig för Omar:IntroduceYourself"
    ] :
        !askedAboutCase ? [
        "Be om updatering i fallet:AskAboutCase"
    ] :
    [
        "Prata med Omar:TalkToOmar"
    ];
      
    public void IntroduceYourself()
    {
        introduction = true;
        Console.WriteLine("Hej! Det är jag som är Eva Nylén från Helsingborgspolisen.");
        Console.ReadLine();
    }


    public void AskAboutCase()
    {
        askedAboutCase = true;
        Console.WriteLine("\"Kroppen hittades i Höganäs hamn. Vi åker på en gång.\"");
        Console.ReadLine();
    }

    public void TalkToOmar()
    {
        Console.WriteLine("\"Ska vi åka då?\"");
        Console.ReadLine();
        Menu.Close();
    }
}

