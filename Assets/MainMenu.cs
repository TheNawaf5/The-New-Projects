using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("SampleScene"); // Replace with your actual game scene name
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}