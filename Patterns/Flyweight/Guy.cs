using UnityEngine;
using UnityEngine.InputSystem;
public class Guy : MonoBehaviour
{
    [SerializeField] TypesOfGuy type;
    [SerializeField] InputActionReference movement;
    float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var dataGuy = FlyweightPointer.Get(type);
        speed = dataGuy.speed;
    }

    // Update is called once per frame
    void Update()
    {
        var dir = movement.ToInputAction().ReadValue<Vector2>();
        transform.position += (Vector3)dir * speed * Time.deltaTime;
    }
}
