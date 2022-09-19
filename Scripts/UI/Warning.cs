using UnityEngine;

public class Warning : MonoBehaviour
{
    [SerializeField] private GameObject _warning;

    public void ExitAppear()
    {
        _warning.SetActive(true);
    }

    public void Disappear()
    {
        _warning.SetActive(false);
    }
}