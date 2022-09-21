using UnityEngine;
using static UnityEngine.ParticleSystem;

public class DestructionObject : MonoBehaviour
{
    [SerializeField] private GameObject _hitEffect;
    [SerializeField] private GameObject _killEffect;

    public void HitEffect()
    {
        DestroyGameObject(_hitEffect);
    }

    public void KillEffect()
    {
        DestroyGameObject(_killEffect);
    }

    private void DestroyGameObject(GameObject effect)
    {
        Instantiate(effect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}