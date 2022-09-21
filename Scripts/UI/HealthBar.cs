using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Transform _lifeBar;
    [SerializeField] private Health _health;

    private float _oldLifeBar;
    private readonly float _axisX = 1.75f;

    private void OnEnable()
    {
        _health.HealthChanged += OnHealhBarChanged;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= OnHealhBarChanged;
    }

    private void Start()
    {
        _oldLifeBar = _lifeBar.localScale.x;
    }

    public void OnHealhBarChanged(int health)
    {
        _lifeBar.localPosition = new Vector2(_axisX * health / 100 - _axisX, _lifeBar.localPosition.y);
        _lifeBar.localScale = new Vector2(_oldLifeBar * health / 100, _lifeBar.localScale.y);
    }
}