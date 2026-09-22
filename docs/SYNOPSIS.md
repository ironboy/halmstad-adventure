# Jane the Ripper – synopsis och arbetsfördelning

## Bakgrund

London, i dag. En seriemördare som pressen döpt till **Jane the Ripper** har mördat tre unga män i Whitechapel – på samma platser och samma datum som Jack the Ripper 1888. Scotland Yard är nära att gripa henne, och hon försvinner.

Hon dyker upp på **Kullahalvön**. Hon har studerat halvöns historia och sägner och maskerar sina nya mord som **Kullamannens** verk: kroppar hittas vid grottorna, med "trollspår" och gamla runtecken runt omkring. Byborna viskar om att berget vaknat. Hon bor i den övergivna fyrvaktarbostaden vid Kullens fyr.

**Kriminalkommissarie Eva Nylén** från polisområde nordvästra Skåne (Helsingborg) skickas upp till polisstationen i Höganäs när det första offret hittas. Hon är spelets huvudperson. Spelaren *är* Eva.

> Om graden: *kriminalkommissarie* är den klassiska deckargraden (Wallander, Beck) och fungerar fint. I verkligheten heter utredaren ofta *kriminalinspektör* och förundersökningen leds av en åklagare – men det här är fiktion.

> Om geografin: Kullahalvön ligger i Höganäs kommun. Höganäs har en liten polisstation, men "riktiga" utredningar leds från Helsingborg (ca 20 km söderut). Det är därför Eva kommer *utifrån* – det ger en naturlig anledning för npc:er att vara misstänksamma mot "stadspolisen".

## Spelets form

Eva rör sig över kartan, pratar med folk och löser **delgåtor**. Varje delgåta ger **ett föremål eller en ledtråd** i inventariet. När hon har tillräckligt många kan hon konfrontera Jane i fyren – finalen.

Falsk hemsökelse är den röda tråden: överallt ser det ut som Kullamannen, men varje delgåta avslöjar en bit av bluffen (en högtalare i grottan, ett lånekort på boken om sägnerna, en hotellgäst med falskt namn...).

## Kartan (utkast)

Rad 0 är norr, kolumn 0 är väster. Halvöns spets (fyren) pekar nordväst.

```
        0                1                2               3                 4
rad 0   Kullens fyr      Silvergrottan    Nimis           Arilds hamn       Arilds kapell
rad 1   Fyrvaktarbostad  Josefinelust     Himmelstorp     Rusthållargården  –
rad 2   Ransvik          Mölle hamn       Grand Hôtel     Krapperups slott  Slottsbiblioteket
rad 3   –                –                Nyhamnsläge     Höganäs hamn      Polisstationen (START)
rad 4   –                –                –               Rättsmedicin      Evas bil (→ Helsingborg)
```

Utgångar skapas automatiskt mellan grannceller, så **klustren måste vara sammanhängande block** och bara gränsa till varandra där det är rimligt att gå. Kartan ovan är ett utkast – flytta gärna, men behåll blocken hela.

## Kluster – ett per grupp

Varje kluster är ett självständigt minispel: det ska gå att spela (och testa) helt utan de andra. Kontraktet mot resten av spelet är:

- **Kräver ingenting** från andra kluster (så att ni kan jobba oberoende).
- **Ger exakt ett föremål/ledtråd** till `Player.Inventory` när delgåtan är löst.
- **Stava rätt!** Föremålets namn står i tabellen nedan, med små bokstäver, exakt så. Finalen letar efter just den strängen – `"Signalement"` eller `"signalment"` hittas inte.

