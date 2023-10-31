using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBackToMenu : MonoBehaviour
{
    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
