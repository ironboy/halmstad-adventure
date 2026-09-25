# Interface, enum, static och ToString – och var de hamnar i vår motor

Motorn (`Helpers/`) har fått fyra tillägg. **Ni behöver inte göra något** – era locations och npc:er fungerar precis som förut. Men tilläggen råkar vara exakt dagens fyra begrepp, så i stället för påhittade exempel tittar vi på hur de sitter i vår egen kod.

| Begrepp | Var i motorn |
|---|---|
| Statiska medlemmar | `Player` (hela klassen), `Menu.Close()`, `Menu.Create()` |
| Interface | `IInteractive` i `Helpers/IInteractive.cs` – `Interactive` implementerar det |
| Enum | `Direction` i `Helpers/Direction.cs` – används av `Location` för utgångarna |
| `ToString()` | `Interactive.ToString()` returnerar `Name` |
| Bonus: Dictionary | `World` slår upp platser på klassnamn – det är det som driver **DEV: Teleport** |

## 1. Statiska medlemmar – ni har använt dem hela tiden

En vanlig metod anropas på ett objekt: `_guard.Run()`. Det finns ett objekt, och metoden jobbar med *det* objektets fält. En **statisk** metod anropas på **klassen**: `Menu.Close()`, `Player.Has("lånekort")`. Inget objekt behövs – och kan inte ens finnas, om klassen är `static class`.

```csharp
static class Player
{
    public static List<string> Inventory { get; } = [];
    public static bool Has(string item) => Inventory.Contains(item);
}
```

`Player` är statisk av ett enda skäl: det finns exakt *en* spelare, och alla rum ska se samma ryggsäck. Det är också det som gör statiska variabler farliga i större program – vem som helst kan ändra `Player.Inventory` varifrån som helst. För ett litet spel är det rätt val; i inlämningsuppgiften bör ni fråga er "finns det verkligen bara en?" innan ni skriver `static`.

Ni har anropat statiska metoder sedan dag ett utan att tänka på det: `Console.WriteLine(...)`, `int.TryParse(...)`, `Console.ReadLine()`. Det finns ingen `new Console()`.

Tumregel: behöver metoden objektets fält → vanlig metod. Behöver den bara sina parametrar, eller ska det bara finnas *en* av något → `static`.

## 2. Interface – ett löfte utan kod

Alla våra menyklasser – `Game`, varje `Location`, varje `Npc` – ärver från `Interactive`. Den är en **abstrakt klass**: den har `Name`, `Description`, `Actions` *och* koden i `Run()` som ritar menyn. Ett **interface** är den första halvan utan den andra:

```csharp
interface IInteractive
{
    string Name { get; }
    string[] Description { get; }
    string[] Actions { get; }
    void Run();
}
```

Inga kroppar, inga fält, ingen kod. Bara en lista på vad en klass **lovar att ha**. En klass går med på löftet med ett kolon, och kompilatorn kontrollerar att allt finns:

```csharp
abstract class Interactive : IInteractive { ... }   // has Name, Description, Actions and Run() – OK
```

| | Abstrakt klass (`Interactive`) | Interface (`IInteractive`) |
|---|---|---|
| Innehåller | löfte **+ kod** (`Run()`, `ToString()`) | bara löftet |
| Betyder | "är en sorts …" | "kan …" |
| En klass kan ha | **en** basklass | **hur många** interface som helst |
| Namn | vad som helst | börjar med `I` av tradition |

Varför är `Interactive` en abstrakt klass och inte ett interface? Därför att den *bär kod* – `Run()` är samma för alla, och den koden vill vi skriva en gång. Interfacet är till för den som bara bryr sig om löftet:

```csharp
List<IInteractive> everything = [game, runeRoom, guard];
foreach (IInteractive thing in everything)
{
    Console.WriteLine(thing.Name);   // works – the interface promises Name
}
```

Den som håller i listan behöver inte veta om det är ett rum eller en person. Det är hela poängen: kod som bara behöver *löftet* ska bara känna till *löftet*.

