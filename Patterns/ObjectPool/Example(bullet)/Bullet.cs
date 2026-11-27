using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
[RequireComponent (typeof(Collider))]
public class Bullet : MonoBehaviour,IFactoryProduct
{
    [SerializeField] private float speed = 12f;
    [SerializeField] private float lifeTime = 3f;
    private Vector3 direction;
    private float t;
    private System.Action<IFactoryProduct> _returnToPool;
    private Rigidbody _rb;
    private Collider _col;

    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized;
    }
    
    public void OnCreated()
    {
        t = 0f;
        if(direction == Vector3.zero ) direction = transform.forward;

        if(_rb == null) _rb = GetComponent<Rigidbody>();
        if(_col == null) _col = GetComponent<Collider>();
        _rb.isKinematic = true;
        _rb.detectCollisions = true;
        _col.isTrigger = true;
    }
    
    public void SetReturnToPool(System.Action<IFactoryProduct> returnAction)
    {
        _returnToPool = returnAction;
    }

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
        t += Time.deltaTime;
        if (t > lifeTime)
        {
            ReturnSelf();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        ReturnSelf();
    }
    private void ReturnSelf()
    {
        if (_returnToPool != null) _returnToPool(this);
        else Destroy(gameObject);
    }
}
