/* ==========================================================================
 *  HELPER – an INTERFACE: a contract with no code in it.
 *
 *  Anything that "is interactive" promises to have a Name, a Description,
 *  a list of Actions and a Run() method. That is all an interface says –
 *  it never says HOW. Interactive (the abstract class) is what actually
 *  implements this contract and adds the shared code.
 *
 *  Compare:
 *    interface       = the promise only (what)
 *    abstract class  = the promise + shared code (what + how)
 * ========================================================================== */

interface IInteractive
{
    string Name { get; }
    string[] Description { get; }
    string[] Actions { get; }
    void Run();
}
