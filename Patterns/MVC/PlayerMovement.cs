using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private void Awake()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        CapsuleCollider col = GetComponent<CapsuleCollider>();

        rb.isKinematic = true;
        col.isTrigger = false;
    }

    public void Move(Vector3 direction)
    {
        if (direction.sqrMagnitude > 1f)
            direction.Normalize();

        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}
