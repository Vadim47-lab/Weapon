using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTime : MonoBehaviour
{
    [SerializeField] private TMP_Text _textTime;
    [SerializeField] private float _endTime;

    private float _timeGame;

    private void Update()
    {
        _timeGame += Time.deltaTime;
        ShowTimeGame();

        if (_timeGame >= _endTime)
        {
            SceneManager.LoadScene(2);
        }
    }

    private void ShowTimeGame()
    {
        _textTime.text = _timeGame.ToString();
    } 
}