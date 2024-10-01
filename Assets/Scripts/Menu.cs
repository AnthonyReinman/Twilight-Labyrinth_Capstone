using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OnPlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void OnAbilitiesButton()
    {
        SceneManager.LoadScene(2);
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }
    
}
