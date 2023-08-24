using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class OptionController : MonoBehaviour
{
    public Slider VolumeSlider;
    public LevelLoader levelLoader;
    private MusicManager musicManager;
    
    void Start()
    {
        musicManager = GameObject.FindObjectOfType<MusicManager>();
        VolumeSlider.value = PlayerPrefsManager.GetMasterVolume();
    }
    
    public void SaveandExit()
    {
        PlayerPrefsManager.SetMasterVolumeKey(VolumeSlider.value);
        SceneManager.LoadScene("01 Start Menu");
    }

    
}
