using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject _effect;
    [SerializeField] private GameObject _spawnEffect;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Cartridge _cartridge;
    [SerializeField] private Music _shoot;
    [SerializeField] private EnemyVision _enemyVision;
    [SerializeField] private float _speed;

    private float _time;

    private void Start()
    {
        _time = 0;
    }

    private void OnEnable()
    {
        _enemyVision.SeePlayer += OnSeePlayer;
    }

    private void OnDisable()
    {
        _enemyVision.SeePlayer -= OnSeePlayer;
    }

    public void GenerateBullet()
    {
        _shoot.PlayMusic();
        _cartridge.GenerateBullet(_effect, _spawnEffect, _bullet, _speed);
    }

    public void MoveObject(float axisX, float axisY)
    {
        _spawnEffect.transform.Translate(axisX, 0, 0);
        _spawnEffect.transform.Rotate(0, axisY, 0);
    }

    public void OnSeePlayer()
    {
        InvokeRepeating(nameof(GenerateBullet), 1, 3);
    }
}