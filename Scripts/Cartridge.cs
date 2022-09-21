using UnityEngine;

[RequireComponent(typeof(BulletMove))]
public class Cartridge : MonoBehaviour
{
    [SerializeField] private BulletMove _bulletMove;

    public void GenerateBullet(GameObject effect, GameObject spawn, Bullet bullet, float speed)
    {
        GameObject eff = Instantiate(effect, spawn.transform.position, transform.rotation);
        eff.transform.SetParent(spawn.transform);
        Vector3 bulletPosition = spawn.transform.position;
        Vector2 bulletForce;
        bulletForce = spawn.transform.position - transform.position;
        Bullet bulletClone = Instantiate(bullet,
            bulletPosition,
            transform.rotation);
        _bulletMove.Move(bulletClone, bulletForce, speed);
    }
}