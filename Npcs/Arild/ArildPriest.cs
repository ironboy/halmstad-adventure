using System.Reflection;

class ArildPriest  : Npc

{
    public bool HasWine;
    public bool Bribed;

    


public static bool ToldAboutStranger { get; private set; }

public override string Name => "Heiter the Priest";

public override string[] Description => 
  Bribed
            ? ["Prästen smuttar på vinet. Han ser betydligt mer pratsam ut nu."]
            : ["En äldre man i prästkrage sitter och vinglar på en stor med blossande röda kinder.",
            "Hans blick verka har fastnat på Gudinnans väldiga... vattenmeloner.....",
            "Han verka inte märka av dig"
    ];


public override string [] Actions => Bribed
?["Fråga om offret:AskAboutVictim",
"Fråga om Kullamannen:AskAboutLegends"]

: HasWine

?["Ge prästen vinet:GiveWine"]
:["Försök prata med prästen:TryToTalk"];


public void TryToTalk()

{
    Console.WriteLine("Prästen muttar något om att munnen är för torr för att tala, men vänder sin rygg bort mot dig");
    Console.ReadLine();
    Menu.Close(); // He wont talk back to the chapel.

}

public void GiveWine()

    {
        Bribed =  true;
        HasWine = false;

        Console.WriteLine("Prästens ögon lyser upp. \"Ah... Herren välsigne er, kommissarien. Vad vill vill ni veta?\"");
        Console.ReadLine();   
        
        }

  public void AskAboutVictim()

    {
        Console.WriteLine ("\" Gud förbarme sig... fiskarna såg honom flytande vid hamnen\"" );
        Console.WriteLine("\"Någon hade dumpat kroppen från piren men Byborna säger att berget tog honom.\"");
        Console.WriteLine("\" Själv tror jag inte att troll bär kniv.\"");
        Console.ReadLine();
    }

    public void AskAboutLegends()

    {
        if(ToldAboutStranger)

        {
            Console.WriteLine("\" Som sagt: kvinnan med den engelska brytning. Fråga kostnären nere i hamn." );
            Console.WriteLine("Hon satt och ritade piren ela den veckan.\"");
        }
        else
        {
            Console.WriteLine("Prästen sänker rösten. \"Det var en kvinna här för en veckan sedan. Engelska brytning.\"");
            Console.WriteLine("\" Hon biktade sig, och vad hon sa får jag aldrig berätta. Men innan dess...\"");
            Console.WriteLine("\"... frågade hon allt om Kullamennn. Om rurorna Och var fyrvaktar bostaden låg\"");
            ToldAboutStranger = true;
        }

    Console.ReadLine();


    }



}