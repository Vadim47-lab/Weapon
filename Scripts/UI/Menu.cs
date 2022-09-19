using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private Music _press;
    [SerializeField] private Warning _warning;
    [SerializeField] private GameObject _menu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenMenu();
        }
    }

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void OpenMenu()
    {
        _press.PlayMusic();
        Time.timeScale = 0;
        _menu.SetActive(true);
    }

    public void CloseMenu()
    {
        _press.PlayMusic();
        _menu.SetActive(false);
        Time.timeScale = 1;
    }

    public void ReturnMenu()
    {
        _press.PlayMusic();
        SceneManager.LoadScene(0);
    }

    public void PressYes()
    {
        _press.PlayMusic();
        Application.Quit();
    }

    public void PressNo()
    {
        _press.PlayMusic();
        _warning.Disappear();
    }

    public void Exit()
    {
        _press.PlayMusic();
        _warning.ExitAppear();
    }
}