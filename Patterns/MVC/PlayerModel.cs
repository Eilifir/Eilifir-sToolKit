using System;

public class PlayerModel
{
    public int MaxHealth { get; }
    public int CurrentHealth { get; private set; }
    public int Coins { get; private set; }
    public bool IsDead => CurrentHealth == 0;

    public PlayerModel(int maxHealth)
    {
        MaxHealth = Math.Max(1, maxHealth);
        CurrentHealth = MaxHealth;
        Coins = 0;
    }

    public void TakeDamage(int amount)
    {
        if (amount <= 0 || IsDead) return;

        CurrentHealth = Math.Max(0, CurrentHealth - amount);
    }

    public void Heal(int amount)
    {
        if (amount <= 0 || CurrentHealth == MaxHealth) return;

        CurrentHealth = Math.Min(MaxHealth, CurrentHealth + amount);
    }

    public void AddCoin(int amount)
    {
        if (amount <= 0) return;

        Coins += amount;
    }

    public void ResetStats()
    {
        CurrentHealth = MaxHealth;
        Coins = 0;
    }
}
