using UnityEngine;
using UnityEngine.InputSystem;


public class GunPooled : MonoBehaviour
{
    [SerializeField] private BulletFactoryPooled bulletFactory;
    [SerializeField] private Transform muzzle;
    [SerializeField] private InputActionReference shoot;

    void Update()
    {
        if (!shoot.action.WasPressedThisFrame()) return;
        var bullet = bulletFactory.CreateTyped(muzzle.position, muzzle.rotation);
        if (bullet != null )
        {
            bullet.SetDirection(muzzle.forward);
        }
    }
}
