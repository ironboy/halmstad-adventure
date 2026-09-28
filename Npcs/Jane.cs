class Jane : Npc
{
    public override string Name => "Jane Doe";

    public override string[] Description => [
        "En mystisk person som står vid fyren.",
        "Hon verkar ha något viktigt att berätta."
    ];

    public override string[] Actions => [
        "Prata med Jane Doe:TalkToJane"
    ];
}