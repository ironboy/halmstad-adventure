// 3a. HEMBYGDSFORSKAREN – NPC i källaren.
//
// Samma idé som bibliotekarien: bool-fält låser upp dialogen steg för steg.
//   _knowsWish  → han har avslöjat vad han drömmer om: slottets innersta rum
//   Bribed      → kommissarien har lovat honom tillträde (public – Kallare läser det)
//   _gaveTip    → han har berättat var boken står i Gång 5
//
// Mutan är INTE pengar – det är kommissariens makt att öppna slottets stängda rum.
// Pengar är en fälla: han blir förolämpad, men avslöjar samtidigt vad han egentligen vill ha.

class Hembygdsforskaren : Npc
{
    public bool Bribed;
    private bool _knowsWish;
    private bool _gaveTip;

    public override string Name => "Hembygdsforskaren";

    public override string[] Description => [
        Bribed
            ? "Hembygdsforskaren lutar sig fram med glittrande ögon. \"Vad vill kommissarien veta?\""
            : "En skum man med spetsig hatt blänger upp från en hög gulnade papper. \"Vad gör en polis här nere?\""
    ];

    public override string[] Actions
    {
        get
        {
            // ----- Efter mutan: samarbetsvillig -----
            if (Bribed)
            {
                List<string> helpful = ["Fråga om Kullamannen:AskAboutLegend",
                                        "Fråga om kvinnan som lånade boken:AskAboutWoman"];
                helpful.Add(_gaveTip
                    ? "Fråga om det sista kapitlet:AskAboutChapter"
                    : "Fråga var det andra exemplaret finns:AskWhereBook");
                return helpful.ToArray();
            }

            // ----- Före mutan: ovillig -----
            List<string> actions = ["Fråga om boken om Kullamannen:AskAboutBookRefused",
                                    "Fråga om sägnerna:AskAboutLegendsRefused"];

            actions.Add("Gör honom ett erbjudande");            // rubrik för undermenyn
            actions.Add("-Erbjud pengar:OfferMoney");
            if (_knowsWish)                                       // dyker upp först när du vet vad han vill ha
                actions.Add("-Lova tillträde till slottets innersta rum:OfferSanctum");
            actions.Add("-Ångra dig:Hesitate");

            return actions.ToArray();
        }
    }

    // ---------- Före mutan ----------

    public void AskAboutBookRefused()
    {
        Console.WriteLine("\"Böcker, böcker. Ni poliser läser bara protokoll.\"");
        Console.WriteLine("Han vänder demonstrativt blad i sina papper.");
        Console.ReadLine();
    }

    public void AskAboutLegendsRefused()
    {
        _knowsWish = true;
        Console.WriteLine("Han kan inte hålla sig. \"Sägnerna? Kullamannen är ingen saga!");
        Console.WriteLine("Svaren finns i slottets innersta rum – de gamla kamrarna. Trettio år har jag");
        Console.WriteLine("bett förvaltaren att få komma in. Trettio år av nej.\"");
        Console.ReadLine();
    }

    public void OfferMoney()
    {
        _knowsWish = true;
        Console.WriteLine("Han fnyser. \"Tror kommissarien att jag kan köpas med mynt?");
        Console.WriteLine("Det enda jag vill ha är att få se slottets innersta rum. Men det kan ju ingen ordna.\"");
        Console.ReadLine();
        Menu.Close();   // nytt val i undermenyn – rita om den
    }

    public void OfferSanctum()
    {
        Bribed = true;
        Console.WriteLine("\"Förvaltaren gör som polisen säger,\" säger du. \"Ett ord från mig, så öppnas kamrarna.\"");
        Console.WriteLine("Hembygdsforskaren tar av sig hatten. Händerna darrar.");
        Console.WriteLine("\"Då... då har vi en överenskommelse, kommissarien.\"");
        Console.ReadLine();
        Menu.Close();   // stänger undermenyn – nu visas de samarbetsvilliga frågorna
    }

    public void Hesitate()
    {
        Console.WriteLine("Du låter bli. Han har redan återgått till sina papper.");
        Console.ReadLine();
    }

    // ---------- Efter mutan ----------

    public void AskAboutLegend()
    {
        Console.WriteLine("\"Kullamannen vaktar berget och havet. Den som förstår hans gåtor");
        Console.WriteLine("hittar vägen. Den som inte förstår... ja.\"");
        Console.ReadLine();
    }

    public void AskAboutWoman()
    {
        Console.WriteLine("\"Hon var här nere i förra veckan. Frågade om det sista kapitlet – bara det.");
        Console.WriteLine("Hon verkade inte tro på sägnen. Hon verkade använda den.\"");
        Console.ReadLine();
    }

    public void AskWhereBook()
    {
        _gaveTip = true;
        Player.Inventory.Add("tips om gång 5");   // låser upp repet i Slottsbiblioteket
        Console.WriteLine("\"Gång 5, översta hyllan, längst in. Repet? Säg att jag skickade er.");
        Console.WriteLine("Och läs det sista kapitlet – det är där hon hittade vägen.\"");
        Console.ReadLine();
        Menu.Close();
    }

    public void AskAboutChapter()
    {
        Console.WriteLine("\"Det är en gåta. Jag har aldrig löst den. Kanske gör ni det.\"");
        Console.ReadLine();
    }
}