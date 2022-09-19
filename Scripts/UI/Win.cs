using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    [SerializeField] private Present _present;
    [SerializeField] private Music _press;
    [SerializeField] private Toy _toy;
    [SerializeField] private Button _presentButton;

    private void OnEnable()
    {
        _presentButton.onClick.AddListener(OnPresentButtonClick);
    }

    private void OnDisable()
    {
        _presentButton.onClick.RemoveListener(OnPresentButtonClick);
    }

    private void OnPresentButtonClick()
    {
        _press.PlayMusic();
        _present.Disappear();
        _toy.Appear();
    }
}