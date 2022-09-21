using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public void Move(Bullet bulletClone, Vector2 bulletForce, float speed)
    {
        bulletClone.Rigidbody2D.velocity = bulletForce * speed;
    }
}