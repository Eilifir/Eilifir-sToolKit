public readonly struct HealthChangedEvent
{
    public int CurrentHealth { get; }
    public int MaxHealth { get; }

    public HealthChangedEvent(int currentHealth, int maxHealth)
    {
        CurrentHealth = currentHealth;
        MaxHealth = maxHealth;
    }
}
