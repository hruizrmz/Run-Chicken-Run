using UnityEngine;
using UnityEngine.UI;

public class MuteAudio : MonoBehaviour
{
    public AudioSource music;
    public Button muteButton;

    void Start()
    {
        music = GameObject.FindWithTag("Audio").GetComponent<AudioSource>();
        muteButton.onClick.AddListener(MuteAudioSource);
    }
    void MuteAudioSource()
    {
        music.mute = !music.mute;
    }
}
