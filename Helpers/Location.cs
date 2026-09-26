/* ==========================================================================
 *  HELPER CLASS – base class for every room/place in the game.
 *  You are NOT expected to understand the movement code below.
 *
 *  How to use: inherit from Location and override Name, Description
 *  and Actions (see Locations/RuneRoom.cs). That's it.
 *
 *  Exits ("Go north" etc.) are added to the menu automatically based on
 *  where the location sits in the map in World/Game – you don't write them.
 *  Want to block an exit? Override North()/East()/South()/West() and only
 *  call base.North() when the way is free (see RuneRoom.East()).
 * ========================================================================== */

abstract class Location : Interactive
{
    // Filled in by World when the map is built
    internal World World { get; set; } = null!;
    internal int X { get; set; }
    internal int Y { get; set; }

    protected override string ExitLabel => "Quit to main menu";

    internal override List<string> AllActions()
    {
        var lines = base.AllActions();

        // One "Go ..." line per direction that has a neighbour on the map.
        // The method name is the enum's name: Direction.North -> "North" -> North()
        foreach (Direction direction in Enum.GetValues<Direction>())
        {
            if (Neighbour(direction) != null)
                lines.Add($"Go {direction.ToString().ToLower()}:{direction}");
        }

        // Always show "Show inventory" at all locations
        lines.Add("Show inventory:ShowInventory");

        if (World.DevMode) lines.Add("DEV: Teleport:DevTeleport");

        return lines;
    }

    // These are the methods the exit lines above refer to
    public virtual void North() => Move(Direction.North);
    public virtual void East() => Move(Direction.East);
    public virtual void South() => Move(Direction.South);
    public virtual void West() => Move(Direction.West);

    public void ShowInventory()
    {
        Console.Clear();
        Console.WriteLine("INVENTORY");
        if (Player.Inventory.Count == 0)
        {
            Console.WriteLine("You don't own anything in this world!");
        }
        else
        {
            Console.WriteLine(String.Join("\n", Player.Inventory));
        }
        Console.ReadLine();
    }

    // Only shown while World.DevMode is true: jump to any location by class name
    public void DevTeleport()
    {
        Console.Clear();
        Console.WriteLine("Locations on the map:");
        foreach (string className in World.LocationNames)
            Console.WriteLine($"  {className}  ({World.Find(className)})");   // uses ToString() -> Name
        Console.Write("\nClass name: ");
        string input = Console.ReadLine() ?? "";
        if (World.Teleport(input))
            Menu.Close();   // leave this location so the new one is shown
        else
        {
            Console.WriteLine($"No location called \"{input}\". Check the spelling.");
            Console.ReadLine();
        }
    }

    // The location next to this one in a direction, or null if the map is empty there
    private Location? Neighbour(Direction direction)
    {
        var (dx, dy) = Delta(direction);
        return World.At(X + dx, Y + dy);
    }

    private void Move(Direction direction)
    {
        var (dx, dy) = Delta(direction);
        World.MoveTo(X + dx, Y + dy);
        Menu.Close();   // leave this location's menu so the new one can be shown
    }

    // Row 0 is north, so north is y - 1
    private static (int dx, int dy) Delta(Direction direction)
    {
        switch (direction)
        {
            case Direction.North: return (0, -1);
            case Direction.East: return (1, 0);
            case Direction.South: return (0, 1);
            case Direction.West: return (-1, 0);
            default: return (0, 0);
        }
    }
}
