using UnityEngine;
using UnityEngine.UI;

public class AboutUsButton : MonoBehaviour
{
    public Button aboutUsButton;

    void Start()
    {
        aboutUsButton.onClick.AddListener(OpenAboutUsLink);
    }
    void OpenAboutUsLink()
    {
        Application.OpenURL("https://renasonas.itch.io/run-chicken-run");
    }
}
