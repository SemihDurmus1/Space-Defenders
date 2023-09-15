using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameObject panelPause;
    [SerializeField] GameObject joystick;

    public void Exit()
    {
        Application.Quit();
    }

    public void PlayAgain()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }
    public void Pause()
    {
        Time.timeScale = 0f;

        joystick.SetActive(false);
        panelPause.SetActive(true);
    }
    public void Resume()
    {
        Time.timeScale = 1.0f;

        joystick.SetActive(true);
        panelPause.SetActive(false);
    }
}
