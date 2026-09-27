/* ==========================================================================
 *  HELPER – an ENUM: a type with a fixed set of named values.
 *
 *  A location can only have exits in these four directions, so instead of
 *  four separate method names or strings like "north" we use one type.
 *  Direction.North.ToString() gives "North" – which is exactly the name of
 *  the method Location.North(), so the menu lines can be generated.
 * ========================================================================== */

enum Direction
{
    North,
    East,
    South,
    West
}
