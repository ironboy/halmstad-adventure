class Johan : Fighter
{
    public override string Name => "Johan Falk";

    public override void Attack(Fighter enemy, int choice)
    {
        switch (choice) //Kollar valet
        {
            case 1:
                
                Console.WriteLine("Johan Falk skjuter!");
                enemy.TakeDamage(15);
                break;
            case 2:
                Console.WriteLine("Johan Falk slår!");
                enemy.TakeDamage(10);
                break;
        }
    }
}