| # | Kluster | Locations | Npc-förslag | Delgåta | Ger |
|---|---------|-----------|-------------|---------|-----|
| 1 | **Höganäs – start** | Polisstationen, Höganäs hamn, Rättsmedicin | Kriminalinspektör Omar Sjöberg (kollega, skeptisk), rättsläkaren Dr Lindqvist, *DI Harriet Blake, Scotland Yard – per telefon* | Obduktionsrapporten: "trollklorna" är gjorda med en kirurgkniv. Ring London och matcha mot Ripper-morden. | `"obduktionsrapport"` |
| 2 | **Mölle** | Mölle hamn, Grand Hôtel, Ransvik | Receptionisten, en gammal fiskare som "sett Kullamannen", en badgäst | Hotelliggaren: en kvinna checkade in under falskt namn samma kväll som mordet. Fiskaren såg "trollet" – med ficklampa. | `"signalement"` |
| 3 | **Grottorna** | Silvergrottan, Josefinelust, stigen | Naturguiden, en skräckslagen turist, "Kullamannen" (någon i mask?) | Falsk hemsökelse: hitta högtalaren och projektorn som spelar upp "spöket". | `"högtalare"` |
| 4 | **Arild** | Arilds hamn, Arilds kapell, Rusthållargården | Prästen, en konstnär som skissade en okänd kvinna på piren, hotellvärden | Andra offret hittades här. Konstnärens skiss + prästens berättelse om vem som frågade om sägnerna. | `"skiss"` |
| 5 | **Krapperup** | Krapperups slott, parken, slottsbiblioteket | Slottsförvaltaren, hembygdsforskaren, trädgårdsmästaren | Boken om Kullamannen är utlånad – lånekortet har ett namn. Ett gåtfullt citat i boken pekar mot fyren. | `"lånekort"` |
| 6 | **Nimis & Himmelstorp** | Nimis, Himmelstorp, klippstranden | Eremiten som vaktar Nimis, ett par vandrare, en hund | En dagbokssida har spolats i land, fastkilad i drivvedstornet. Eremiten har sett ljus i fyren om nätterna. | `"dagbokssida"` |
| 7 | **Fyren – final** | Kullens fyr, Fyrvaktarbostaden, klipporna | Jane the Ripper, (ev. Kullamannen på riktigt?) | Konfrontationen. Kräver alla föremål ovan; varje föremål låser upp en replik/ett drag. Utan alla: Jane kommer undan. | Slutet |

Kluster 7 är lämpligt att läraren eller den grupp som blir klar först bygger, eftersom det beror på alla andras föremål.

**London?** Förslag: London finns med som *röst i telefon* (DI Blake i kluster 1) och i dagbokssidan, inte som karta. Det håller ihop kartan. Vill klassen ha en riktig London-del kan den byggas som ett åttonde kluster (Whitechapel-flashback) som nås från "Evas bil" – men det är extra.

## Komma igång (lektionen tisdag 22 september)

Vi jobbar alla i **samma repo** – inga forkar. `main` är skyddad: ingen kan pusha dit, allt går via pull requests som läraren godkänner.

1. Under lektionen: gå fram till lärarens dator och lägg till dig själv som *collaborator* i repot (Settings → Collaborators).
2. **Godkänn inbjudan.** Du får ett mejl från GitHub (och en notis på github.com) med "Accept invitation" – förrän du klickat på den kan du inte pusha. Gör det direkt, på plats.
3. Vi bestämmer i klassen vem som jobbar i vilken grupp.
4. **Var du inte med på lektionen?** Skicka ett sms till Thomas med ditt GitHub-användarnamn (telefonnummer finns i kursplanen), så lägger han till dig i repot och i en lämplig grupp. Godkänn inbjudan även då.
5. Varje grupp får en egen feature-branch, en per kluster:

   ```
   feature-1-hoganas-start
   feature-2-molle
   feature-3-grottorna
   feature-4-arild
   feature-5-krapperup
   feature-6-nimis-himmelstorp
   feature-7-fyren-final
   ```

   Hela gruppen jobbar på samma branch. Klona repot, sedan:

   ```
   git switch feature-2-molle
   ```

## Så jobbar en grupp

1. Skapa era filer i `Locations/<Kluster>/` och `Npcs/<Kluster>/`.
2. Byt ut kartan i `Game.Start()` mot **er egen lilla karta** med bara ert kluster, så kan ni spela och testa det ensamt:

   ```csharp
   World world = new([
       [new MolleHarbour(), new GrandHotel()],
       [new RansvikBeach(), null],
   ], 0, 0);
   ```

3. När delgåtan är löst: `Player.Inventory.Add("signalement");` – stavat exakt som i tabellen.
4. Committa och pusha till er branch ofta. Dra ner varandras ändringar med `git pull` innan ni börjar jobba, så slipper ni konflikter inom gruppen.
5. När klustret går att spela: skapa en pull request från er branch till `main`. Läraren slår ihop kartorna till den stora i `Game.cs` (er testkarta i `Game.cs` tas alltså inte med – den är bara för att ni ska kunna testa).

Regler för att PR:ar ska gå att slå ihop:

- Rör bara era egna mappar (och `Game.Start()` för er testkarta).
- Pusha bara till er egen branch.
- Klassnamn: på engelska (all kod på engelska, all speltext på svenska), unika (`MolleHarbour`, inte `Harbour`).
- Föremål: exakt den sträng som står i tabellen. Behöver ni ett nytt föremål, skriv in det i tabellen i er PR.
