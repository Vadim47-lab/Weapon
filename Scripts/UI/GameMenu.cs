using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenu: MonoBehaviour
{
    [SerializeField] private Warning _warning;
    [SerializeField] private Music _press;
    [SerializeField] private Music _background;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _returnButton;

    private bool _playSong = false;

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
        _returnButton.onClick.AddListener(OnReturnMenuButtonClick);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
        _returnButton.onClick.RemoveListener(OnReturnMenuButtonClick);
    }

    private void Start()
    {
        PlayMusic();
        _playSong = true;
    }

    private void OnRestartButtonClick()
    {
        PlayMusic();
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    private void OnExitButtonClick()
    {
        PlayMusic();
        _warning.ExitAppear();
    }

    private void OnReturnMenuButtonClick()
    {
        PlayMusic();
        SceneManager.LoadScene(0);
    }

    public void PressNo()
    {
        PlayMusic();
        _warning.Disappear();
    }

    public void PressYesExit()
    {
        PlayMusic();
        Application.Quit();
    }

    private void PlayMusic()
    {
        if (_playSong == true)
        {
            _press.PlayMusic();
        }

        if (_playSong == false)
        {
            _background.PlayMusic();
        }
    }
}