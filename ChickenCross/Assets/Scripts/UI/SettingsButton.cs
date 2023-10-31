using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsButton : MonoBehaviour
{
    public string settingsSceneName = "Settings";
    public void OpenSettingsScene()
    {
        SceneManager.LoadScene(settingsSceneName);
    }
}