## 3. Enum – en typ med fasta värden

Förut hade `Location` fyra `if`-satser och en `Move(dx, dy)`. Nu finns:

```csharp
enum Direction
{
    North,
    East,
    South,
    West
}
```

En **enum** är en egen typ som bara kan ha ett av de uppräknade värdena. `Direction.North` är inte en sträng och inte en `int` – skriver man `Direction.Nort` vägrar kompilatorn, och editorn föreslår de fyra värdena så fort man skrivit `Direction.`. Motorn använder den så här:

```csharp
foreach (Direction direction in Enum.GetValues<Direction>())
{
    if (Neighbour(direction) != null)
        lines.Add($"Go {direction.ToString().ToLower()}:{direction}");
}
```

`Enum.GetValues<Direction>()` ger alla fyra värdena, och `direction.ToString()` ger namnet – `"North"` – som råkar vara exakt namnet på metoden `North()`. Så menyraden `"Go north:North"` genereras av enumen; ingen skriver den för hand längre.

**När ska ni själva använda en enum?** När något bara kan vara ett av några få kända lägen. En `bool` räcker för två lägen, men blir det tre är det dags:

```csharp
enum GateState { Locked, Alarm, Open }

private GateState _state = GateState.Locked;

public override string[] Actions => _state == GateState.Open
    ? ["Gå igenom:WalkThrough"]
    : ["Prova nyckeln:TryKey"];
```

Det läses bättre än `int _state = 2`, och ingen kan råka sätta den till 7.

## 4. ToString() – hur ett objekt blir text

Alla objekt i C# har `ToString()`, ärvd från den översta klassen `object`. Standardversionen returnerar klassens namn, vilket sällan är vad man vill. `Interactive` skriver över den:

```csharp
public override string ToString() => Name;
```

Så `Console.WriteLine(guard)` skriver `Guard`, och `$"{runeRoom}"` ger `Rune room`. Teleport-listan (punkt 6) använder just det. Samma `override` som för `Actions` – `ToString()` är `virtual` i `object`.

## 5. Bonus: Dictionary – slå upp något på ett namn

Vi hoppade över dictionaries tidigare i kursen. Här är det första stället i vår kod där en `Dictionary` är den *rätta* datastrukturen. `World` behöver kunna svara på "vilket rum heter `Courtyard`?" – och att loopa igenom hela kartan varje gång vore dumt när man kan slå upp direkt:

```csharp
private readonly Dictionary<string, Location> _byClassName = [];

// when the map is built:
_byClassName[loc.GetType().Name] = loc;      // key = "Courtyard", value = the object

// when someone asks:
public Location? Find(string className) =>
    _byClassName.TryGetValue(className, out var loc) ? loc : null;
```

En `List<T>` är rätt när ordningen spelar roll och man loopar. En `Dictionary<TKey, TValue>` är rätt när man har en **nyckel** och vill ha **värdet** – ett namn, ett id, ett ord. `TryGetValue` är det säkra sättet att fråga: den returnerar `false` i stället för att krascha om nyckeln saknas.

## 6. DEV: Teleport – så använder ni det

I `Game.Start()` står nu `world.DevMode = true;`. Så länge den är `true` har varje plats ett extra menyval, **DEV: Teleport**, som listar alla platser på kartan med klassnamn och `Name`, och flyttar er dit ni skriver. Sätt samma rad i er egen testkarta i `Game.Start()` om ni vill. När spelet är klart sätter läraren `DevMode = false`.

## 7. Kolon i menytexter – nu inbyggt

Ändringen som föreslogs i syntaxartikeln på bloggen (avsnittet om kolon i menytexter) är nu gjord i motorn: menyn delar vid **sista** kolonet. `"Fråga: vem är du?:AskWho"` fungerar, och `"INSTÄLLNINGAR:"` blir en undermeny som visas med kolon. Det var faktiskt DEV-menyraden `"DEV: Teleport:DevTeleport"` som tvingade fram det.
