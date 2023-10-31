using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBackToSettings : MonoBehaviour
{
    public void LoadSettingsScene()
    {
        SceneManager.LoadScene("Settings");
    }
}
