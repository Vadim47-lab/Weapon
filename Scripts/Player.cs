using UnityEngine;

public class Player : MonoBehaviour
{ 
    [SerializeField] private GameObject _menu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            _menu.SetActive(true);
        }
    }
}