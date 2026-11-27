using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Coin : MonoBehaviour
{
    [SerializeField] private int amount = 1;
    [SerializeField] private float spinSpeed = 90f;

    private void Reset()
    {
        GetComponent<Collider>().isTrigger = true;
    }

    private void Update()
    {
        transform.Rotate(0f, spinSpeed * Time.deltaTime, 0f, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        // La moneda habla con el Controller, no con el Model directamente.
        PlayerController controller = other.GetComponent<PlayerController>();

        if (controller == null)
            controller = other.GetComponentInParent<PlayerController>();

        if (controller == null) return;

        controller.AddCoin(amount);
        Destroy(gameObject);
    }
}
