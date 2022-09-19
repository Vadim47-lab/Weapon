using UnityEngine;

public class Present : MonoBehaviour
{
    [SerializeField] private GameObject _gameObjectPresent;

    public void Disappear()
    {
        _gameObjectPresent.SetActive(false);
    }
}