using UnityEngine;

public class PlayerHealth_EventBus : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        if (amount <= 0) return;

        currentHealth = Mathf.Max(0, currentHealth - amount);
        PublishHealthChanged();
    }

    public void Heal(int amount)
    {
        if (amount <= 0) return;

        currentHealth = Mathf.Min(maxHealth, currentHealth + amount);
        PublishHealthChanged();
    }

    private void PublishHealthChanged()
    {
        HealthChangedEvent data = new(currentHealth, maxHealth);
        EventManager<GameEvent>.Publish(GameEvent.HealthChanged, data);
    }
}
