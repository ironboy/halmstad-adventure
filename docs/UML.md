# UML – Jane the Ripper (halmstad-adventure)



```mermaid
classDiagram
    direction TB

    %% ===== Helpers =====
    class Interactive {
        <<abstract>>
        +string Name
        +string[] Description
        +string[] Actions
        #string ExitLabel
        ~AllActions() List~string~
        +Run() void
    }

    class Location {
        <<abstract>>
        ~World World
        ~int X
        ~int Y
        #string ExitLabel
        ~AllActions() List~string~
        +North() void
        +East() void
        +South() void
        +West() void
        +ShowInventory() void
        -Move(int dx, int dy) void
    }

    class Npc {
        <<abstract>>
        #string ExitLabel
    }

    class World {
        -Location[][] _map
        -int _x
        -int _y
        -bool _moved
        +World(Location[][] map, int startX, int startY)
        +At(int x, int y) Location
        +Play() void
        ~MoveTo(int x, int y) void
    }

    class Menu {
        +string Title
        -List~Menu~ _children
        -bool _closeRequested$
        +Close()$ void
        +Create(string[] lines, object instance)$ Menu
        +Run(string exitLabel) void
        ~RunOnce(string exitLabel) bool
    }

    class Player {
        <<static>>
        +List~string~ Inventory$
        +Has(string item)$ bool
    }

    %% ===== Game =====
    class Game {
        +string Name
        +string[] Description
        +string[] Actions
        #string ExitLabel
        +Start() void
        +Help() void
    }

    class Program {
        <<top-level statements>>
    }

    %% ===== Locations =====
    class Hoganashamn {
        -bool Trollmarks
        -bool WentSouth
        +Omar() void
        +Kolla() void
        +North() void
        +East() void
        +South() void
        +West() void
    }

    class PoliceStation {
        -OmarSjoberg _omarSjoberg
        -bool _talkedToOmar
        +TalkToOmarSjöberg() void
        +LookAround() void
    }

    class Forensic {
        -bool _deskSearched
        -Coroner _coroner
        -DIHarrietBlake _harriet
        +TakeReport() void
        +LeaveIt() void
        +TalkToCoroner() void
        +LookAround() void
        +CallHarriet() void
    }

    %% ===== Npcs =====
    class OmarSjoberg {
        -bool introduction
        +IntroduceYourself() void
        +AskAboutCase() void
    }

    class Coroner {
        +bool GetReport
        +AskForReport() void
        +TalkToCoroner() void
    }

    class DIHarrietBlake {
        +bool Called
        +Call() void
        +CallAgain() void
    }

    %% ===== Arv (generalisering) =====
    Interactive <|-- Game
    Interactive <|-- Location
    Interactive <|-- Npc
    Location <|-- Hoganashamn
    Location <|-- PoliceStation
    Location <|-- Forensic
    Npc <|-- OmarSjoberg
    Npc <|-- Coroner
    Npc <|-- DIHarrietBlake

    %% ===== Komposition / association =====
    World "1" o-- "0..*" Location : _map
    Location "0..*" --> "1" World : World
    PoliceStation "1" *-- "1" OmarSjoberg
    Forensic "1" *-- "1" Coroner
    Forensic "1" *-- "1" DIHarrietBlake
    Menu "1" *-- "0..*" Menu : _children

    %% ===== Beroenden =====
    Program ..> Game : skapar och kör
    Game ..> World : skapar i Start()
    Game ..> Player : Inventory.Clear()
    Interactive ..> Menu : Create / RunOnce
    Location ..> Player : ShowInventory
    Forensic ..> Player : Inventory.Add
    Forensic ..> Coroner : läser GetReport
```

## Förklaring av symboler

| Symbol | Betydelse |
|---|---|
| `+` / `-` / `#` / `~` | public / private / protected / internal |
| `$` | static |
| `<\|--` | arv (A är basklass till B) |
| `*--` | komposition – ägaren skapar och äger objektet (`new()` i fältet) |
| `o--` | aggregation – World håller Locations som skapas i `Game.Start()` |
| `-->` | association – Location har en referens tillbaka till sin World |
| `..>` | beroende – klassen använder den andra utan att spara den |
