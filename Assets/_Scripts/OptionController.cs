using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class OptionController : MonoBehaviour
{
    [SerializeField] Slider _volumeSlider;
    [SerializeField] Text _volumeSliderValueText;
    
    private const float DEFAULT_VOLUME = 0.5f;


    void Start()
    {
        _volumeSlider.value = PlayerPrefs.GetFloat("Volume");
        _volumeSliderValueText.text = _volumeSlider.value.ToString("F2");
    }
    
    public void ChangeMusicVolume()
    {
        var audioSource = FindObjectOfType<MusicManager>().GetComponent<AudioSource>();
        audioSource.volume = _volumeSlider.value;
        _volumeSliderValueText.text = _volumeSlider.value.ToString("F2");
        PlayerPrefs.SetFloat("Volume", audioSource.volume);
    }

    public void SetDefaultValues()
    {
        _volumeSlider.value = DEFAULT_VOLUME;
        _volumeSliderValueText.text = DEFAULT_VOLUME.ToString("F2");
        PlayerPrefs.SetFloat("Volume", DEFAULT_VOLUME);
    }
}
