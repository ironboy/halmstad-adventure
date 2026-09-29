class Kullamannen : Fighter
{
    public override string Name => "Kullamannen";

    public override void Attack(Fighter enemy, int choice)
    {
        switch (choice)
        {
            case 1:
                Console.WriteLine("Kullamannen stampar!");
                enemy.TakeDamage(10);
                break;
            case 2:
                Console.WriteLine("Kullamannen rapar!");
                enemy.TakeDamage(16);
                break;
        }
    }
    public override void TakeDamage(int damageAmount) //override på TakeDamge för kullamannen tar 2 damage mindre
    {
        Hp -= damageAmount - 2;
        Console.WriteLine($"Kullamannen har tjock hud! Tar bara {damageAmount -2} skada!");
        
    }
}



