/* ==========================================================================
 *  HELPER CLASS – holds the map (a grid of locations) and where the
 *  player is. You are NOT expected to understand the code in this file.
 *
 *  How to use (see Game.cs):
 *
 *    World world = new([
 *        [new RuneRoom(), new Hallway()],   // row 0 = north
 *        [null,           new Courtyard()], // null = nothing there
 *    ]);
 *    world.DevMode = true;   // adds "DEV: Teleport" to every location's menu
 *    world.Play();           // runs until the player quits to the main menu
 *
 *  The player starts in the top-left location unless you pass
 *  startX/startY. Exits between neighbouring cells are automatic.
 * ========================================================================== */

class World
{
    private readonly Location?[][] _map;
    private int _x, _y;
    private bool _moved;

    // A DICTIONARY: look up a location by its class name, e.g. "RuneRoom".
    // Built once when the map is built, used by the dev teleport.
    private readonly Dictionary<string, Location> _byClassName = [];

    /// <summary>While true, every location's menu gets a "DEV: Teleport" item.</summary>
    public bool DevMode { get; set; }

    public World(Location?[][] map, int startX = 0, int startY = 0)
    {
        _map = map;
        _x = startX;
        _y = startY;

        // Tell every location where it lives so it can find its exits,
        // and remember it by class name
        for (int y = 0; y < map.Length; y++)
            for (int x = 0; x < map[y].Length; x++)
                if (map[y][x] is Location loc)
                {
                    loc.World = this;
                    loc.X = x;
                    loc.Y = y;
                    _byClassName[loc.GetType().Name] = loc;
                }
    }

    /// <summary>The location at (x, y), or null if empty or outside the map.</summary>
    public Location? At(int x, int y) =>
        y >= 0 && y < _map.Length && x >= 0 && x < _map[y].Length ? _map[y][x] : null;

    /// <summary>All class names on the map, e.g. "RuneRoom", "Hallway".</summary>
    public IEnumerable<string> LocationNames => _byClassName.Keys;

    /// <summary>The location with this class name, or null if there is none.</summary>
    public Location? Find(string className) =>
        _byClassName.TryGetValue(className, out var loc) ? loc : null;

    /// <summary>Moves the player to the location with this class name. False if it doesn't exist.</summary>
    public bool Teleport(string className)
    {
        var loc = Find(className);
        if (loc == null) return false;
        MoveTo(loc.X, loc.Y);
        return true;
    }

    /// <summary>Runs the current location's menu; repeats while the player keeps moving.</summary>
    public void Play()
    {
        while (true)
        {
            _moved = false;
            At(_x, _y)!.Run();
            if (!_moved) return;   // player chose "0" instead of an exit
        }
    }

    internal void MoveTo(int x, int y)
    {
        _x = x;
        _y = y;
        _moved = true;
    }
}
