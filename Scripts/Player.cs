using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Health))]
public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private Health _health;

    public void TakeDamage(int damage)
    {
        _health.OnTakeDamage(damage);

        if (_health.Value <= 0)
        {
            SceneManager.LoadScene(3);
        }
    }
}