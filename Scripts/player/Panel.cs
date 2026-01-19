using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class Basla : MonoBehaviour
{
    public GameObject AyarlarEkrani;
    public GameObject Setting;
    public GameObject Play;
    public GameObject BaslamaEkrani;      // Giriþ UI paneli
    public MonoBehaviour Movement;     // Movement scripti
    public MonoBehaviour npc;
    public Scrollbar volumeScrollbar;

    void Start()
    {
        AyarlarEkrani.SetActive(false);
        BaslamaEkrani.SetActive(true);
        Movement.enabled = false;
        npc.enabled = false;
        float savedVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);
        volumeScrollbar.value = savedVolume;
        AudioListener.volume = savedVolume;
         volumeScrollbar.onValueChanged.AddListener(OnVolumeChanged);
    }
    public void basla() 
    { 
    BaslamaEkrani.SetActive(false);
        Movement.enabled = true;
        npc.enabled = true;
    }
    public void Settings()
    {
        AyarlarEkrani.SetActive(true);
        Setting.SetActive(false);
        Play.SetActive(false);
    }
    public void Exit() 
    { 
    AyarlarEkrani.SetActive(false);
        Setting.SetActive(true);
        Play.SetActive(true);
    }
    public void OnVolumeChanged(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("MasterVolume", volume);

    }
}
