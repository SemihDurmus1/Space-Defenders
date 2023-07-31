using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]GameObject panelPause;


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

        panelPause.SetActive(true);
    }
    public void Resume()
    {
        Time.timeScale = 1.0f;

        panelPause.SetActive(false);
    }
}
