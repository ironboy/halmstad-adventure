class Fighter // Fighter klass som fighters ärver och kan override om det behövs
{
    public virtual string Name => "";
    public int Hp = 100;

    public virtual void Attack(Fighter enemy, int choice) //Choice är switch val, se en av fighters
    {
        
    }
    public virtual void TakeDamage(int damageAmount)
    {
        Hp -= damageAmount;
        Console.WriteLine($"{Name} tar {damageAmount} skada!");
    }
}