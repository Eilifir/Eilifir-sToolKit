using UnityEngine;

public class HealthDebugControls_EventBus : MonoBehaviour
{
    [SerializeField] private PlayerHealth_EventBus target;
    [SerializeField] private int damage = 10;
    [SerializeField] private int heal = 5;

    private void Update()
    {
        if (target == null) return;

        if (Input.GetKeyDown(KeyCode.D)) target.TakeDamage(damage);
        if (Input.GetKeyDown(KeyCode.H)) target.Heal(heal);
    }
}
