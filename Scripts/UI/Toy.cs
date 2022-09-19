using UnityEngine;

public class Toy : MonoBehaviour
{
    [SerializeField] private GameObject _gameObjectToy;

    public void Appear()
    {
        _gameObjectToy.SetActive(true);
    }
}