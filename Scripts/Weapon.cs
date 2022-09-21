using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject _effect;
    [SerializeField] private GameObject _spawnEffect;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Cartridge _cartridge;
    [SerializeField] private Music _shoot;
    [SerializeField] private float _timeToShoot;
    [SerializeField] private float _speed;

    private float _time;

    private void Start()
    {
        InvokeRepeating(nameof(GenerateBullet), 1, 3);
        _time = 0;
    }

    public void Shoot()
    {
        if (Input.GetMouseButton(0) && _time <= 0)
        {
            GenerateBullet();
            _shoot.PlayMusic();

            _time = _timeToShoot;
        }

        _time -= Time.deltaTime;
    }

    public void GenerateBullet()
    {
        _cartridge.GenerateBullet(_effect, _spawnEffect, _bullet, _speed);
    }
}