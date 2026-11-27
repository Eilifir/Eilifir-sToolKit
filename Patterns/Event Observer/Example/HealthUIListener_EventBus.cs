using UnityEngine;

public class HealthUIListener_EventBus : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager<GameEvent>.Subscribe<HealthChangedEvent>(
            GameEvent.HealthChanged,
            OnHealthChanged
        );
    }

    private void OnDisable()
    {
        EventManager<GameEvent>.Unsubscribe<HealthChangedEvent>(
            GameEvent.HealthChanged,
            OnHealthChanged
        );
    }

    private void OnHealthChanged(HealthChangedEvent data)
    {
        Debug.Log($"[Event Manager] Vida: {data.CurrentHealth}/{data.MaxHealth}");
    }
}
